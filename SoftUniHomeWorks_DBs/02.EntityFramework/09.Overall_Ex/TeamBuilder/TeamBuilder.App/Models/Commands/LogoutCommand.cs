using System;
using TeamBuilder.App.Constants;
using TeamBuilder.App.Interfaces;

namespace TeamBuilder.App.Models.Commands
{
    public class LogoutCommand : IConsoleCommand
    {
        public string SucessMessage { get; private set; }

        public void Execute(string[] parameters)
        {
            if (parameters.Length != 1)
                throw new InvalidOperationException(ConsoleMessages.InvalidArgumentCount);
            if (LogedUser.User == null)
                throw new InvalidOperationException(ConsoleMessages.LogInFirst);

            this.SucessMessage = $"User {LogedUser.User.Username} successfully logged out!";
            LogedUser.Logout();
        }
    }
}
