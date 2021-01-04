using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Access.Primitives.Extensions.Cloning;
using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;
using StackUnderflow.Domain.Core.Contexts.Question.ConfirmationOp;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp
{
    public struct CreateQuestionCmd
    {
        public interface ICreateQuestionResult : IDynClonable
        {
            Microsoft.AspNetCore.Mvc.IActionResult Match(Func<ConfirmationResult.QuestionConfirmed, Microsoft.AspNetCore.Mvc.OkObjectResult> p1, Func<ConfirmationResult.QuestionNotConfirmed, Microsoft.AspNetCore.Mvc.ObjectResult> p2, Func<ConfirmationResult.InvalidRequest, Microsoft.AspNetCore.Mvc.BadRequestObjectResult> p3);
        }
        public CreateQuestionCmd(Guid organisationId, string userName, string questionTitle, string questionBody, string questionTags, Guid userId, Guid questionId)
        {
            OrganisationId = organisationId;
            UserName = userName;
            QuestionTitle = questionTitle;
            QuestionBody = questionBody;
            QuestionTags = questionTags;
            UserId = userId;
            QuestionId = questionId;
        }
        [GuidNotEmpty]
        public Guid OrganisationId { get; set; }
        [GuidNotEmpty]
        public Guid QuestionId { get; set; }
        [GuidNotEmpty]
        public Guid UserId { get; set; }
        [Required]
        public string QuestionTitle { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string QuestionBody { get; set; }
        [Required]
        public string QuestionTags { get; set; }
    }
}
