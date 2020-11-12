using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow
{
    [AsChoice]
    public static partial class RespondQuestionResult
    {
        public interface IReplay { }

        public class ReplayPublised : IReplay
        {
            public ReplayPublised(string replayText)
            {
                ReplayText = replayText;
            }

            public string ReplayText { get; private set; }
        }

        public class ReplyValidationFailed : IReplay
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public ReplyValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }

        public class ReplyNotPublished : IReplay
        {
            public ReplyNotPublished(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; set; }
        }
    }
}
