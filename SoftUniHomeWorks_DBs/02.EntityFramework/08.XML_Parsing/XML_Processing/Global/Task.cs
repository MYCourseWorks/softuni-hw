namespace Global
{
    public abstract class Task
    {
        public Task(int ordering)
        {
            this.Ordering = ordering;
        }

        public int Ordering { get; private set; }

        public abstract void Run<T>(T context);
    }
}
