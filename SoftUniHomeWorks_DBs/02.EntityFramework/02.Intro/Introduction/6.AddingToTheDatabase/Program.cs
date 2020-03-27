namespace _6.AddingToTheDatabase
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext ctx = new SoftUniContext();

            var address = new Address()
            {
                TownID = 4,
                AddressText = "Vitoshka 15"
            };

            var nakov = ctx.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();

            if (nakov == null)
            {
                throw new ArgumentException("No Nakov in SoftUni. The World has Ended !");
            }

            ctx.Addresses.Add(address);
            nakov.Address = address;
            ctx.SaveChanges();

            var employees = ctx.Employees
               .Join(
                    ctx.Addresses,
                    e => e.AddressID,
                    a => a.AddressID,
                    (e, a) => new { a.AddressID, a.AddressText, e.FirstName }
               )
               .OrderByDescending(x => x.AddressID)
               .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0}{1}", e.AddressText, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
