using JSON_Processing.Enums;
using ProductsShop.Data;

namespace JSON_Processing.TaskControllers
{
    public abstract class Task
    {
        public Task(ContextType contextType, int ordering)
        {
            this.ContextType = contextType;
            this.Ordering = ordering;
        }

        public ContextType ContextType { get; private set; }

        public int Ordering { get; private set; }

        public abstract void Run<T>(T context);
    }
}
