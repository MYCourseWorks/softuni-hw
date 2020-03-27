using System;
using System.Linq;
using ProductsShop.Data;
using ProductsShop.Data.Models;
using System.Text;
using JSON_Processing.TaskControllers;

namespace JSON_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            var en = new Engine();
            en.Run();
        }
    }
}
