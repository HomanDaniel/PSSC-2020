using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Inputs
{
    public class LanguageCheckCmd
    {
        public LanguageCheckCmd(string answerText)
        {
            AnswerText = answerText;
        }

        public string AnswerText { get; private set; }

    }
}
