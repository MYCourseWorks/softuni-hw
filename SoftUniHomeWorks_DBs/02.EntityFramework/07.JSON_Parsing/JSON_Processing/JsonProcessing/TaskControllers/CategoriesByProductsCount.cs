using ProductsShop.Data;
using System;
using System.Linq;

namespace JSON_Processing.TaskControllers
{
    public class CategoriesByProductsCount : Task
    {
        public CategoriesByProductsCount() : base(Enums.ContextType.ProductShopContext, 4) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var categories = ctx
                .Categories
                .Where(c => c.Products.Any(p => p.Categories.Any(x => x.Id == c.Id)))
                .Select(c => new
                {
                    Name = c.Name,
                    ProductCount = c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalRevenue = c.Products.Sum(p => p.Price)
                })
                .ToArray();

            FileOperations.WriteJson(this.GetType(), categories);
        }
    }
}
