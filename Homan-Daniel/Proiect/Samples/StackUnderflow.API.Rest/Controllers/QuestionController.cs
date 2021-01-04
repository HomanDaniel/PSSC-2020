using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp;
using StackUnderflow.Domain.Core.Contexts.Question;
using System;
using StackUnderflow.Domain.Core.Contexts.Question.ConfirmationOp;
using GrainInterfaces;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly IClusterClient _client;

        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext, IClusterClient client)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _client = client;
        }


        [HttpPost("post")]
        public async Task<IActionResult> CreateAndConfirmationQuestion([FromBody] CreateQuestionCmd createQuestionCmd)
        {
            QuestionWriteContext ctx = new QuestionWriteContext(
               new EFList<Post>(_dbContext.Post),
               new EFList<User>(_dbContext.User));

            var dependencies = new QuestionDependencies();
            dependencies.GenerateConfirmationToken = () => Guid.NewGuid().ToString();
            dependencies.SendConfirmationEmail = SendEmail;

            var expr = from createQuestionResult in QuestionDomain.CreateQuestion(createQuestionCmd)
                       let user = createQuestionResult.SafeCast<CreateQuestionResult.QuestionCreated>().Select(p => p.Author)
                       let confirmationCmd = new ConfirmationCmd(user)
                       from ConfirmationResult in QuestionDomain.ConfirmQuestion(confirmationCmd)
                       select new { createQuestionResult, ConfirmationResult };
            var r = await _interpreter.Interpret(expr, ctx, dependencies);
            _dbContext.SaveChanges();
            return r.createQuestionResult.Match(
                created => Ok(created),
                // created => (IActionResult)Ok(created.Question.PostId),
                notCreated => StatusCode(StatusCodes.Status500InternalServerError, "Question could not be created."),//todo return 500 (),
            invalidRequest => BadRequest("Invalid request."));

        }



        private TryAsync<ConfirmationAcknowledgement> SendEmail(ConfirmationLetter letter)
       => async () =>
       {
           var emialSender = _client.GetGrain<IEmailSender>(0);
           await emialSender.SendEmailAsync(letter.Letter);
           return new ConfirmationAcknowledgement(Guid.NewGuid().ToString());
       };
    }
}
