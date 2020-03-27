using System;
using TeamBuilder.App.Extensions;
using TeamBuilder.App.Constants;
using TeamBuilder.App.Interfaces;
using TeamBuilder.Data;
using TeamBuilder.Data.Client;
using TeamBuilder.Data.Enums;
using TeamBuilder.App.Models.Validators;

namespace TeamBuilder.App.Models.Commands
{
    public class RegisterUserCommand : IConsoleCommand
    {
        public string SucessMessage { get; private set; }

        public void Execute(string[] parameters)
        {
            if (LogedUser.User != null)
                throw new InvalidOperationException(ConsoleMessages.LogOutFirst);
            if (parameters == null)
                throw new InvalidOperationException(ConsoleMessages.NoParametersSet);
            if (parameters.Length != 8)
                throw new InvalidOperationException(ConsoleMessages.InvalidArgumentCount);

            string username = parameters[1];
            string password = parameters[2];
            string repeatPass = parameters[3];
            string firstName = parameters[4];
            string lastName = parameters[5];
            int? age = parameters[6].IsNumber() ? (int?)int.Parse(parameters[6]) : null;
            Gender? gender = parameters[7].IsGender() ? (Gender?)Enum.Parse(typeof(Gender), parameters[7]) : null;

            if (password != repeatPass)
                throw new InvalidOperationException(ConsoleMessages.PassowrdsDoNotMatch);

            var u = new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            };

            using (var ctx = new TeamBuilderContext())
            {
                var validator = new UserValidator(ctx);
                CommandUtils.ValidateAndThrowErrorCode(validator, u);
                RegisterUser(ctx, u);
            }

            this.SucessMessage = $"User {username} was registered successfully!";
        }

        private void RegisterUser(TeamBuilderContext ctx, User u)
        {
            ctx.Users.Add(u);
            ctx.SaveChanges();
        }
    }
}
