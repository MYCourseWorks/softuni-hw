namespace _08.AddressByTownName
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
            var addresses = ctx.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendFormat("{0}, {1} - {2} employees{3}", a.AddressText, a.Town.Name, a.Employees.Count, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
