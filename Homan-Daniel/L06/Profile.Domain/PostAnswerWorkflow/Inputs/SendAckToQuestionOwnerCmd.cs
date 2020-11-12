using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Inputs
{
    public class SendAckToQuestionOwnerCmd
    {
        public SendAckToQuestionOwnerCmd(string answerText, int idQuestion, int replyAutorId)
        {
            AnswerText = answerText;
            IdQuestion = idQuestion;
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
