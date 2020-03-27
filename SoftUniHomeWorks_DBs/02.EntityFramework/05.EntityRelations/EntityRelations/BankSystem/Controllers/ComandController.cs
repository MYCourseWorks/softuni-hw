using BankSystem.Enums;
using BankSystem.Models;
using System;

namespace BankSystem.Controllers
{
    public class ComandController
    {
        public void Handle(string rawInput)
        {
            string[] split = rawInput.Split();
            string commandName = split[0].ToLower();

            Command command;

            try
            {
                switch (commandName)
                {
                    case "register":
                        command = new Command(CommandType.Register);
                        command.Execute(split);
                        break;
                    case "login":
                        command = new Command(CommandType.Login);
                        command.Execute(split);
                        break;
                    case "logout":
                        command = new Command(CommandType.Logout);
                        command.Execute(split);
                        break;
                    case "add":
                        command = new Command(CommandType.AddAccount);
                        command.Execute(split);
                        break;
                    case "listaccounts":
                        command = new Command(CommandType.ListAccounts);
                        break;
                    case "deposit":
                        command = new Command(CommandType.Deposit);
                        break;
                    case "withdraw":
                        command = new Command(CommandType.Withdraw);
                        break;
                    case "depositfee":
                        command = new Command(CommandType.DeductFee);
                        break;
                    case "addinterest":
                        command = new Command(CommandType.AddInterest);
                        break;
                    default:
                        Console.WriteLine("Invalid Command.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
