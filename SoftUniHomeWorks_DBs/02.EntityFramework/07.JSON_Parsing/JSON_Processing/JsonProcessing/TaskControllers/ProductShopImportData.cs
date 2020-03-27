using System;
using System.Linq;
using ProductsShop.Data;
using ProductsShop.Data.Models;
using JSON_Processing.Global;

namespace JSON_Processing.TaskControllers
{
    public class ProductShopImportData : Task
    {
        private static Random random = new Random();
        private ProductShopContext context;

        public ProductShopImportData() : base(Enums.ContextType.ProductShopContext, 1) { }

        public override void Run<T>(T context)
        {
            this.context = context as ProductShopContext;
            if (this.context.Database.Exists())
                this.context.Database.Delete();
            this.context.Database.Create();

            ParseUsers();
            ParseCategories();
            ParseProducts();
        }

        private void ParseUsers()
        {
            var users = FileOperations.DeserializeJson<User>(Constants.UserJson);

            int i = 0;
            foreach (var u in users)
            {
                u.Id = i++;
                this.context.Users.Add(u);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add users.");
        }

        private void ParseCategories()
        {
            var categories = FileOperations.DeserializeJson<Category>(Constants.CategoryJson);

            int i = 0;
            foreach (var c in categories)
            {
                c.Id = i++;
                this.context.Categories.Add(c);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add categories.");
        }

        private void ParseProducts()
        {
            var products = FileOperations.DeserializeJson<Product>(Constants.ProductJson);
            var users = context.Users.ToArray();
            var categories = context.Categories.ToArray();
            int categoriesCount = context.Categories.Count();

            int i = 0;
            foreach (var p in products)
            {
                p.Id = i++;
                p.Seller = users[random.Next(0, users.Length - 1)];
                if (random.Next() % 2 == 0)
                    p.Buyer = users[random.Next(0, users.Length - 1)];

                int rndCategoryCount = random.Next(0, categoriesCount - 1);
                for (int j = 0; j < rndCategoryCount; j++)
                {
                    var rndCategory = categories[random.Next(0, categoriesCount - 1)];
                    if (!p.Categories.Contains(rndCategory))
                        p.Categories.Add(rndCategory);
                }

                this.context.Products.Add(p);
            }

            DbOperationExtentions.ExecTranOnContext(this.context, "Could not add products.");
        }
    }
}
