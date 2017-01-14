using CalendarSystem.Events;
using System;
using Wintellect.PowerCollections;

namespace CalendarSystem.Tests
{
    public class ExtendedEventsManagerFast : EventsManagerFast
    {
        public MultiDictionary<string, Event> EventsDictionary
        {
            get
            {
                return this.eventsDictionary;
            }
        }

        public OrderedMultiDictionary<DateTime, Event> EventsOrderedByDate
        {
            get
            {
                return this.eventsOrderedByDate;
            }
        }

    }
}
