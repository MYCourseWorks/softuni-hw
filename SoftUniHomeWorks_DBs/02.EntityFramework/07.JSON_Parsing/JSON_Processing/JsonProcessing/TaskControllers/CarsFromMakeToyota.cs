using System;
using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace JSON_Processing.TaskControllers
{
    public class CarsFromMakeToyota : Task
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            }
        };

        public CarsFromMakeToyota() : base(ContextType.CarDealerContext, 8) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var cars = ctx.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new { c.Id, c.Make, c.Model, c.TravelledDistance })
                .ToArray();

            FileOperations.WriteJson(this.GetType(), cars, settings);
        }
    }
}
