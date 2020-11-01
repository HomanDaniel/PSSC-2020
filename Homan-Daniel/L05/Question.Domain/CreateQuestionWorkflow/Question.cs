using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt.Common;

namespace Question.Domain.CreateQuestionWorkflow
{
   

    [AsChoice]
    public static partial class Question
    {

        public interface IQuestion { }

        public class UnverifiedQuestion : IQuestion
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }

            private UnverifiedQuestion(string question, List<string> tag)
            {
               Question = question;
               Tag = tag;
            }

            public static Result<UnverifiedQuestion> Create(string question,List<string>tag)
            {
                if (IsQuestionValid(question))
                {
                    if (IsTagValid(tag))
                    {
                        return new UnverifiedQuestion(question,tag);
                    }

                    else
                    {
                        return new Result<UnverifiedQuestion>(new InvalidQuestionException(question, tag));
                    }
                
                }
                else
                {
                    return new Result<UnverifiedQuestion>(new InvalidQuestionException(question));
                }
            }
            private static bool IsQuestionValid(string question)
            {
                if (question.Length < 1000)
                {
                    return true;
                }
                return false;
            }
            private static bool IsTagValid(List<string> tag)
            {
                if (tag.Count >= 1 && tag.Count <= 3)
                {
                    return true;
                }
                return false;
            }

        }

        public class VerifiedQuestion : IQuestion
        {
            public string Question { get; private set; }
            public List<string> Tag { get; private set; }

            internal VerifiedQuestion(string question, List<string> tag)
            {
                Question = question;
                Tag = tag;
            }
        }
    }
}
