namespace _15.DeleteProductById
{
    using System;
    using System.Text;
    using System.Linq;
    using System.IO;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext ctx = new SoftUniContext();
            var projectToDelete = ctx.Projects
                .Where(p => p.ProjectID == 2)
                .FirstOrDefault();

            if (projectToDelete == null)
                throw new ArgumentNullException("No project with Id = 2");

            projectToDelete.Employees.Clear();
            ctx.Projects.Remove(projectToDelete);
            ctx.SaveChanges();

            var projects = ctx.Projects.Take(10).ToArray();
            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendFormat("{0}{1}", p.Name, Environment.NewLine);
            }

            File.WriteAllText("../../out.txt", sb.ToString());
        }
    }
}
