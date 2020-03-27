using Global;
using ProductsShop.Data;
using System.Linq;
using System.Xml.Linq;

namespace ProductsShop.TaskControllers
{
    public class UsersSoldProducts : Task
    {
        public UsersSoldProducts() : base(3) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var userGroups = ctx.Users
                .Where(u => u.ProductsBought.Count > 0)
                .Join(
                    ctx.Products,
                    u => u.Id,
                    p => p.BuyerId,
                    (u, p) => new { u, p }
                )
                .Select(up => new { up.u.FirstName, up.u.LastName, up.p.Name, up.p.Price})
                .GroupBy(
                    up => new { up.FirstName, up.LastName },
                    up => new { ProductName = up.Name, up.Price }
                )
                .OrderBy(g => g.Key.LastName)
                .ThenBy(g => g.Key.FirstName)
                .ToArray();

            XDocument doc = new XDocument();
            XElement root = new XElement("users");
            foreach (var g in userGroups)
            {
                XElement user = new XElement("user");
                user.SetAttributeValue("first-name", g.Key.FirstName);
                user.SetAttributeValue("last-name", g.Key.LastName);

                XElement soldProducts = new XElement("sold-products");
                foreach (var p in g)
                {
                    XElement product = new XElement("product");
                    product.Add(new XElement("name", p.ProductName));
                    product.Add(new XElement("price", p.Price));
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
