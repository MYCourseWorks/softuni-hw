using BankSystem.Enums;
using BankSystem.Services;

namespace BankSystem.Models
{
    public class Command
    {
        public Command(CommandType type)
        {
            this.Type = type;
        }

        public CommandType Type { get; set; }

        public void Execute(string[] args)
        {
            CommandService.ServiceTable[this.Type].Invoke(args);
        }
    }
}
