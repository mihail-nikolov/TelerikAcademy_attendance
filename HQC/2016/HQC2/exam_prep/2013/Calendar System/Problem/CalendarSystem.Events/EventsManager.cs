using CalendarSystem.Events.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem.Events
{
    public class EventsManager : IEventsManager
    {
        private readonly List<Event> eventsList = new List<Event>();

        public void AddEvent(Event e)
        {
            this.eventsList.Add(e);
        }
        public int DeleteEventsByTitle(string t)
        {
            return this.eventsList
                .RemoveAll(e => e.Title.ToLowerInvariant() == t.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberToTake)
        {
            var events = (from e in this.eventsList
                          where e.Date >= date
                          orderby e.Date, e.Title, e.Location
                          select e).Take(numberToTake);
            return events;
        }
    }
}
