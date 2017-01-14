using System;
using System.Collections.Generic;

namespace CalendarSystem.Events.Contracts
{
    public interface IEventsManager
    {
        void AddEvent(Event eventToAdd);

        int DeleteEventsByTitle(string b);

        IEnumerable<Event> ListEvents(DateTime date, int d);
    }
}
