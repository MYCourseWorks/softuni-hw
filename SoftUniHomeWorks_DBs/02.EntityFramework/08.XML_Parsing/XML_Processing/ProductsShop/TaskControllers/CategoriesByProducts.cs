using Global;
using ProductsShop.Data;
using System.Linq;
using System.Xml.Linq;

namespace ProductsShop.TaskControllers
{
    public class CategoriesByProducts : Task
    {
        public CategoriesByProducts() : base(4) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var categories = ctx.Categories
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    c.Name,
                    CountOfProducts = c.Products.Count,
                    AveragePrice = c.Products.Average(x => x.Price),
                    TotalRevenue = c.Products.Sum(x => x.Price)
                })
                .OrderByDescending(c => c.CountOfProducts)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("categories");
            foreach (var c in categories)
            {
                XElement category = new XElement("category");
                category.SetAttributeValue("name", c.Name);
                category.Add(new XElement("products-count", c.CountOfProducts));
                category.Add(new XElement("average-price", c.AveragePrice));
                category.Add(new XElement("total-revenue", c.TotalRevenue));
                root.Add(category);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
