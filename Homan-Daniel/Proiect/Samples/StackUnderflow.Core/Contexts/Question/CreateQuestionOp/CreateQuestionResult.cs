using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.Extensions.Cloning;
using Access.Primitives.IO;
using CSharp.Choices;
using LanguageExt;
using StackUnderflow.Domain.Schema.Models;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult : IDynClonable { }
        public class QuestionCreated : ICreateQuestionResult
        {
            public QuestionSummary Question { get; }
            public object Author { get; set; }
            public object QuestionUser { get; set; }
            public object QuestionSummary { get; set; }

            public QuestionCreated(QuestionSummary question)
            {
                Question = question;
            }

            public object Clone() => this.ShallowClone();

        }
        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; private set; }

            public object Clone() => this.ShallowClone();
        }
        public class InvalidRequest : ICreateQuestionResult
        {
            public string Message { get; }

            public InvalidRequest(string message)
            {
                Message = message;
            }

            public object Clone() => this.ShallowClone();
        }
    }
}
