using System;
using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace JSON_Processing.TaskControllers
{
    public class LocalSuppliers : Task
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new DefaultNamingStrategy()
            }
        };

        public LocalSuppliers() : base(ContextType.CarDealerContext, 9) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var supliers = ctx.Supliers
                .Where(s => s.IsImporter == false)
                .Select(s => new { s.Id, s.Name, PartsCount = s.Parts.Count })
                .ToArray();

            FileOperations.WriteJson(this.GetType(), supliers, settings);
        }
    }
}
