using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public class EventManager : IEventsManager
    {
        private readonly List<Event> list = new List<Event>();

        public void AddEvent(Event e)
        {
            this.list.Add(e);
        }
        public int DeleteEventsByTitle(string t)
        {
            return this.list.RemoveAll(
                e => e.Title.ToLowerInvariant() == t.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime d, int c)
        {
            return (from e in this.list
                    where e.dateAndTime >= d
                    orderby e.dateAndTime, e.Title, e.Location
                    select e).Take(c);

        }
    }
}
