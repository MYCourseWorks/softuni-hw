using ProductsShop.Data;

namespace ProductsShop
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var en = new ConsoleEngine<ProductShopContext>();
            en.Run();
        }
    }
}
