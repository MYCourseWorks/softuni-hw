namespace _5.EmployeesFromSeattle
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
                .Where(e => e.Department.Name == "Research and Development")
                .Join(ctx.Departments, 
                    e => e.DepartmentID, 
                    d => d.DepartmentID, 
                    (e, d) => new {e.FirstName, e.LastName, e.Salary, DepartmentName = d.Name})
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0} {1} from {2} - ${3:F2}{4}", e.FirstName, e.LastName,
                    e.DepartmentName, e.Salary, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
