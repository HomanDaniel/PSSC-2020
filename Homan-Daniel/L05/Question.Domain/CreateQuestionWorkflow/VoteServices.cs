using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateQuestionWorkflow.Vote;

namespace Question.Domain.CreateQuestionWorkflow
{
        public class VoteService
        {
            public Result<VerifiedVote> VerifyVote(UnverifiedNumberVote vote)
            {
                return new VerifiedVote(vote.Vote);
            }
        }
    
}

