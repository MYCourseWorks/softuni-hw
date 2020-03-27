using System.Linq;
using TeamBuilder.Data.Client;

namespace TeamBuilder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient c = new ConsoleClient();
            c.Run();
        }
    }
}
