using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moderator_Pattern
{
    public abstract class MeetingRoom
    {
        public abstract void Register(Participant participant);

        public abstract void ShareWith(string personTalkName, string personListen, string message);

        public abstract void ShareWithAll(string personTalkName, string status);
    }
}
