using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSON_Processing.TaskControllers
{
    public class TotalSalesByCustomer : Task
    {
        public TotalSalesByCustomer() : base(ContextType.CarDealerContext, 11) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var customers = ctx.Customers
                .Join(
                    ctx.Sales,
                    c => c.Id,
                    s => s.Customer.Id,
                    (c, s) => new { c, s }
                )
                .Join(
                    ctx.Cars,
                    cs => cs.s.Car.Id,
                    c => c.Id,
                    (cs, c) => new { cs, c, spentForCar = c.Parts.Sum(p => p.Price) }
                )
                .GroupBy(
                    csc => new { csc.cs.c.Name },
                    csc => new { csc.spentForCar }
                )
                .Select(g => new
                {
                    FirstName = g.Key.Name,
                    BoughtCars = g.Count(),
                    SpentMoney = g.Sum(x => x.spentForCar)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();

            FileOperations.WriteJson(this.GetType(), customers);
        }
    }
}
