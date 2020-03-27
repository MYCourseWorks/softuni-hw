using CarDealer.Data;

namespace CarDealer.App
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var en = new ConsoleEngine<CarDealerContext>();
            en.Run();
        }
    }
}
