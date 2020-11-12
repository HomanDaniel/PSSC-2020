using LanguageExt;
using Question.Domain.PostAnswerWorkflow.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.PostAnswerWorkflow.Outputs.LanguageCheckResult;

namespace Question.Domain.PostAnswerWorkflow
{
    public static class OrderOperations
    {
      /*  public static Either<Outputs.ValidationError, ValidateReplyResult> ValidateReply(Func<Outputs.ValidateReplyResult.UnvalidateReply, Either<Outputs.ValidationError, Outputs.ValidateReplyResult.ValidateReplyText>> checkIdQuestion,
                Func<Outputs.ValidateReplyResult.UnvalidateReply, Either<Outputs.ValidationError, Outputs.ValidateReplyResult.ValidateReplyText>> checkTextReply,
                Func<Outputs.ValidateReplyResult.UnvalidateReply, Either<Outputs.ValidationError, Outputs.ValidateReplyResult.ValidateReplyText>> checkIdAuthor,
                Outputs.ValidateReplyResult.UnvalidateReply text)
        {
            var textValidationResult = checkTextReply(text.AnswerText);
            return textValidationResult.Match(
                validAnswerText =>
                {
                    var idQuestionResult = checkIdQuestion(text.IdQuestion);
                    return idQuestionResult.Match(
                        validIdQuestion =>
                        {
                            var idAuthorReply = checkIdAuthor(text.ReplyAutorId);
                            return idQuestionResult.Match<Either<ValidationError, ValidateReplyResult>>(
                        validatedIdAuthor => new ValidateReplyResult(validIdQuestion, validAnswerText, validatedIdAuthor), error => error);
                        },
                        error => error);

                },
                error => error);
        }*/
        
    }
}
