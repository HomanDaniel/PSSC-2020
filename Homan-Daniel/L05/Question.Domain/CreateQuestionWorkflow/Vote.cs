using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt.Common;
namespace Question.Domain.CreateQuestionWorkflow
{
    [AsChoice]
    public static partial class Vote
    {
        public interface IVote { }
        public class UnverifiedNumberVote : IVote
        {
            public int  Vote { get; private set; }
            private UnverifiedNumberVote(int vote)
            {
                Vote = vote;
            }

            public static Result<UnverifiedNumberVote> Create(int vote)
            {
                if (IsVoteValid(vote))
                {
                    return new UnverifiedNumberVote(vote);
                }
                else
                {
                    return new Result<UnverifiedNumberVote>(new InvalidVoteException(vote));
                }
            }
            private static bool IsVoteValid(int vote)
            {
                 
                if (Vote == vote)
                {
                    return false;
                }
                return true;
            }
        }
        public class VerifiedVote : IVote
        {
            public int Vote { get; private set; }
            internal VerifiedVote(int vote)
            {
                Vote = vote;
            }
        }
    }
}
