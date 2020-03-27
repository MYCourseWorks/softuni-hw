using CarDealer.Data;
using JSON_Processing.TaskControllers;
using ProductsShop.Data;
using System;
using System.Linq;
using System.Threading;

namespace JSON_Processing
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                using (var cdContext = new CarDealerContext())
                using (var psContext = new ProductShopContext())
                {

                    Console.WriteLine(Constants.MenuOptions);
                    Console.Write("Option = ");
                    string line = Console.ReadLine();

                    Console.Clear();

                    if (line == "exit")
                    {
                        break;
                    }
                    if (line == "all")
                    {
                        foreach (var tc in Constants.TaskControllers)
                        {
                            switch (tc.ContextType)
                            {
                                case Enums.ContextType.ProductShopContext: tc.Run(psContext); break;
                                case Enums.ContextType.CarDealerContext: tc.Run(cdContext); break;
                                default: break;
                            }
                        }

                        continue;
                    }

                    int option = 0;
                    int.TryParse(line, out option);

                    if (0 <= option - 1 && option - 1 < Constants.TaskControllers.Count)
                    {
                        var taskChoise = Constants.TaskControllers[option - 1];

                        switch (taskChoise.ContextType)
                        {
                            case Enums.ContextType.ProductShopContext: taskChoise.Run(psContext); break;
                            case Enums.ContextType.CarDealerContext: taskChoise.Run(cdContext); break;
                            default: break;
                        }

                        Console.WriteLine(Constants.TaskSuccessfullyExecuted);
                    }
                    else
                    {
                        Console.WriteLine(Constants.ErrorOption);
                    }

                    Thread.Sleep(Constants.ProgramDelay);
                    Console.Clear();
                }
            }
        }
    }
}
