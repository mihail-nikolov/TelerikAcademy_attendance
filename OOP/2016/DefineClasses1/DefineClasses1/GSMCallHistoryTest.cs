using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    public class GSMCallHistoryTest
    {
        public void HistoryTest()
        {
            GSM myGSM = new GSM("nokia", "nokiaEOOD");
            myGSM.AddCall(new Call(DateTime.Parse("15/03/2015 13:26:48"), 388297912, 11));
            myGSM.AddCall(new Call(DateTime.Parse("15/03/2015 13:45:48"), 3213213599, 13));
            myGSM.AddCall(new Call(DateTime.Parse("15/03/2015 14:26:48"), 359894969656, 48));
            myGSM.AddCall(new Call(DateTime.Parse("15/03/2015 15:26:48"), 359894969656, 59));
            myGSM.PrintCallHistory();
            Console.WriteLine("Total Price: {0}.", myGSM.CallPriceCalc());
            Console.WriteLine("----------------------------------");
            Call longestCall = myGSM.CallHistory.OrderBy(call => call.Duration).ToArray()[myGSM.CallHistory.Count - 1];
            myGSM.DelCall(longestCall);
            myGSM.PrintCallHistory();
            Console.WriteLine("Total Price: {0}.", myGSM.CallPriceCalc());
            Console.WriteLine("----------------------------------");
            myGSM.ClearHistory();
            Console.WriteLine("here is the new history (it is empty) --> must be empty line -->");
            myGSM.PrintCallHistory();
        }
    }
}
