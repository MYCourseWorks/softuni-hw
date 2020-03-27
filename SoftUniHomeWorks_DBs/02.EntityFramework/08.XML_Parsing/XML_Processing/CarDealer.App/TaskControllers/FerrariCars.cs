using CarDealer.Data;
using Global;
using System.Linq;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class FerrariCars : Task
    {
        public FerrariCars() : base(3) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var cars = ctx.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElem = new XElement("car");
                carElem.SetAttributeValue("id", c.Id);
                carElem.SetAttributeValue("model", c.Model);
                carElem.SetAttributeValue("travelled-distance", c.TravelledDistance);
                root.Add(carElem);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
