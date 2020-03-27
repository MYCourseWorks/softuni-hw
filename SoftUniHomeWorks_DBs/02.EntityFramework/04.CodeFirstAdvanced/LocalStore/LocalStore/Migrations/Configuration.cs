namespace LocalStore.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LocalStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LocalStore.LocalStoreContext";
        }

        protected override void Seed(LocalStoreContext context)
        {
            var product1 = new Product()
            {
                Name = "prouct1",
                Price = 100,
                Quantity = 5
            };
            var product2 = new Product()
            {
                Name = "prouct2",
                Price = 100,
                Quantity = 5
            };
            var customer1 = new Customer()
            {
                Name = "customer1",
                Email = "customer1@gmail.com",
                CrediCardNumber = "378282246310005"
            };
            var customer2 = new Customer()
            {
                Name = "customer2",
                Email = "customer2@mail.bg.com",
                CrediCardNumber = "4111111111111111"
            };
            var location1 = new StoreLocation()
            {
                LocationName = "Sofia"
            };
            var location2 = new StoreLocation()
            {
                LocationName = "Varna"
            };
            var location3 = new StoreLocation()
            {
                LocationName = "Burgas"
            };

            var sale1 = new Sale()
            {
                Id = 0,
                Customer = customer1,
                Product = product1,
                StoreLocation = location1,
                Date = DateTime.Now
            };
            var sale2 = new Sale()
            {
                Id = 1,
                Customer = customer2,
                Product = product2,
                StoreLocation = location2
            };

            context.Products.AddOrUpdate(p => p.Name, product1);
            context.Products.AddOrUpdate(p => p.Name, product2);
            context.Customers.AddOrUpdate(c => c.Name, customer1);
            context.Customers.AddOrUpdate(c => c.Name, customer2);
            context.StoreLocations.AddOrUpdate(l => l.LocationName, location1);
            context.StoreLocations.AddOrUpdate(l => l.LocationName, location2);
            context.StoreLocations.AddOrUpdate(l => l.LocationName, location3);
            context.Sales.AddOrUpdate(s => s.Id, sale1);
            context.Sales.AddOrUpdate(s => s.Id, sale2);
            base.Seed(context);
        }
    }
}
