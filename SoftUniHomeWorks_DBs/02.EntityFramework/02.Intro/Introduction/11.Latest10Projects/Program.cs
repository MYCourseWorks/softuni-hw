namespace _11.Latest10Projects
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Globalization;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en", true);

            SoftUniContext ctx = new SoftUniContext();
            var projects = ctx.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToArray()
                .OrderBy(p => p.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendFormat("{0} {1} {2} {3}{4}", p.Name, p.Description, 
                    p.StartDate, p.EndDate, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
