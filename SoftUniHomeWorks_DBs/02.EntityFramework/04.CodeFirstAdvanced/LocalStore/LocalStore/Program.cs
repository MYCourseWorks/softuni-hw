using LocalStore.Models;
using System.Linq;

namespace LocalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalStoreContext ctx = new LocalStoreContext();
            var customers = ctx.Customers.ToArray();
            var locations = ctx.StoreLocations.ToArray();
            var products = ctx.Products.ToArray();
            var sales = ctx.Sales.ToList();

            ctx.Sales.Add(new Sale());
            ctx.SaveChanges();

            System.Console.WriteLine();
        }
    }
}
