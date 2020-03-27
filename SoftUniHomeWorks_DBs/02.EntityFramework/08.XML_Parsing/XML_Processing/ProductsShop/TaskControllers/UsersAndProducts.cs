using Global;
using ProductsShop.Data;
using System.Linq;
using System.Xml.Linq;

namespace ProductsShop.TaskControllers
{
    public class UsersAndProducts : Task
    {
        public UsersAndProducts() : base(5) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var userGroups = ctx.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Join(
                    ctx.Products,
                    u => u.Id,
                    p => p.SelledId,
                    (u, p) => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        ProductsSoldCount = u.ProductsSold.Count,
                        p.Name,
                        p.Price
                    }
                )
                .GroupBy(
                    up => new { up.FirstName, up.LastName, up.Age, up.ProductsSoldCount },
                    up => new { up.Name, up.Price }
                )
                .OrderByDescending(g => g.Key.ProductsSoldCount)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("users");
            root.SetAttributeValue("count", userGroups.Length);
            foreach (var g in userGroups)
            {
                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", g.Key.FirstName);
                user.SetAttributeValue("last-name", g.Key.LastName);
                user.SetAttributeValue("age", g.Key.Age);
                XElement soldProducts = new XElement("sold-products");
                soldProducts.SetAttributeValue("count", g.Key.ProductsSoldCount);
                foreach (var p in g)
                {
                    XElement product = new XElement("product");
                    product.SetAttributeValue("name", p.Name);
                    product.SetAttributeValue("price", p.Price);
                    soldProducts.Add(product);
                }

                user.Add(soldProducts);
                root.Add(user);
            }
            doc.Add(root);

            FileOperations.WriteToXml(GetType(), doc);
        }
    }
}
