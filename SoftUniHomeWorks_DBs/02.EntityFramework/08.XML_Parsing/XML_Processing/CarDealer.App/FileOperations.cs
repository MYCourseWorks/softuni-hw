using CarDealer.Models;
using Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace CarDealer.App
{
    public static class FileOperations
    {
        public static void WriteToXml(Type type, XDocument doc)
        {
            if (!Directory.Exists(Constants.OutDirectory))
                Directory.CreateDirectory(Constants.OutDirectory);

            var fileName = NameConverter.ConvertClassNameToSnakeCase(type, ".xml");
            doc.Save(Constants.OutDirectory + fileName);
        }

        public static ICollection<Supplier> ParseSuppliers(string path)
        {
            ICollection<Supplier> suppliers = new List<Supplier>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var s in xmlDocument)
            {
                string name = s.Attribute("name") == null ? null : s.Attribute("name").Value;
                bool isImporter = s.Attribute("is-importer") == null ?
                    false : bool.Parse(s.Attribute("is-importer").Value);

                suppliers.Add(new Supplier()
                {
                    Name = name,
                    IsImporter = isImporter
                });
            }

            return suppliers;
        }

        public static ICollection<Part> ParseParts(string path)
        {
            ICollection<Part> parts = new List<Part>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var p in xmlDocument)
            {
                string name = p.Attribute("name") == null ? null : p.Attribute("name").Value;
                decimal price = p.Attribute("price") == null ? 0 : decimal.Parse(p.Attribute("price").Value);
                int quantity = p.Attribute("quantity") == null ? 0 : int.Parse(p.Attribute("quantity").Value);

                parts.Add(new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity
                });
            }

            return parts;
        }

        public static ICollection<Car> ParseCars(string path)
        {
            ICollection<Car> cars = new List<Car>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var c in xmlDocument)
            {
                string make = c.Element("make") == null ? null : c.Element("make").Value;
                string model = c.Element("model") == null ? null : c.Element("model").Value;
                long travelledDistance = c.Element("travelled-distance") == null 
                    ? 0 : long.Parse(c.Element("travelled-distance").Value);

                cars.Add(new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travelledDistance
                });
            }

            return cars;
        }

        public static ICollection<Customer> ParseCustomers(string path)
        {
            ICollection<Customer> customers = new List<Customer>();
            var xmlDocument = XDocument.Load(path).Root.Elements();

            foreach (var c in xmlDocument)
            {
                string name = c.Attribute("name") == null ? null : c.Attribute("name").Value;
                DateTime birthDate = DateTime.Parse(c.Element("birth-date").Value);
                bool isYoungDriver = c.Element("is-young-driver") == null ? 
                    true : bool.Parse(c.Element("is-young-driver").Value);

                customers.Add(new Customer()
                {
                    Name = name,
                    BirthDate = birthDate,
                    IsYoungDriver = isYoungDriver
                });
            }

            return customers;
        }
    }
}
