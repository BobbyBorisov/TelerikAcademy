using System;
using System.Linq;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        public DateTime dateAndTime { get; set; }

        public string Title;
        public string Location;

        public Event(string title, string location, DateTime dateAndTime) 
        {
            this.Title = title;
            this.Location = location;
            this.dateAndTime = dateAndTime;
        }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";

            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.dateAndTime, this.Title, this.Location);

            return eventAsString;
        }

        public int CompareTo(Event x)
        {
            int res = DateTime.Compare(this.dateAndTime, x.dateAndTime);
            foreach (char c in this.Title)
            {
                if (res == 0)
                {
                    res = string.Compare(this.Title, x.Title, StringComparison.Ordinal);
                }

                if (res == 0)
                {
                    res = string.Compare(this.Location, x.Location, StringComparison.Ordinal);
                }
            }

            return res;
        }
    }
}
