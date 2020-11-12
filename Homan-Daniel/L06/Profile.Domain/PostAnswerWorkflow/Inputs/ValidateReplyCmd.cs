using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Domain.PostAnswerWorkflow
{
    public class ValidateReplyCmd
    {
        public ValidateReplyCmd(int idQuestion, string answerText, int replyAutorId)
        {
            IdQuestion = idQuestion;
            AnswerText = answerText;
            ReplyAutorId = replyAutorId;
        }

        [Required]
        public string AnswerText { get; private set; }

        [Required]
        public int IdQuestion { get; private set; }

        [Required]
        public int ReplyAutorId { get; private set; }
    }
}
