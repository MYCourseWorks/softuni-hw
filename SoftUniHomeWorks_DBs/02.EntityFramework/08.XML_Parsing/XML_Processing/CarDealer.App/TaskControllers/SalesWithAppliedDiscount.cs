using CarDealer.Data;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class SalesWithAppliedDiscount : Task
    {
        public SalesWithAppliedDiscount() : base(7) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var saleInfo = ctx.Sales
                .Select(s => new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TravelledDistance,
                    s.Customer.Name,
                    s.Discount,
                    Price = s.Car.Parts.Sum(c => c.Price),
                    PriceWithDiscount = s.Car.Parts.Sum(c => c.Price) - s.Car.Parts.Sum(c => c.Price) * s.Discount
                })
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("sales");
            foreach (var s in saleInfo)
            {
                XElement saleElem = new XElement("sale");
                XElement carElem = new XElement("car");
                carElem.SetAttributeValue("make", s.Make);
                carElem.SetAttributeValue("model", s.Model);
                carElem.SetAttributeValue("travelled-distance", s.TravelledDistance);

                saleElem.Add(carElem);
                saleElem.Add(new XElement("customer-name", s.Name));
                saleElem.Add(new XElement("discount", s.Discount));
                saleElem.Add(new XElement("price", s.Price));
                saleElem.Add(new XElement("price-with-discount", s.PriceWithDiscount));

                root.Add(saleElem);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
