namespace _04.SalaryOver50000
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
            Employee[] employees = ctx.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => x)
                .ToArray();
            
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0} {1}", e.FirstName, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
