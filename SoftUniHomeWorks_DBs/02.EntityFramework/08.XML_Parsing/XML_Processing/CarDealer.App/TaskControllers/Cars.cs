using CarDealer.Data;
using Global;
using System.Linq;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class Cars : Task
    {
        public Cars() : base(2) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var cars = ctx.Cars
                .Where(c => c.TravelledDistance > 2000000L)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToArray();

            XDocument doc = new XDocument();
            XElement carElems = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElem = new XElement("car");
                carElem.Add(new XElement("make", c.Make));
                carElem.Add(new XElement("model", c.Model));
                carElem.Add(new XElement("travelled-distance", c.TravelledDistance));
                carElems.Add(carElem);
            }
            doc.Add(carElems);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
