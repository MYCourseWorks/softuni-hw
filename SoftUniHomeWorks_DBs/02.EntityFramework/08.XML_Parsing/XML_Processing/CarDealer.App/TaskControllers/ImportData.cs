using CarDealer.Data;
using CarDealer.Models;
using Global;
using System;
using System.Linq;

namespace CarDealer.App.TaskControllers
{
    public class ImportData : Task
    {
        private static Random random = new Random();

        public ImportData() : base(1) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            if (ctx.Database.Exists())
                ctx.Database.Delete();
            ctx.Database.Create();

            ParseSuppliers(ctx);
            ParseParts(ctx);
            ParseCars(ctx);
            ParseCustomers(ctx);
            ParseSales(ctx);
        }

        private void ParseSuppliers(CarDealerContext ctx)
        {
            var suppliers = FileOperations.ParseSuppliers(Constants.SupplierXml);

            int i = 0;
            foreach (var s in suppliers)
            {
                s.Id = i++;
                ctx.Suppliers.Add(s);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not parse suppliers.");
        }

        private void ParseParts(CarDealerContext ctx)
        {
            var parts = FileOperations.ParseParts(Constants.PartsXml);
            var suppliers = ctx.Suppliers.ToArray();

            int i = 0;
            foreach (var p in parts)
            {
                p.Id = i++;
                p.Supplier = suppliers[random.Next(0, suppliers.Length - 1)];
                ctx.Parts.Add(p);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not parse suppliers.");
        }

        private void ParseCars(CarDealerContext ctx)
        {
            var cars = FileOperations.ParseCars(Constants.CarXml);
            var parts = ctx.Parts.ToArray();

            int i = 0;
            foreach (var c in cars)
            {
                c.Id = i++;

                int rndCarCount = random.Next(10, 20);
                for (int j = 0; j < rndCarCount; j++)
                {
                    var rndPart = parts[random.Next(0, parts.Length - 1)];
                    c.Parts.Add(rndPart);
                }

                ctx.Cars.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not parse cars.");
        }

        private void ParseCustomers(CarDealerContext ctx)
        {
            var customers = FileOperations.ParseCustomers(Constants.CustomerXml);

            int i = 0;
            foreach (var c in customers)
            {
                c.Id = i++;
                ctx.Customers.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not parse customers.");
        }

        private void ParseSales(CarDealerContext ctx)
        {
            int saleCount = 500;
            var cars = ctx.Cars.ToArray();
            var customers = ctx.Customers.ToArray();
            decimal[] discountRanges = { 0m, 0.5m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };

            for (int i = 0; i < saleCount; i++)
            {
                var s = new Sale();
                s.Id = i;
                s.Car = cars[random.Next(0, cars.Length - 1)];
                s.Customer = customers[random.Next(0, customers.Length - 1)];
                s.Discount = discountRanges[random.Next(0, discountRanges.Length - 1)];

                ctx.Sales.Add(s);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not parse sales.");
        }
    }
}
