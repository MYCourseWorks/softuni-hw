using System;
using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSON_Processing.TaskControllers
{
    public class OrderedCustomers : Task
    {
        public OrderedCustomers() : base(ContextType.CarDealerContext, 7) { }

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
                .GroupBy(
                    cs => new { cs.c },
                    cs => new { cs.s }
                )
                .OrderBy(g => g.Key.c.BirthDate)
                .ThenByDescending(g => g.Key.c.IsYoungDriver)
                .ToArray();

            JArray result = new JArray();
            foreach (var g in customers)
            {
                JObject jo = new JObject();
                jo.Add("Id", g.Key.c.Id);
                jo.Add("Name", g.Key.c.Name);
                jo.Add("BirthDate", g.Key.c.BirthDate);
                jo.Add("IsYoungDriver", g.Key.c.IsYoungDriver);

                JArray sales = new JArray();
                foreach (var item in g)
                {
                    JObject saleObj = new JObject();
                    saleObj.Add("Id", item.s.Id);
                    saleObj.Add("Discount", item.s.Discount);
                    sales.Add(saleObj);
                }
                
                jo.Add(new JProperty("Sales", sales));
                result.Add(jo);
            }
            
            FileOperations.WriteJson(this.GetType(), result);
        }
    }
}
