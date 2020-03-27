namespace _17.NaitiveSQL
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Data.Sql;
    using Database;
    using Database.Models;

    class Program
    {
        public static void PrintNamesLINQ()
        {
            SoftUniContext ctx = new SoftUniContext();
            var employees = ctx.Employees
                .ToArray()
                .Where(e =>
                {
                    foreach (var p in e.Projects)
                    {
                        if (p.StartDate.Year == 2002)
                            return true;
                    }

                    return false;
                })
                .Select(e => new { e.FirstName })
                .Distinct()
                .ToArray();
        }

        public static void PrintNamesNativeSQL()
        {
            SoftUniContext ctx = new SoftUniContext();
            var employees = ctx.Database.SqlQuery<string>(@"
                select distinct
	                E.FirstName
                from 
	                Employees as E
	                join EmployeesProjects as EP on EP.EmployeeID = E.EmployeeID
	                join Projects as P on P.ProjectID = EP.ProjectID
                where
	                DATEPART(YEAR, P.StartDate) = 2002
                ")
                 .ToArray();
        }

        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            PrintNamesLINQ();
            timer.Stop();
            Console.WriteLine("LINQ Time : " + timer.Elapsed);
            
            timer.Reset();
            timer.Start();
            PrintNamesNativeSQL();
            timer.Stop();
            Console.WriteLine("Naitive Time : " + timer.Elapsed);
        }
    }
}
