namespace _14.FirstLetter
{
    using System;
    using System.Text;
    using System.Linq;
    using System.IO;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            GringottsContext ctx = new GringottsContext();
            var letters = ctx.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .ToArray()
                .Select(w => w.FirstName[0])
                .Distinct()
                .OrderBy(w => w)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();

            foreach (var l in letters)
            {
                sb.Append(l);
                sb.AppendLine();
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
