using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderator_Pattern
{
    public class Participant:Person
    {
        private MeetingRoom dailyMeetingRoom;

        public Participant(string name)
            :base(name)
        {
            
        }
        public MeetingRoom DailyMeetingRoom
        {
            get { return this.dailyMeetingRoom; }
            set { this.dailyMeetingRoom = value; }
        }
        public void Join(MeetingRoom meeting)
        {
            meeting.Register(this);
        }
        public void DiscussWith(string meetingParticipantName, string status)
        {
            this.dailyMeetingRoom.ShareWith(this.Name, meetingParticipantName, status);
        }

        public void ShareWorkStatus(string message)
        {
            this.dailyMeetingRoom.ShareWithAll(this.Name, message);
        }

        public virtual void Receive(string from, string status)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, status);
        }

    }
}
