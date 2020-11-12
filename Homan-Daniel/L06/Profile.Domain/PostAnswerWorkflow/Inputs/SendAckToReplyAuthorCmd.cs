using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Inputs
{
    public class SendAckToReplyAuthorCmd
    {
        public SendAckToReplyAuthorCmd(string answerText, int idQuestion, int idReply)
        {
            AnswerText = answerText;
            IdQuestion = idQuestion;
            IdReply = idReply;
        }

        [Required]
        public string AnswerText { get; private set; }

        [Required]
        public int IdQuestion { get; private set; }

        [Required]
        public int IdReply { get; private set; }
    }
}
