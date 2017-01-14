using Dealership.Engine;
using System.Globalization;
using System.Threading;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DealershipEngine.Instance.Start();
        }
    }
}
