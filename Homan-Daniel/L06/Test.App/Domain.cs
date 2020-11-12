using Primitives.IO;
using Profile.Domain.PostAnswerWorkflow;
using Question.Domain.PostAnswerWorkflow.Outputs;
using Question.Domain.PostAnswerWorkflow.Inputs;

using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using static PortExt;

namespace Test.App
{
    public static class BoundedContext
    {
        public static Port<ValidateReplyResult.IValidateReply> ValidateReplyText(int idQuestion, string answerText, int replyAutorId)
            => NewPort<ValidateReplyCmd, ValidateReplyResult.IValidateReply>(new ValidateReplyCmd(idQuestion, answerText, replyAutorId));

        public static Port<LanguageCheckResult.IVerifyLanguage> LanguageCheck(string answerText)
            => NewPort<LanguageCheckCmd, LanguageCheckResult.IVerifyLanguage>(new LanguageCheckCmd(answerText));

        public static Port<SendAckToQuestionOwnerResult.ISendAckToQuestionOwner> SendAckToQuestionOwner(string answerText, int idQuestion, int replyAutorId)
       => NewPort<SendAckToQuestionOwnerCmd, SendAckToQuestionOwnerResult.ISendAckToQuestionOwner>(new SendAckToQuestionOwnerCmd(answerText, idQuestion, replyAutorId));

        public static Port<SendAckToReplyAuthorResult.ISendAckToReplyAuthor> SendAckToReplyAuthor(string answerText, int idQuestion, int idReply)
        => NewPort<SendAckToReplyAuthorCmd, SendAckToReplyAuthorResult.ISendAckToReplyAuthor>(new SendAckToReplyAuthorCmd(answerText, idQuestion, idReply));

    }
}
