using Newtonsoft.Json.Linq;
using ProductsShop.Data;
using ProductsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSON_Processing.TaskControllers
{
    public class UsersSoldProducts : Task
    {
        public UsersSoldProducts() : base(Enums.ContextType.ProductShopContext, 3) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var products = ctx.Products
                .Where(p => p.Buyer != null)
                .Join(
                    ctx.Users,
                    p => p.SellerId,
                    u => u.Id,
                    (p, u) => new
                    {
                        UserFirstName = u.FirstName,
                        UserLastName = u.LastName,
                        ProductName = p.Name,
                        ProductPrice = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    }
                )
                .GroupBy(
                    pu => new { pu.UserFirstName, pu.UserLastName },
                    pu => new { pu.ProductName, pu.ProductPrice, pu.BuyerFirstName, pu.BuyerLastName }
                )
                .OrderBy(g => g.Key.UserLastName)
                .ThenBy(g => g.Key.UserFirstName)
                .ToArray();

            JArray result = new JArray();
            foreach (var g in products)
            {
                JObject jo = new JObject();
                jo.Add("firstName", g.Key.UserFirstName);
                jo.Add("lastName", g.Key.UserLastName);

                JArray soldProducts = new JArray();
                foreach (var p in g)
                {
                    JObject innerJo = new JObject();
                    innerJo.Add("name", p.ProductName);
                    innerJo.Add("price", p.ProductPrice);
                    innerJo.Add("buyerFirstName", p.BuyerFirstName);
                    innerJo.Add("buyerLastName", p.BuyerLastName);
                    soldProducts.Add(innerJo);
                }

                jo.Add(new JProperty("soldProducts", soldProducts));
                result.Add(jo);
            }

            FileOperations.WriteJson(this.GetType(), result);
        }
    }
}
