using System;
using System.Text.RegularExpressions;

namespace BankSystem.Services
{
    public static class ValidatorService
    {
        private static readonly string EmailRegex = @"[^@\s]+@[^@\W+]+(\.[^@\s]+)+";

        public static void Username(string input)
        {
            if (string.IsNullOrEmpty(input) || 
                input.Length < 3 ||
                !char.IsLetter(input[0]) || 
                Regex.IsMatch(input, @"\W+"))
            {
                throw new ArgumentException("Incorrect username");
            }
        }

        public static void Password(string input)
        {
            if (string.IsNullOrEmpty(input) || 
                input.Length < 6 || 
                !Regex.IsMatch(input, @"[A-Z]") ||
                !Regex.IsMatch(input, @"[a-z]") || 
                !Regex.IsMatch(input, @"[0-9]"))
            {
                throw new ArgumentException("Incorrect password");
            }
        }

        public static void Email(string input)
        {
            if (!Regex.IsMatch(input, EmailRegex))
                throw new ArgumentException("Invalid email");
        }
    }
}
