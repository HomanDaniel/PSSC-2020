using CSharp.Choices;
using LanguageExt.Common;
using Question.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class QuestionText
    {
        public interface IQuestionText { }

        public class UnverifiedQuestion : IQuestionText
        {
            public string Question { get; private set; }
            public List<string> Tags { get; private set; }
            private UnverifiedQuestion(string question, List<string> tags)
            {
                Question = question;
                Tags = tags;
            }

            public static Result<UnverifiedQuestion> Create(string question, List<string> tags)
            {
                if (IsQuestionTextValid(question) && IsTagsValid(tags))
                {
                    return new UnverifiedQuestion(question, tags);
                }
                else if (!IsQuestionTextValid(question))
                {
                    return new Result<UnverifiedQuestion>(new InvalidQuestionTextException(question));
                }
                else 
                {
                    return new Result<UnverifiedQuestion>(new InvalidQuestionTagsException(tags));
                }
            }

            public static bool IsQuestionTextValid(string question)
            {
                if (question.Length <= 1000)
                {
                    return true;
                }
                return false;
            }

            public static bool IsTagsValid(List<string> tags)
            {
                if (tags.Count>=1 && tags.Count<=3)
                {
                    return true;
                }
                return false;
            }
        }
        
        public class VerifiedQuestion : IQuestionText
        {
            public string Question { get; private set; }
            public List<string> Tags { get; private set; }

            internal VerifiedQuestion(string question, List<string> tags)
            {
                Question = question;
                Tags = tags;
            }
        }
    }
}
