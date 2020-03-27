using System;
using ProductsShop.Data;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSON_Processing.TaskControllers
{
    public class UsersAndProducts : Task
    {
        public UsersAndProducts() : base(Enums.ContextType.ProductShopContext, 5) { }

        public override void Run<T>(T context)
        {
            var ctx = context as ProductShopContext;
            var users = ctx.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new { u.FirstName, u.LastName, u.Age, u.SoldProducts })
                .ToArray();

            JObject result = new JObject();
            result.Add("usersCount", users.Length);
            JArray usersArr = new JArray();
            foreach (var u in users)
            {
                JObject usersObject = new JObject();
                usersObject.Add("firstName", u.FirstName);
                usersObject.Add("lastName", u.LastName);
                usersObject.Add("age", u.Age);

                JObject soldProductsObj = new JObject();
                soldProductsObj.Add("count", u.SoldProducts.Count);
                JArray productsArr = new JArray();
                foreach (var p in u.SoldProducts)
                {
                    JObject productObj = new JObject();
                    productObj.Add("name", p.Name);
                    productObj.Add("price", p.Price);
                    productsArr.Add(productObj);
                }

                soldProductsObj.Add(new JProperty("products", productsArr));
                usersObject.Add("soldProducts", soldProductsObj);
                usersArr.Add(usersObject);
            }

            result.Add(new JProperty("users", usersArr));
            FileOperations.WriteJson(this.GetType(), result);
        }
    }
}
