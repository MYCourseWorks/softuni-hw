namespace AutoMapping.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeContext context)
        {
            var emp1 = new Employee()
            {
                Id = 0,
                FirstName = "Steve",
                LastName = "Jobbsen",
                Salary = 100000,
                BirthDay = new DateTime(1990, 1, 1)
            };
            var emp2 = new Employee()
            {
                Id = 1,
                FirstName = "Stephen",
                LastName = "Bjorn",
                Salary = 4300.00m,
                BirthDay = new DateTime(1980, 1, 1)
            };
            var emp3 = new Employee()
            {
                Id = 2,
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400.00m,
                BirthDay = new DateTime(1960, 1, 1)
            };
            var emp4 = new Employee()
            {
                Id = 3,
                FirstName = "Carl",
                LastName = "Kormac",
                Salary = 20000,
                BirthDay = new DateTime(1950, 1, 1)
            };
            var emp5 = new Employee()
            {
                Id = 4,
                FirstName = "Jurgen",
                LastName = "Straus",
                Salary = 1000.45m,
                BirthDay = new DateTime(1996, 1, 1)
            };
            var emp6 = new Employee()
            {
                Id = 5,
                FirstName = "Moni",
                LastName = "Kozinac",
                Salary = 2030.99m,
                BirthDay = new DateTime(1983, 1, 1)

            };
            var emp7 = new Employee()
            {
                Id = 6,
                FirstName = "Kopp",
                LastName = "Spidok",
                Salary = 2000.21m,
                BirthDay = new DateTime(1964, 1, 1)
            };

            emp1.Employees.Add(emp2);
            emp2.Manager = emp1;
            emp1.Employees.Add(emp3);
            emp3.Manager = emp1;
            emp4.Employees.Add(emp5);
            emp5.Manager = emp4;
            emp4.Employees.Add(emp6);
            emp6.Manager = emp4;
            emp4.Employees.Add(emp7);
            emp7.Manager = emp4;
            List<Employee> emps = new List<Employee>() { emp1, emp2, emp3, emp4, emp5, emp6, emp7 };

            context.Employees.AddRange(emps);
        }
    }
}
