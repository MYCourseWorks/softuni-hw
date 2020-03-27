namespace _07.TimePeriod
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Globalization;
    using System.Threading;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en", true);

            SoftUniContext ctx = new SoftUniContext();
            var employees = ctx.Employees
                .Where(e => e.Projects.Any(p => 2001 <= p.StartDate.Year && p.StartDate.Year <= 2003))
                .Take(30)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                var projects = e.Projects.ToArray();
                var managerName = e.Manager.FirstName;

                sb.AppendFormat("{0} {1} {2}{3}", e.FirstName, e.LastName, 
                    managerName, Environment.NewLine);

                foreach (var p in projects)
                {
                    sb.AppendFormat("--{0} {1:M/d/yyyy h:mm:ss tt} {2:M/d/yyyy h:mm:ss tt}{3}",
                        p.Name, p.StartDate, p.EndDate, Environment.NewLine);
                }
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
