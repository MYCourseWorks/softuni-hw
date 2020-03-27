using System;
using Global;
using CarDealer.Data;
using System.Linq;
using System.Data.Entity;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class CarsAndParts : Task
    {
        public CarsAndParts() : base(5) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var cars = ctx.Cars
                .Include(c => c.Parts)
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    Parts = c.Parts.Select(p => new { p.Name, p.Price })
                })
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElem = new XElement("car");
                carElem.SetAttributeValue("make", c.Make);
                carElem.SetAttributeValue("model", c.Model);
                carElem.SetAttributeValue("travelled-distance", c.TravelledDistance);
                XElement partsElem = new XElement("parts");
                foreach (var p in c.Parts)
                {
                    XElement partElem = new XElement("part");
                    partElem.SetAttributeValue("name", p.Name);
                    partElem.SetAttributeValue("price", p.Price);
                    partsElem.Add(partElem);
                }

                carElem.Add(partsElem);
                root.Add(carElem);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
