namespace _12.SalaryIncrease
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
            var departmentsToPromote = new [] {"Engineering", "Tool Design", "Marketing", "Information Services"};

            var employees = ctx.Employees
                .Where(e => departmentsToPromote.Contains(e.Department.Name))
                .ToArray();

            // Increase salaries :
            //Array.ForEach(employees, e => e.Salary = e.Salary + e.Salary * 0.12m);
            //ctx.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0} {1} (${2:F6}){3}", e.FirstName, e.LastName, e.Salary, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
