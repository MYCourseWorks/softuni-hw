using FluentValidation;
using System;

namespace TeamBuilder.App.Models.Commands
{
    public static class CommandUtils
    {
        public static void ValidateAndThrowErrorCode<T>(AbstractValidator<T> validator, T elem)
        {
            var errors = validator.Validate(elem).Errors;
            if (errors.Count > 0)
            {
                string message = errors[0].ErrorMessage;
                switch (errors[0].ErrorCode)
                {
                    case "InvalidOperationException": throw new InvalidCastException(message);
                    case "ArgumentException": throw new ArgumentException(message);
                    default: throw new Exception(message);
                }
            }
        }
    }
}
