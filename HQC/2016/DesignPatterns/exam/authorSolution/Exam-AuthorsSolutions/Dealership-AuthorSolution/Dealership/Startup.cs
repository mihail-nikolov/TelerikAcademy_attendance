using Dealership.Engine;
using Dealership.Factories;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var factory = new DealershipFactory();
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var engine = new DealershipEngine(factory, writer, reader);
            engine.Start();
        }
    }
}
