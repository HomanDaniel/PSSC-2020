using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionTextException : Exception
    {
        public InvalidQuestionTextException()
        {

        }

        public InvalidQuestionTextException(string question) : base($"The value \"{question}\" is an invalid question format.")
        {
        }
    }
}
