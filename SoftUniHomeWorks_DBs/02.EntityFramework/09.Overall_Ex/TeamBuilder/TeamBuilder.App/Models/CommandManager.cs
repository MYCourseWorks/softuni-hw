using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using TeamBuilder.App.Interfaces;
using TeamBuilder.App.Models.InputModels;
using TeamBuilder.Data;

namespace TeamBuilder.App.Models
{
    public class CommandManager : IInvoker
    {
        public ICollection<IConsoleCommand> Commands { get; set; }

        public CommandManager()
        {
            this.Commands = new List<IConsoleCommand>();
            RegisterCommands();
            ConfigureMapper();
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<string, int>().ConvertUsing((str) => int.Parse(str));
                cfg.CreateMap<string, DateTime>().ConvertUsing((str) => DateTime.Parse(str));
                cfg.CreateMap<InputEvent, Event>();
            });

            Mapper.AssertConfigurationIsValid();
        }

        private void RegisterCommands()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var assemblyTypes = assembly.GetTypes();
            foreach (Type type in assemblyTypes)
            {
                if (type.GetInterface("ICommand") != null)
                {
                    var command = (IConsoleCommand)Activator.CreateInstance(type);
                    this.Commands.Add(command);
                }
            }
        }

        public void ExecuteCommand(string commandName, string[] parameters)
        {
            commandName = commandName.ToLower() + "command";
            var command = this.Commands.SingleOrDefault(c => c.GetType().Name.ToLower() == commandName);

            try
            {
                command.Execute(parameters);
                Console.WriteLine(command.SucessMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
