using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.QuestionText;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class VerifyQuestionService
    {
        public Result<VerifiedQuestion> VerifyQuestion(UnverifiedQuestion question)
        {
            return new VerifiedQuestion(question.Question,question.Tags);
        }
    }
}
