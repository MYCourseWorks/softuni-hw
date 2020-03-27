using BankSystem.Controllers;
using BankSystem.Data;
using System;

namespace BankSystem.Models
{
    public class MainMenu
    {
        public void Run()
        {
            string line;
            ComandController cc = new ComandController();

            BankSystemContext ctx = new BankSystemContext();
            ctx.Database.Delete();
            ctx.Database.Create();

            Console.WriteLine("Debug done.");
            while (string.IsNullOrEmpty(line = Console.ReadLine()) == false)
            {
                cc.Handle(line);
            }
        }
    }
}
