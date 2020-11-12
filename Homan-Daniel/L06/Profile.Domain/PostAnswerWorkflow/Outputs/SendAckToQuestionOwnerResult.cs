using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    [AsChoice]
    public static partial class SendAckToQuestionOwnerResult
    {
        public interface ISendAckToQuestionOwner { }
        public class ReplyReceived : ISendAckToQuestionOwner
        {
            public ReplyReceived(string message)
            {
                Message = message;
            }

            public string Message { get; private set;}

        }

        public class ReplyUnreceived : ISendAckToQuestionOwner
        {
            public ReplyUnreceived(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set;}
        }
    }
}
