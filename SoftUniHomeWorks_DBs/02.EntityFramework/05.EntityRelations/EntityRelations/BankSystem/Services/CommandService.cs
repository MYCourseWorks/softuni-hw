using System;
using System.Collections.Generic;
using BankSystem.Data.Models;
using BankSystem.Data;
using BankSystem.Enums;
using System.Linq;

namespace BankSystem.Services
{
    public static class CommandService
    {
        private static Action<string[]> Register = (args) =>
        {
            if (args == null)
                throw new ArgumentException("Args can't be null");
            else if (args.Length != 4)
                throw new ArgumentException("Wrong number of arguments.");

            ValidatorService.Username(args[1]);
            ValidatorService.Password(args[2]);
            ValidatorService.Email(args[3]);

            var ctx = AppData.BankSystemContext;
            var user = new User()
            {
                Id = ctx.Users.Count(),
                Username = args[1],
                Password = args[2],
                Email = args[3],
                Role = RoleEnum.User
            };
            ctx.Users.Add(user);
            ctx.SaveChanges();

            Console.WriteLine($"{user.Username} was registered in the system");
        };

        private static Action<string[]> Logout = (args) =>
        {
            var ctx = AppData.BankSystemContext;
            var sessions = ctx.UserSessions;

            if (sessions.Count() == 0)
                throw new ArgumentException("Cannot log out. No user was logged in.");

            ctx.UserSessions.RemoveRange(sessions);
        };

        private static Action<string[]> Login = (args) =>
        {
            if (args == null)
                throw new ArgumentException("Args can't be null");
            else if (args.Length != 3)
                throw new ArgumentException("Wrong number of arguments.");

            string username = args[1];
            string password = args[2];

            var ctx = AppData.BankSystemContext;
            var user = ctx.Users.Where(u => u.Username == username && u.Password == password).SingleOrDefault();

            if (user == null)
                throw new ArgumentException("Incorrect username / password");

            ctx.UserSessions.Add(new UserSession() {
                User = user
            });
            ctx.SaveChanges();
        };

        private static Action<string[]> AddCount = (args) =>
        {
            if (args == null)
                throw new ArgumentException("Arguments can't be null.");
            else if (args.Length < 4)
                throw new ArgumentException("Invalid number of arguments.");

            string accountType = args[1].Trim().ToLower();
            decimal balance = decimal.Parse(args[2]);
            BankAccount account;

            switch (accountType)
            {
                case "savingsaccount":
                    int interestRate = (int)(decimal.Parse(args[3]) * 100);
                    account = new SavingAccount()
                    {
                        IBAN = RndGenService.RndString(10, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"),
                        Balance = balance,
                        InterestRate = interestRate
                    };
                    break;
                case "checkingaccount":
                    account = new CheckingAccount()
                    {
                        IBAN = RndGenService.RndString(10, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"),
                        Balance = balance,
                        Fee = decimal.Parse(args[3])
                    };
                    break;
                default:
                    throw new ArgumentException("Invalid account.");
            }

            var ctx = AppData.BankSystemContext;
            ctx.BankAccounts.Add(account);
            ctx.SaveChanges();

            Console.WriteLine($"Succesfully added account with number {account.IBAN}");
        };

        public static IDictionary<CommandType, Action<string[]>> ServiceTable = new Dictionary<CommandType, Action<string[]>>()
        {
            { CommandType.Register, Register },
            { CommandType.Logout, Logout },
            { CommandType.Login, Login },
            { CommandType.AddAccount, AddCount }
        };
    }
}
