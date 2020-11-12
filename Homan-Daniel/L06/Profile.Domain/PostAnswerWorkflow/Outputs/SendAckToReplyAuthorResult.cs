using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    public class SendAckToReplyAuthorResult
    {
        public interface ISendAckToReplyAuthor { }
        public class ReplyPublished : ISendAckToReplyAuthor
        {
            public ReplyPublished(string message)
            {
                Message = message;
            }

            public string Message { get; private set; }
        }

        public class ReplyUnsent : ISendAckToReplyAuthor
        {
            public ReplyUnsent(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }
        }
    }
}
