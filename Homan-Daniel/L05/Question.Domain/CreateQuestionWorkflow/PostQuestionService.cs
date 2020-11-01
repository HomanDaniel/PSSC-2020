using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.Question;
using LanguageExt.Common;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class PostQuestionService
    {
        public Result<VerifiedQuestion> VerifiedQuestion(UnverifiedQuestion question)
        {
            return new VerifiedQuestion(question.Question, question.Tag);
        }
    }
}

