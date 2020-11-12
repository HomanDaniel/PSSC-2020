using System;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    [Serializable]
    public class InvalidAnswerTextException : Exception
    { 
        public InvalidAnswerTextException()
        {

        }

        public InvalidAnswerTextException(string answerText) : base($"Invalid text")
        {
        }
    }
}