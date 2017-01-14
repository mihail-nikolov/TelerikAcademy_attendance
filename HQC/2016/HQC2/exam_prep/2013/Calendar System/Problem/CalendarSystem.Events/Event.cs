using System;

namespace CalendarSystem.Events
{
    public class Event : IComparable<Event>
    {
        public Event(DateTime date, string title, string location = null)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }
            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event eventToCompare)
        {
            // bottleneck in multidictionary shit
            int result = DateTime.Compare(this.Date, eventToCompare.Date);

            if (result == 0)
            {
                result = string.Compare(this.Title, eventToCompare.Title);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, eventToCompare.Location, StringComparison.InvariantCultureIgnoreCase);
            }
            return result;
            //foreach (char c in this.Title)
            //{
            //    if (result == 0)
            //    {
            //        result = string.Compare(this.Title, eventToCompare.Title, StringComparison.Ordinal);
            //    }

            //    if (result == 0)
            //    {
            //        result = string.Compare(this.Location, eventToCompare.Location, StringComparison.Ordinal);
            //    }
            //}
        }
    }
}
