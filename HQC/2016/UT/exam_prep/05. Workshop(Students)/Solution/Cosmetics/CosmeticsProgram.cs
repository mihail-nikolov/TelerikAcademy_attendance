using Cosmetics.Engine;
using Cosmetics.Products;
using System.Globalization;
using System.Threading;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var consoleCommandParser = new ConsoleCommandParser();
            var engine = new CosmeticsEngine(factory, shoppingCart, consoleCommandParser);

            engine.Start();
        }
    }
}
