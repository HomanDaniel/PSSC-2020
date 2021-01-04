using Access.Primitives.IO;
using EarlyPay.Primitives.ValidationAttributes;
using LanguageExt;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.ConfirmationOp
{
    public struct ConfirmationCmd
    {
       

        [OptionValidator(typeof(RequiredAttribute))]
        public Option<User> QuestionUser { get; }
        public ConfirmationCmd(Option<User> questionUser)
        {
            QuestionUser = questionUser;
        }

        public ConfirmationCmd(Option<object> user) : this()
        {
            this.QuestionUser = (Option<User>)user;
        }
    }
    public enum ConfirmationCmdInput
    {
        Valid,
        UserIsNone
    }

    public class ConfirmationCmdInputGen : InputGenerator<ConfirmationCmd, ConfirmationCmdInput>
    {
        public ConfirmationCmdInputGen()
        {
            mappings.Add(ConfirmationCmdInput.Valid, () =>
             new ConfirmationCmd(
                 Option<User>.Some(new User()
                 {
                     DisplayName = Guid.NewGuid().ToString(),
                     Email = $"{Guid.NewGuid()}@mail.com"
                 }))
            );

            mappings.Add(ConfirmationCmdInput.UserIsNone, () =>
                new ConfirmationCmd(
                    Option<User>.None
                    )
            );
        }
    }

}
