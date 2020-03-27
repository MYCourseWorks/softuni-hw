using Global;
using CarDealer.Data;
using System.Linq;
using System.Xml.Linq;

namespace CarDealer.App.TaskControllers
{
    public class LocalSuppliers : Task
    {
        public LocalSuppliers() : base(4) { }

        public override void Run<T>(T context)
        {
            var ctx = context as CarDealerContext;
            var suppliers = ctx.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new { s.Id, s.Name, s.Parts.Count })
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("suppliers");
            foreach (var s in suppliers)
            {
                XElement supElem = new XElement("supplier");
                supElem.SetAttributeValue("id", s.Id);
                supElem.SetAttributeValue("name", s.Name);
                supElem.SetAttributeValue("parts-count", s.Count);
                root.Add(supElem);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
