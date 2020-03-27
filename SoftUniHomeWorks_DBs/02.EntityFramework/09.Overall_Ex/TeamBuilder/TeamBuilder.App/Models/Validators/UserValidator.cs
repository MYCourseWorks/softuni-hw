using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using FluentValidation.Results;
using System.Data.Entity;
using TeamBuilder.Data.Client;
using TeamBuilder.App.Models.InputModels;

namespace TeamBuilder.App.Models.Validators
{
    public class UserValidator : AbstractValidator<InputUser>
    {
        public UserValidator(TeamBuilderContext context)
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(u => u.Username)
                .NotNull()
                .Length(3, 25)
                .WithMessage(u => $"Username {u.Username} not valid!")
                .WithErrorCode("ArgumentException");

            RuleFor(u => u.Username)
                .Must(u => NotExistInDb(u, context))
                .WithMessage(u => $"Username {u.Username} is already taken!")
                .WithErrorCode("InvalidOperationException");

            RuleFor(u => u.FirstName)
                .NotNull()
                .Length(0, 25)
                .WithMessage(u => $"FirstName {u.FirstName} not valid!")
                .WithErrorCode("ArgumentException");

            RuleFor(u => u.LastName)
                .NotNull()
                .Length(0, 25)
                .WithMessage(u => $"LastName {u.LastName} not valid!")
                .WithErrorCode("ArgumentException"); ;

            RuleFor(u => u.Password)
                .NotNull()
                .Length(6, 30)
                .WithMessage(u => $"Password {u.Password} not valid!")
                .WithErrorCode("ArgumentException");

            RuleFor(u => u.Gender)
                .NotNull()
                .WithMessage("Gender should be either \"Male\" or \"Female\"!")
                .WithErrorCode("ArgumentException");

            RuleFor(u => u.Age)
                .NotNull()
                .Must(age => age > 0)
                .WithMessage(u => $"Age {u.Age} is not valid")
                .WithErrorCode("ArgumentException"); ;
        }

        private bool NotExistInDb(string name, TeamBuilderContext context)
        {
            return context.Users.Where(x => x.Username == name).FirstOrDefault() == null;
        }
    }
}
