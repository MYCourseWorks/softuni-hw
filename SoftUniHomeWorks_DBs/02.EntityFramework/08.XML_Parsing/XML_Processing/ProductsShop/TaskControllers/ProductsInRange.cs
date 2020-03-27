using Global;
using ProductsShop.Data;
using System;
using System.Linq;
using System.Xml.Linq;

namespace ProductsShop.TaskControllers
{
    public class ProductsInRange : Task
    {
        public ProductsInRange() : base(2) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;

            var products = ctx.Products
                .Where(p => 1000 <= p.Price && p.Price <= 2000 && p.BuyerId != null)
                .Select(p => new { ProductName = p.Name, p.Price, BuyerFullName = p.Buyer.FirstName + " " + p.Buyer.LastName })
                .OrderByDescending(p => p.Price)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("products");
            foreach (var p in products)
            {
                var productObj = new XElement("product");
                productObj.SetAttributeValue("name", p.ProductName);
                productObj.SetAttributeValue("price", p.Price);
                productObj.SetAttributeValue("buyer", p.BuyerFullName);
                root.Add(productObj);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
