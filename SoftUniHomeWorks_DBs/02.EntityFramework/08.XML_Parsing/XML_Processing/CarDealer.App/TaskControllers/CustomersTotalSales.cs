using CarDealer.Data;
using Global;
using System.Linq;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class CustomersTotalSales : Task
    {
        public CustomersTotalSales() : base(6) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var customers = ctx.Customers
                .Join(
                    ctx.Sales,
                    c => c.Id,
                    s => s.Customer.Id,
                    (c, s) => new { c.Name, s.Car, CarPrice = s.Car.Parts.Sum(p => p.Price) }
                )
                .GroupBy(
                    cs => new { cs.Name },
                    cs => new { cs.Car, cs.CarPrice }
                )
                .Select(g => new { g.Key.Name, CarCount = g.Count(), TotalSpent = g.Sum(c => c.CarPrice) })
                .OrderByDescending(x => x.TotalSpent)
                .ThenByDescending(x => x.CarCount)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("customers");
            foreach (var c in customers)
            {
                XElement customer = new XElement("customer");
                customer.SetAttributeValue("full-name", c.Name);
                customer.SetAttributeValue("bought-cars", c.CarCount);
                customer.SetAttributeValue("spent-money", c.TotalSpent);
                root.Add(customer);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
