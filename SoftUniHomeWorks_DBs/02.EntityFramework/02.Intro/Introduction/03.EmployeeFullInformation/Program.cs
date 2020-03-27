namespace _03.EmployeeFullInformation
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext ctx = new SoftUniContext();
            Employee[] employees = ctx.Employees.Select(x => x).ToArray();
            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendFormat("{0} {1} {2} {3} {4} {5}", e.FirstName, e.LastName, 
                    e.MiddleName, e.JobTitle, e.Salary, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
