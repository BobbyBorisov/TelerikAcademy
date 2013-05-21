using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        void AddEvent(Event e);
        int DeleteEventsByTitle(string title);
        IEnumerable<Event> ListEvents(DateTime c, int d);
    }
}
