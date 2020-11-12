using CSharp.Choices;
using Question.Domain.CreateQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionPosted: ICreateQuestionResult
        {
            public QuestionPosted(string title, List<string> tags, int voteCount, IReadOnlyCollection<VoteEnum> allVotes)
            {
                Title = title;
                Tags = tags;
                VoteCount = voteCount;
                AllVotes = allVotes;

            }

            public string Title { get; private set; }
            public List<string> Tags { get; private set; }
            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }
        }

        public class QuestionNotPosted: ICreateQuestionResult
        {
            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; set; }
        }

        public class QuestionValidationFailed: ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
