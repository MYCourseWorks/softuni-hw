namespace _13.EmployeesByFirstName
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
            var employees = ctx.Employees
                .Where(e => e.FirstName.ToUpper().StartsWith("SA"))
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0} {1} - {2} - (${3:F4}){4}", e.FirstName, e.LastName, 
                    e.JobTitle, e.Salary, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
