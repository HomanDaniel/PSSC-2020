using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostAnswerWorkflow.Outputs
{
    [AsChoice]
    public static partial class LanguageCheckResult
    {
        public interface IVerifyLanguage { }

        public class VerifiedText : IVerifyLanguage
        {
            public int Certainty { get; }

            public VerifiedText(int certainty)
            {
                Certainty = certainty;
            }
        }

        public class UnverifiedText : IVerifyLanguage
        {
            public UnverifiedText(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }

            public string ErrorMessage { get; private set; }

        }
    }
}
