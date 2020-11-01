using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Security;
using LanguageExt;
using LanguageExt.Common;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;
using static Question.Domain.CreateQuestionWorkflow.Question;
using Question.Domain.CreateQuestionWorkflow;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string>()
            {
                "C++",
                "Java",            
            };

            var result = UnverifiedQuestion.Create("Cum creez un constructor?", tags);

            result.Match(
                Succ: question =>
                {
                    VoteQuestion(question);
                    Console.WriteLine("Poti vota");
                    return Unit.Default;
                },
                Fail: ex =>
                {
                    Console.WriteLine($"Intrebarea nu a fost postata. Motiv: {ex.Message}");
                    return Unit.Default;
                }
                );
            Console.ReadLine();
        }
        private static void VoteQuestion(UnverifiedQuestion question)
        {
            var postQuestionResult = new PostQuestionService().VerifiedQuestion(question);
            postQuestionResult.Match(
                    VoteQuestion =>
                    {
                        new VoteService().VerifyVote(VoteQuestion);
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("You can't vote this question!");
                        return Unit.Default;
                    }
                );

        }
    }
}