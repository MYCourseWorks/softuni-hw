using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Constants;
using TeamBuilder.App.Interfaces;
using TeamBuilder.Data.Client;

namespace TeamBuilder.App.Models.Commands
{
    public class DeleteUserCommand : IConsoleCommand
    {
        public string SucessMessage { get; private set; }

        public void Execute(string[] parameters)
        {
            if (parameters.Length != 1)
                throw new InvalidOperationException(ConsoleMessages.InvalidArgumentCount);
            if (LogedUser.User == null)
                throw new InvalidOperationException(ConsoleMessages.LogInFirst);

            TeamBuilderContext ctx = new TeamBuilderContext();
            var user = ctx.Users.Where(u => u.Id == LogedUser.User.Id).FirstOrDefault();
            ctx.Users.Remove(user);
            ctx.SaveChanges();
            SucessMessage = $"User {user.Username} was deleted successfully!";
            LogedUser.Logout();
        }
    }
}
