using Global;
using ProductsShop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ProductsShop
{
    public static class FileOperations
    {
        public static ICollection<User> ParseUsers(string path)
        {
            ICollection<User> users = new List<User>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var e in xmlDocument)
            {
                var firstName = e.Attribute("first-name");
                var lastName = e.Attribute("last-name");
                var age = e.Attribute("age");
                var u = new User()
                {
                    FirstName = firstName == null ? null : firstName.Value,
                    LastName = lastName == null ? null : lastName.Value,
                    Age = age == null ? 0 : int.Parse(age.Value)
                };

                users.Add(u);
            }

            return users;
        }

        public static ICollection<Product> ParseProducts(string path)
        {
            ICollection<Product> products = new List<Product>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var product in xmlDocument)
            {
                string productName = null;
                decimal price = 0;

                foreach (var n in product.Elements())
                {
                    if (n.Name.LocalName == "name")
                        productName = n.Value;
                    else if (n.Name.LocalName == "price")
                        price = decimal.Parse(n.Value);
                }

                products.Add(new Product()
                {
                    Name = productName,
                    Price = price
                });
            }

            return products;
        }

        public static void WriteToXml(Type type, XDocument doc)
        {
            if (!Directory.Exists(Constants.OutDirectory))
                Directory.CreateDirectory(Constants.OutDirectory);

            var fileName = NameConverter.ConvertClassNameToSnakeCase(type, ".xml");
            doc.Save(Constants.OutDirectory + fileName);
        }

        public static ICollection<Category> ParseCategories(string path)
        {
            ICollection<Category> categories = new List<Category>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var category in xmlDocument)
            {
                var name = category.Element("name");
                categories.Add(new Category()
                {
                    Name = name == null ? null : name.Value
                });
            }

            return categories;
        }
    }
}
