using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;

namespace JSON_Processing.TaskControllers
{
    public class SalesWithAppliedDiscount : Task
    {
        public SalesWithAppliedDiscount() : base(ContextType.CarDealerContext, 12) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var sales = ctx.Sales
                .Join(
                    ctx.Customers,
                    s => s.Customer.Id,
                    c => c.Id,
                    (s, c) => new { s, c }
                )
                .Join(
                    ctx.Cars,
                    sc => sc.s.Car.Id,
                    c => c.Id,
                    (sc, c) => new { sc, c }
                )
                .Select(scc => new
                {
                    Car = new { scc.c.Make, scc.c.Model, scc.c.TravelledDistance },
                    CustomerName = scc.sc.c.Name,
                    Discount = scc.sc.s.Discount,
                    Price = scc.c.Parts.Sum(p => p.Price),
                    PriceWithDiscount = scc.c.Parts.Sum(p => p.Price) - scc.c.Parts.Sum(p => p.Price) * scc.sc.s.Discount
                })
                .ToArray();

            FileOperations.WriteJson(this.GetType(), sales);
        }
    }
}
