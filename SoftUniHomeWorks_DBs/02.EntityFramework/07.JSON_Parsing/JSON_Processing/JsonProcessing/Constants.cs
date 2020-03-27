using JSON_Processing.TaskControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace JSON_Processing
{
    public static class Constants
    {
        private static readonly Tuple<List<Task>, string> OptionTuple = GetAllOptions();
        public static readonly string MenuOptions = OptionTuple.Item2;
        public static readonly List<Task> TaskControllers = OptionTuple.Item1;

        public static readonly int ProgramDelay = 2000;
        public static readonly string TaskSuccessfullyExecuted = "Task Successfully Executed";
        public static readonly string ErrorOption = "Invalid Option";
        public static readonly string ResourceDirectory = "../../resources/";
        public static readonly string OutDirectory = "../../out/";

        public static readonly string UserJson = ResourceDirectory + "users.json";
        public static readonly string ProductJson = ResourceDirectory + "products.json";
        public static readonly string CategoryJson = ResourceDirectory + "categories.json";

        public static readonly string SupplierJson = ResourceDirectory + "suppliers.json";
        public static readonly string PartJson = ResourceDirectory + "parts.json";
        public static readonly string CarJson = ResourceDirectory + "cars.json";
        public static readonly string CustomerJson = ResourceDirectory + "customers.json";
        public static readonly string SaleJson = ResourceDirectory + "sales.json";

        private static Tuple<List<Task>, string> GetAllOptions()
        {
            Type[] typelist = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => string.Equals(t.Namespace, "JSON_Processing.TaskControllers", StringComparison.Ordinal))
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var tasks = new List<Task>();
            sb.AppendLine("Application data source=.\\SQLEXPRESS");
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
