using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSON_Processing.Enums;
using CarDealer.Data;
using CarDealer.Data.Model;
using JSON_Processing.Global;

namespace JSON_Processing.TaskControllers
{
    class CarDealerImportData : Task
    {
        private static Random random = new Random();
        private CarDealerContext context;

        public CarDealerImportData() : base(ContextType.CarDealerContext, 6) { }

        public override void Run<T>(T context)
        {
            this.context = context as CarDealerContext;
            if (this.context.Database.Exists())
                this.context.Database.Delete();
            this.context.Database.Create();

            ParseSuppliers();
            ParseParts();
            ParseCars();
            ParseCustomers();
            ParseSales();
        }

        private void ParseSuppliers()
        {
            var suppliers = FileOperations.DeserializeJson<Supplier>(Constants.SupplierJson);

            int i = 0;
            foreach (var s in suppliers)
            {
                s.Id = i++;
                this.context.Supliers.Add(s);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add suppliers");
        }

        private void ParseParts()
        {
            var parts = FileOperations.DeserializeJson<Part>(Constants.PartJson);
            var suppliers = this.context.Supliers.ToArray();

            int i = 0;
            foreach (var p in parts)
            {
                p.Id = i++;
                p.Supplier = suppliers[random.Next(0, suppliers.Length - 1)];
                this.context.Parts.Add(p);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add parts");
        }

        private void ParseCars()
        {
            var cars = FileOperations.DeserializeJson<Car>(Constants.CarJson);
            var parts = this.context.Parts.ToArray();

            int i = 0;
            foreach (var c in cars)
            {
                c.Id = i++;

                int rndNumberOfParts = random.Next(10, 20);
                for (int j = 0; j < rndNumberOfParts; j++)
                {
                    var rndPart = parts[random.Next(0, parts.Length - 1)];
                    if (!c.Parts.Contains(rndPart))
                        c.Parts.Add(rndPart);
                    else
                        j--;
                }

                this.context.Cars.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add cars");
        }

        private void ParseCustomers()
        {
            var customers = FileOperations.DeserializeJson<Customer>(Constants.CustomerJson);

            int i = 0;
            foreach (var c in customers)
            {
                c.Id = i++;
                this.context.Customers.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add customers");
        }

        private void ParseSales()
        {
            var sales = new Sale[random.Next(50, 200)];
            var cars = this.context.Cars.ToArray();
            var customers = this.context.Customers.ToArray();
            decimal[] discountRanges = { 0m, 0.05m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };

            for (int i = 0; i < sales.Length; i++)
            {
                sales[i] = new Sale();
                var s = sales[i];
                s.Id = i++;
                s.Car = cars[random.Next(0, cars.Length - 1)];
                s.Customer = customers[random.Next(0, customers.Length - 1)];
                s.Discount = discountRanges[random.Next(0, discountRanges.Length - 1)];
                this.context.Sales.Add(s);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add sales");
        }
    }
}
