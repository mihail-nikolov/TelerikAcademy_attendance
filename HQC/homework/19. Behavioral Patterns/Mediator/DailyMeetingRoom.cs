using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderator_Pattern
{
    public  class DailyMeetingRoom : MeetingRoom
    {
        private readonly Dictionary<string, Participant> participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!this.participants.ContainsValue(participant))
            {
                this.participants[participant.Name] = participant;
            }

            participant.DailyMeetingRoom = this;
        }

        public override void ShareWith(string personTalk, string personListen, string message)
        {
            var participant = this.participants[personListen];

            if (participant != null)
            {
                participant.Receive(personTalk, message);
            }
        }

        public override void ShareWithAll(string @personTalk, string status)
        {
            foreach (var participant in this.participants)
            {
                if (participant.Key != @personTalk)
                {
                    participant.Value.Receive(@personTalk, status);
                }
            }
        }
    }
}
