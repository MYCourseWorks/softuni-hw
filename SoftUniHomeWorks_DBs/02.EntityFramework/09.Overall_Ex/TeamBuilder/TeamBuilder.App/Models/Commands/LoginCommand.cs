using System;
using System.Linq;
using TeamBuilder.App.Constants;
using TeamBuilder.App.Interfaces;
using TeamBuilder.Data;
using TeamBuilder.Data.Client;

namespace TeamBuilder.App.Models.Commands
{
    public class LoginCommand : IConsoleCommand
    {
        public string SucessMessage { get; private set; }

        public void Execute(string[] parameters)
        {
            if (LogedUser.User != null)
                throw new InvalidOperationException(ConsoleMessages.LogOutFirst);

            string username = parameters[1];
            string password = parameters[2];

            try
            {
                var user = GetUser(username, password);
                if (user == null)
                    throw new ArgumentException(ConsoleMessages.InvalidUsernameOrPassword);

                LogedUser.Login(user);
                this.SucessMessage = $"User {username} sucessfully logged in!";
            }
            catch (Exception)
            {
                throw new ArgumentException(ConsoleMessages.InvalidUsernameOrPassword);
            }
        }

        private User GetUser(string username, string password)
        {
            var ctx = new TeamBuilderContext();
            var user = ctx.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user;
        }
    }
}
