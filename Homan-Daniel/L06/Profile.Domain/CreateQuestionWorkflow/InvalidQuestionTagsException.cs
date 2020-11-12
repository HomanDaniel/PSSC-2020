using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionTagsException : Exception
    {
        public InvalidQuestionTagsException()
        {

        }

        public InvalidQuestionTagsException(List<string> tags) : base($"The value \"{tags.Count}\" is an invalid question format.Please enter no more than 3 tags.")
        {

        }
    }
}
