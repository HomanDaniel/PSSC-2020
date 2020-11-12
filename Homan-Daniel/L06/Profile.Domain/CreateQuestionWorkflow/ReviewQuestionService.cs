using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateQuestionWorkflow.QuestionText;

namespace Question.Domain.CreateQuestionWorkflow
{
    public class ReviewQuestionService
    {
        public Task RewriteQuestionText(VerifiedQuestion question)
        {
            return Task.CompletedTask;
        }
    }
}
