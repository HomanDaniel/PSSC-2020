using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    public class ValidationError
    {
        public string ErrorMessage { get; private set; }

        internal ValidationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
