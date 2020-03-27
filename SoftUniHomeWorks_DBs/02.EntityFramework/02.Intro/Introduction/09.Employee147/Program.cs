namespace _09.Employee147
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
            var employee = ctx.Employees
                .Where(e => e.EmployeeID == 147)
                .FirstOrDefault();

            if (employee == null)
                throw new ArgumentNullException("No employee 147 !!");

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} {1} {2}{3}", employee.FirstName, 
                employee.LastName, employee.JobTitle, Environment.NewLine);

            var projects = employee.Projects.OrderBy(p => p.Name);

            foreach (var p in projects)
            {
                sb.AppendFormat("{0}{1}", p.Name, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}