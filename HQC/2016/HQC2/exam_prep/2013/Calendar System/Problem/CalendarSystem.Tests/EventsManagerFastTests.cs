namespace CalendarSystem.Tests
{
    using Events;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class EventsManagerFastTests
    {
        [Test]
        public void AddEvent_ShouldAddTheEventToBothCollections()
        {
            var eventsManager = new ExtendedEventsManagerFast();
            var currentDateTime = DateTime.Now;
            var event1 = new Event(currentDateTime, "Event1");
            eventsManager.AddEvent(event1);

            Assert.IsTrue(eventsManager.EventsDictionary.ContainsKey("event1"));
            Assert.AreEqual(eventsManager.EventsDictionary["event1"].Count, 1);

            Assert.IsTrue(eventsManager.EventsOrderedByDate.ContainsKey(currentDateTime));
            Assert.AreEqual(eventsManager.EventsOrderedByDate[currentDateTime].Count, 1);
        }

        [Test]
        public void DeleteEventsByTitle_ShouldRemoveAllEventsWithTheGivenTitleAndReturnTheRightNumber()
        {
            var eventsManager = new ExtendedEventsManagerFast();

            var currentDateTime = DateTime.Now;
            var event1 = new Event(currentDateTime, "Event1");
            eventsManager.AddEvent(event1);

            var event2 = new Event(currentDateTime, "Event1", "sofia");
            eventsManager.AddEvent(event2);

            var event3 = new Event(currentDateTime, "Event3", "sofia");
            eventsManager.AddEvent(event3);

            int deleted = eventsManager.DeleteEventsByTitle("Event1");

            Assert.AreEqual(deleted, 2);
            Assert.IsFalse(eventsManager.EventsDictionary.ContainsKey("event1"));
            Assert.IsTrue(eventsManager.EventsDictionary.ContainsKey("event3"));

            var events = eventsManager.EventsOrderedByDate[currentDateTime];
            Assert.AreEqual(events.Count, 1);
            var onlyLeftEvent = events.FirstOrDefault();
            Assert.AreEqual(onlyLeftEvent.Title, "Event3");
        }

        [Test]
        public void DeleteEventsByTitle_ShouldReturnZeroWhenNoEventsWithThisName()
        {
            var eventsManager = new ExtendedEventsManagerFast();
            var currentDateTime = DateTime.Now;
            var event3 = new Event(currentDateTime, "Event3", "sofia");
            eventsManager.AddEvent(event3);

            int deleted = eventsManager.DeleteEventsByTitle("Event1");

            Assert.AreEqual(deleted, 0);
        }

        [Test]
        public void ListEvents_ShouldListAllNeededEventsAndShouldBeInTheCorrectFormat_WhenGivenNumberBiggerThanExistingEventsCount()
        {
            var eventsManager = new ExtendedEventsManagerFast();
            var currentDateTime = DateTime.Now;
            var event1 = new Event(currentDateTime, "Event1");
            eventsManager.AddEvent(event1);

            var event2 = new Event(currentDateTime, "Event1", "sofia");
            eventsManager.AddEvent(event2);

            var event3 = new Event(currentDateTime, "Event3", "sofia");
            eventsManager.AddEvent(event3);

            var events = eventsManager.ListEvents(currentDateTime, 4).ToArray();

            Assert.AreEqual(events.Length, 3);
            Assert.AreEqual(events[0].Title, "Event1");
            Assert.AreEqual(events[1].Title, "Event1");
            Assert.AreEqual(events[1].Location, "sofia");
            Assert.AreEqual(events[2].Title, "Event3");
            Assert.AreEqual(events[2].Location, "sofia");
        }

        [Test]
        public void ListEvents_ShouldListAllNeededEventsAndShouldBeInTheCorrectFormat_WhenGivenNumberLowerThanExistingEventsCount()
        {
            var eventsManager = new ExtendedEventsManagerFast();
            var currentDateTime = DateTime.Now;
            var event1 = new Event(currentDateTime, "Event1");
            eventsManager.AddEvent(event1);

            var event2 = new Event(currentDateTime, "Event1", "sofia");
            eventsManager.AddEvent(event2);

            var event3 = new Event(currentDateTime, "Event3", "sofia");
            eventsManager.AddEvent(event3);

            var events = eventsManager.ListEvents(currentDateTime, 2).ToArray();

            Assert.AreEqual(events.Length, 2);
            Assert.AreEqual(events[0].Title, "Event1");
            Assert.AreEqual(events[1].Title, "Event1");
            Assert.AreEqual(events[1].Location, "sofia");
        }
    }
}
