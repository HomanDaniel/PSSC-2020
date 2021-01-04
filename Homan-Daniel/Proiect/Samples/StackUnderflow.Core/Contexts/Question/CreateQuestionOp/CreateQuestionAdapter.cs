using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO.Attributes;
using Access.Primitives.IO.Mocking;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.EF.Models;

using StackUnderflow.Domain.Schema.Backoffice;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp.CreateQuestionResult;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp;
using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.DatabaseModel.Models;
using ICreateQuestionResult = StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp.CreateQuestionResult.ICreateQuestionResult;

namespace StackUnderflow.Backoffice.Adapters.CreateQuestion
{
    public partial class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult, BackofficeWriteContext, BackofficeDependencies>
    {
        private readonly IExecutionContext _ex;

        public CreateQuestionAdapter(IExecutionContext ex)
        {
            _ex = ex;
        }

        public override async Task<ICreateQuestionResult> Work(CreateQuestionCmd command, BackofficeWriteContext state, BackofficeDependencies dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestionIfMissing(state, CreateQuestionFromCommand(command))
                           select t;


            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidRequest(ex.ToString()));

            return (ICreateQuestionResult)result;
        }

        private object AddQuestionIfMissing(BackofficeWriteContext state, Question question)
        {
            throw new System.NotImplementedException();
        }




        private Question CreateQuestionFromCommand(CreateQuestionCmd cmd)
        {
            var question = new Question()
            { 
                OrganisationId = cmd.OrganisationId,
                Name = cmd.UserName,
                Title = cmd.QuestionTitle,
                Body = cmd.QuestionBody,
                Tags = cmd.QuestionTags,
                QuestionId = cmd.QuestionId,
            };
            return question;
        }

        public override Task PostConditions(CreateQuestionCmd op, CreateQuestionResult.ICreateQuestionResult result, BackofficeWriteContext state)
        {
            return Task.CompletedTask;
        }

       
    }
}
