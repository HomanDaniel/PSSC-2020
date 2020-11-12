using CSharp.Choices;
using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.PostAnswerWorkflow.Outputs.LanguageCheckResult;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    [AsChoice]
    public static partial class ValidateReplyResult
    {

        public interface IValidateReply { }

        public class UnvalidateReply : IValidateReply
        {
            public UnvalidateReply(int idQuestion, string answerText, int replyAutorId)
            {
                IdQuestion = idQuestion;
                AnswerText = answerText;
                ReplyAutorId = replyAutorId;
            }

            public int IdQuestion { get; private set; }
            public string AnswerText { get; private set; }

            public int ReplyAutorId { get; private set; }

            public Result<UnvalidateReply> SendEmail(int idQuestion, string answerText, int replyAutorId)
            {
                if (IsAnswerTextValid(answerText))
                {
                    return new UnvalidateReply(idQuestion, answerText, replyAutorId);
                }
                else
                {
                    return new Result<UnvalidateReply>(new InvalidAnswerTextException(answerText));
                }
            }

            private static bool IsAnswerTextValid(string answerText)
            {

                //validate 
                if (answerText.Length >= 10 && answerText.Length >= 500)
                {
                    return true;
                }
                return false;
            }

        }

        public class ValidateReplyText : IValidateReply
        {
            public ValidateReplyText(int idQuestion, string answerText, int replyAutorId)
            {
                IdQuestion = idQuestion;
                AnswerText = answerText;
                ReplyAutorId = replyAutorId;
            }

            public int IdQuestion { get; private set; }
            public string AnswerText { get; private set; }

            public int ReplyAutorId { get; private set; }


        }
    }
}
