using LanguageExt;
using Question.Domain.CreateQuestionWorkflow;
using Question.Domain.PostAnswerWorkflow.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication.ExtendedProtection;

namespace Test.App
{
    class ProgramQuestion
    {

        static void Main(string[] args)
        {

            var expr = from createReplyResult in BoundedContext.ValidateReplyText(10, "To be tested", 1)
                       let validReply = (ValidateReplyResult.ValidateReplyText)createReplyResult
                       from checkLanguageResult in BoundedContext.LanguageCheck(validReply.AnswerText)
                       from ownerAck in BoundedContext.SendAckToQuestionOwner(checkLanguageResult.ToString(), 10, 1)
                       from authorAck in BoundedContext.SendAckToReplyAuthor(checkLanguageResult.ToString(), 10, 2)
                       select (validReply, checkLanguageResult, ownerAck, authorAck);


        }
    }
}
