namespace _10.DepartmentsWithMoreThan5
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
            var departments = ctx.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var d in departments)
            {
                var managerName = d.Manager.FirstName;

                sb.AppendFormat("{0} {1}{2}", d.Name, managerName, Environment.NewLine);

                foreach (var e in d.Employees)
                {
                    sb.AppendFormat("{0} {1} {2}{3}", e.FirstName, e.LastName, e.JobTitle, Environment.NewLine);
                }
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
