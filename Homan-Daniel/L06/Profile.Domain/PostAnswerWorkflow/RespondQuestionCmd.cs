using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Domain.PostAnswerWorkflow
{
    public struct RespondQuestionCmd
    {
        public RespondQuestionCmd(int idQuestion,int idAuthor, int idOwner, string answerText)
        {
            IdQuestion = idQuestion;
            IdAuthor = idAuthor;
            IdOwner = idOwner;
            AnswerText = answerText;
           
        }

        [Required]
        public string AnswerText { get; private set; }

        [Required]
        public int IdQuestion { get; private set; }

        [Required]
        public int IdAuthor { get; private set; }

        [Required]
        public int IdOwner { get; private set; }
    }
}
