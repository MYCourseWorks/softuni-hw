using System;

namespace Gringotts
{
    class Program
    {
        static void Main(string[] args)
        {
            GringottsContext ctx = new GringottsContext();
            ctx.Database.Delete();
            ctx.Database.Create();

            var wizzard = new WizzardDeposits()
            {
                FirstName = "Bate",
                LastName = "Pesho",
                MagicWandSize = int.MaxValue - 10000,
                Age = 20
            };

            var tran = ctx.Database.BeginTransaction();
                
            try
            {
                ctx.WizzardDeposits.Add(wizzard);
                ctx.SaveChanges();
                tran.Commit();
                System.Console.WriteLine("Bate Pesho added.");
            }
            catch (System.Exception)
            {
                tran.Rollback();
                System.Console.WriteLine("Neshto grumna.");
            }
        }
    }
}
