using AutoMapper;
using System;
using TeamBuilder.App.Constants;
using TeamBuilder.App.Extensions;
using TeamBuilder.App.Interfaces;
using TeamBuilder.App.Models.InputModels;
using TeamBuilder.App.Models.Validators;
using TeamBuilder.Data;
using TeamBuilder.Data.Client;

namespace TeamBuilder.App.Models.Commands
{
    public class CreateEventCommand : IConsoleCommand
    {
        public string SucessMessage { get; private set; }

        public void Execute(string[] parameters)
        {
            if (LogedUser.User == null)
                throw new InvalidOperationException(ConsoleMessages.LogInFirst);
            if (parameters.Length != 5)
                throw new InvalidOperationException(ConsoleMessages.InvalidArgumentCount);

            string name = parameters[1];
            string description = parameters[2];
            DateTime? startDate = parameters[3].CanConvertTo(typeof(DateTime)) ? (DateTime?)DateTime.Parse(parameters[3]) : null;
            DateTime? endDate = parameters[4].CanConvertTo(typeof(DateTime)) ? (DateTime?)DateTime.Parse(parameters[4]) : null;

            var inputEvent = new InputEvent()
            {
                Name = parameters[1],
                Description = parameters[2],
                StartDate = parameters[3],
                EndDate = parameters[4]
            };

            using (var ctx = new TeamBuilderContext())
            {
                var validator = new EventValidator();
                CommandUtils.ValidateAndThrowErrorCode(validator, inputEvent);
                var e = new Event();
                Mapper.Map(inputEvent, e);
                CreateEvent(ctx, e);
            }
            
            this.SucessMessage = $"Event {name} was created successfully!";
        }

        public void CreateEvent(TeamBuilderContext ctx, Event e)
        {
            ctx.Events.Add(e);
            ctx.SaveChanges();
        }
    }
}
