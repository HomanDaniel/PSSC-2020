using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
  
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        {
        }

    
        public InvalidQuestionException(string question) : base($"The value \"{question}\" is an invalid question format(question>1000 c).")
        {
        }
        public InvalidQuestionException(string title,List<string> tag) : base($"The value \"{tag.Count}\" is an invalid question format(tag).")
        {
        }
    }
}
