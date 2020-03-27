using FluentValidation;
using System;
using TeamBuilder.App.Extensions;
using TeamBuilder.App.Models.InputModels;
using TeamBuilder.Data;

namespace TeamBuilder.App.Models.Validators
{
    public class EventValidator : AbstractValidator<InputEvent>
    {
        public EventValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .Length(0, 25)
                .WithErrorCode("ArgumentException");

            RuleFor(e => e.Description)
                .Length(0, 250)
                .WithErrorCode("ArgumentException");

            RuleFor(e => e.StartDate)
                .Must(d => d.CanConvertTo(typeof(DateTime)))
                .WithMessage("Please insert the dates in format:[dd/MM/yyyy HH:mm]!")
                .WithErrorCode("ArgumentException");

            RuleFor(e => e.EndDate)
                .Must(d => d.CanConvertTo(typeof(DateTime)))
                .WithMessage("Please insert the dates in format:[dd/MM/yyyy HH:mm]!")
                .WithErrorCode("ArgumentException");

            RuleFor(e => e)
                .Must(e =>
                {
                    var start = DateTime.Parse(e.StartDate);
                    var end = DateTime.Parse(e.EndDate);
                    return start < end;
                 })
                .WithMessage("Start date is after end date")
                .WithErrorCode("ArgumentException");
        }
    }
}
