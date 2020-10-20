using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Domain.PostAnswerWorkflow
{
    [AsChoice]
    public static partial class PostAnswerResult
    {
        public interface IPostAnswerResult { }

        public class PostAnswer: IPostAnswerResult
        {
            public PostAnswer(string answerText)
            {
                AnswerText = answerText;
            }

            public string AnswerText { get; set; }
        }

        public class AnswerNotPosted : IPostAnswerResult
        {
            public AnswerNotPosted(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; set; }
        }

        public class AnswerValidationFailed : IPostAnswerResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public AnswerValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
