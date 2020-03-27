using System;
using System.Collections.Generic;
using TeamBuilder.App.Models;

namespace TeamBuilder.App
{
    public class ConsoleClient
    {
        public void Run()
        {
            CommandManager cm = new CommandManager();
            List<string> inputBatch = new List<string>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (line.ToUpper() == "EXIT")
                    break;
                else
                    inputBatch.Add(line);
            }

            foreach (var c in inputBatch)
            {
                var tokens = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var commandName = tokens[0];
                cm.ExecuteCommand(commandName, tokens);
            }
        }
    }
}
