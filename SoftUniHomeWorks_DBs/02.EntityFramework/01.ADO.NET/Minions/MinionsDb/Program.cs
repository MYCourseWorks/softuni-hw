namespace MinionsDb
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            c.InitializeDb();
        }
    }
}
