using Global;
using ProductsShop.Data;
using System;
using System.Linq;

namespace ProductsShop.TaskControllers
{
    public class ImportData : Task
    {
        private static Random random = new Random();

        public ImportData() : base(1) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            if (ctx.Database.Exists())
                ctx.Database.Delete();
            ctx.Database.Create();

            ParseUsers(ctx);
            ParseProducts(ctx);
            ParseCategories(ctx);
        } 

        public void ParseUsers(ProductShopContext ctx)
        {
            var users = FileOperations.ParseUsers(Constants.UserXml);

            int i = 0;
            foreach (var u in users)
            {
                u.Id = i++;
                ctx.Users.Add(u);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not add users.");
        }

        public void ParseProducts(ProductShopContext ctx)
        {
            var products = FileOperations.ParseProducts(Constants.ProductXml);
            var users = ctx.Users.ToArray();

            int i = 0;
            foreach (var p in products)
            {
                p.Id = i++;
                p.Seller = users[random.Next(0, users.Length - 1)];

                if (random.Next() % 2 == 0)
                    p.Buyer = users[random.Next(0, users.Length - 1)];

                ctx.Products.Add(p);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not add products.");
        }

        public void ParseCategories(ProductShopContext ctx)
        {
            var categories = FileOperations.ParseCategories(Constants.CategoryXml);
            var products = ctx.Products.ToArray();

            int i = 0;
            foreach (var c in categories)
            {
                c.Id = i++;
                int rndNumberOfProducts = random.Next(5, 20);

                for (int j = 0; j < rndNumberOfProducts; j++)
                {
                    var rndProduct = products[random.Next(0, products.Length - 1)];

                    if (!c.Products.Contains(rndProduct))
                        c.Products.Add(rndProduct);
                    else
                        j--;
                }

                ctx.Categories.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(ctx, "Could not add categories.");
        }
    }
}
