using CalendarSystem.Events.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem.Events
{
    public class EventsManagerFast : IEventsManager
    {
        protected readonly MultiDictionary<string, Event> eventsDictionary = new MultiDictionary<string, Event>(true);
        protected readonly OrderedMultiDictionary<DateTime, Event> eventsOrderedByDate = new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event eventToAdd)
        {
            string eventTitleLowerCase = eventToAdd.Title.ToLowerInvariant();
            this.eventsDictionary.Add(eventTitleLowerCase, eventToAdd);
            this.eventsOrderedByDate.Add(eventToAdd.Date, eventToAdd);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLowerInvariant();
            var eventsToRemove = this.eventsDictionary[titleToLower];
            int countToRemove = eventsToRemove.Count;

            foreach (var ev in eventsToRemove)
            {
                this.eventsOrderedByDate.Remove(ev.Date, ev);
            }

            this.eventsDictionary.Remove(titleToLower);

            return countToRemove;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int numberToTake)
        {
            var events = (from e in this.eventsOrderedByDate.RangeFrom(date, true).Values
                          select e).Take(numberToTake);

            return events;
        }
    }
}
