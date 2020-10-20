using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Domain.PostAnswerWorkflow
{
    public struct PostAnswerCmd
    {
        public PostAnswerCmd(string answerText)
        {
            AnswerText = answerText;
        }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(30)]
        public string AnswerText { get; private set; }
    }
}
