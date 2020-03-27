using System;
using System.Collections.Generic;

namespace TeamBuilder.App.Interfaces
{
    public interface IInvoker
    {
        ICollection<IConsoleCommand> Commands { get; set; }

        void ExecuteCommand(string commandName, string[] parms);
    }
}
