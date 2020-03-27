using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CarDealer.App
{
    public static class Constants
    {
        private static readonly Tuple<List<Task>, string> OptionTuple = GetAllOptions();
        public static readonly string MenuOptions = OptionTuple.Item2;
        public static readonly List<Task> TaskControllers = OptionTuple.Item1;

        public static readonly int ProgramDelay = 2000;
        public static readonly string TaskSuccessfullyExecuted = "Task Successfully Executed";
        public static readonly string ErrorOption = "Invalid Option";
        public static readonly string ResourcesDirectory = "../../resources/";
        public static readonly string OutDirectory = "../../out/";

        public static readonly string CarXml = ResourcesDirectory + "cars.xml";
        public static readonly string CustomerXml = ResourcesDirectory + "customers.xml";
        public static readonly string PartsXml = ResourcesDirectory + "parts.xml";
        public static readonly string SupplierXml = ResourcesDirectory + "suppliers.xml";

        private static Tuple<List<Task>, string> GetAllOptions()
        {
            Type[] typelist = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => string.Equals(t.Namespace, "CarDealer.App.TaskControllers", StringComparison.Ordinal))
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var tasks = new List<Task>();
            sb.AppendLine("Application data source=.\\SQLEXPRESS");
            sb.AppendLine("Close all existing connection to the database before running option 1.");
            sb.AppendLine("Choose Option :");

            foreach (var t in typelist)
            {
                if (t.BaseType.Name == "Task" && Regex.IsMatch(t.Name, @"^\w+$"))
                {
                    var task = (Task)Activator.CreateInstance(t);
                    tasks.Add(task);
                }
            }
            tasks = tasks.OrderBy(t => t.Ordering).ToList();

            int i = 0;
            foreach (var t in tasks)
            {
                sb.AppendLine($"{++i} : {t.GetType().Name}");
            }

            sb.AppendLine("all: to run every task sequentially");
            sb.AppendLine("exit: to exit program");
            return new Tuple<List<Task>, string>(tasks, sb.ToString());
        }
    }
}
