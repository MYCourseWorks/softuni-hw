namespace _16.RemoveTowns
{
    using System;
    using System.Linq;
    using Database;
    using Database.Models;

    class Program
    {
        static void Main(string[] args)
        {
            String townName = Console.ReadLine().Trim();
            SoftUniContext ctx = new SoftUniContext();
            var town = ctx.Towns
                .Where(t => t.Name == townName)
                .FirstOrDefault();

            if (town == null)
                throw new ArgumentNullException("No such town");

            var addressesToDelete = town.Addresses.ToArray();
            int count = 0;

            foreach (var a in addressesToDelete)
            {
                a.Employees.Clear();
                ctx.Addresses.Remove(a);
                count++;
            }

            ctx.SaveChanges();

            if (count <= 1)
                Console.WriteLine("{0} addresse in {1} was deleted", count, townName);
            else
                Console.WriteLine("{0} addresses in {1} were deleted", count, townName);

        }
    }
}
