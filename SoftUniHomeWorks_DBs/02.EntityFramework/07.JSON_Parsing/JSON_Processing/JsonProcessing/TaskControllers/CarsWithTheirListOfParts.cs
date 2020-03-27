using JSON_Processing.Enums;
using CarDealer.Data;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSON_Processing.TaskControllers
{
    public class CarsWithTheirListOfParts : Task
    {
        public CarsWithTheirListOfParts() : base(ContextType.CarDealerContext, 10) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var cars = ctx.Cars
                .Where(c => c.Parts.Any(p => p.Cars.Any(x => x.Id == c.Id)))
                .Select(c => new { c.Make, c.Model, c.TravelledDistance, c.Parts })
                .ToArray();

            JArray result = new JArray();
            foreach (var c in cars)
            {
                JObject carPartsObj = new JObject();

                JObject carsObj = new JObject();
                carsObj.Add("Make", c.Make);
                carsObj.Add("Model", c.Model);
                carsObj.Add("TravelledDistance", c.TravelledDistance);

                JArray partsArray = new JArray();
                foreach (var p in c.Parts)
                {
                    JObject partObj = new JObject();
                    partObj.Add("Name", p.Name);
                    partObj.Add("Price", p.Name);
                    partsArray.Add(partObj);
                }

                carPartsObj.Add(new JProperty("car", carsObj));
                carPartsObj.Add(new JProperty("parts", partsArray));
                result.Add(carPartsObj);
            }

            FileOperations.WriteJson(this.GetType(), result);
        }
    }
}
