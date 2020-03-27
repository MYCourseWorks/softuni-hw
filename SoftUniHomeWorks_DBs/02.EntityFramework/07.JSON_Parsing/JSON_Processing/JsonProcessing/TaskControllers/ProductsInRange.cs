using ProductsShop.Data;
using System;
using System.Linq;

namespace JSON_Processing.TaskControllers
{
    public class ProductsInRange : Task
    {
        public ProductsInRange() : base(Enums.ContextType.ProductShopContext, 2) { }
        public object ProductsShopContext { get; private set; }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var products = ctx.Products
                .Where(p => 500 <= p.Price && p.Price <= 1000)
                .OrderByDescending(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    SellerFullName = p.Seller.FirstName + p.Seller.LastName
                })
                .ToArray();
            
            FileOperations.WriteJson(this.GetType(), products);
        }
    }
}
