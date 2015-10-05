using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderator_Pattern
{
    class Program
    {
        static void Main()
        {
            var theGreenRoom = new DailyMeetingRoom();
            var pesho = new Participant("pehata");
            var gogo = new Participant("gogata");
            var sasho = new Participant("sasheto");

            pesho.Join(theGreenRoom);
            gogo.Join(theGreenRoom);
            sasho.Join(theGreenRoom);

            pesho.ShareWorkStatus("I am done with story 535");
            gogo.ShareWorkStatus("I am done with story 545");
            string sashoStatus = string.Format("I need some help from {0}", gogo.Name);
            sasho.ShareWorkStatus(sashoStatus);
            gogo.DiscussWith(sasho.Name, "what kind of help do you need");
            sasho.DiscussWith(gogo.Name, "some advice about behavioral pattern usage");
        }
    }
}
