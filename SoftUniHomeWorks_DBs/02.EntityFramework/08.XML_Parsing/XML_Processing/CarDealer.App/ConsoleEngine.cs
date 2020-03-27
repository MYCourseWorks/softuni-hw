using System;
using System.Data.Entity;
using System.Threading;

namespace CarDealer.App
{
    public class ConsoleEngine<Context> where Context : DbContext
    {
        public void Run()
        {
            while (true)
            {
                var contextType = typeof(Context);

                using (var context = (Context)Activator.CreateInstance(contextType))
                {
                    Console.WriteLine(Constants.MenuOptions);
                    Console.Write("Option = ");
                    string line = Console.ReadLine();

                    Console.Clear();

                    if (line == "exit")
                    {
                        break;
                    }

                    Console.WriteLine("Loading ...");

                    if (line == "all")
                    {
                        foreach (var tc in Constants.TaskControllers)
                        {
                            tc.Run(context);
                        }

                        continue;
                    }

                    int option = 0;
                    int.TryParse(line, out option);

                    if (0 <= option - 1 && option - 1 < Constants.TaskControllers.Count)
                    {
                        var taskChoise = Constants.TaskControllers[option - 1];
                        taskChoise.Run(context);
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
