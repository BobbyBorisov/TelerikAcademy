using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class AdvancedEventManager : IEventsManager
    {
        private readonly MultiDictionary<string, Event> titles = new MultiDictionary<string, Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> dates = new OrderedMultiDictionary<DateTime, Event>(true);

        public int Count 
        {
            get 
            {
                return this.titles.Count;
            }
        }
        public void AddEvent(Event eventItem)
        {
            string eventTitleLowerCase = eventItem.Title.ToLowerInvariant();
            this.titles.Add(eventTitleLowerCase, eventItem);
            this.dates.Add(eventItem.dateAndTime, eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLowerInvariant();
            var foundEvents = this.titles[titleToLower];

            if (this.titles.Count <= 0) 
            {
                throw new ArgumentException("Events list is empty");
            }

            if (foundEvents.Count <= 0) 
            {
                throw new ArgumentException("Event is not found");
            }

            int deletedEvents = foundEvents.Count;

            foreach (var eventItem in foundEvents)
            {
                this.dates.Remove(eventItem.dateAndTime, eventItem);
            }

            this.titles.Remove(titleToLower);

            return deletedEvents;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            IEnumerable<Event> contentToList = from c in this.dates[date] select c;

            return contentToList.Take(count);
        }
    }
}
