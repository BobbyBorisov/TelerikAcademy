using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using System.Globalization;

namespace Problem_1___Events
{
    class Events
    {
        //private static EventsProcessorSlow eventsProcessor = new EventsProcessorSlow();
        private static EventsProcessorFast eventsProcessor = new EventsProcessorFast();
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            ProcessAllCommands();
            PrintCollectedOutput();
        }

        private static void ProcessAllCommands()
        {
            while (true)
            {
                string commandText = Console.ReadLine();
                if (commandText == "End" || commandText == null)
                {
                    // The sequence of commands is finished
                    break;
                }
                try
                {
                    ProcessCommand(commandText);
                }
                catch (Exception ex)
                {
                    Print("Unhandled exception: " + ex);
                }
            }
        }

        private static void PrintCollectedOutput()
        {
            Console.Write(output);
        }

        private static void ProcessCommand(string commandText)
        {
            // Parse the command and its arguments
            int spaceIndex = commandText.IndexOf(' ');
            if (spaceIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }
            string command = commandText.Substring(0, spaceIndex);
            string argumentsStr = commandText.Substring(spaceIndex + 1);
            string[] arguments = argumentsStr.Split('|');
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            // Execute the parsed command
            if ((command == "AddEvent") && ((arguments.Length == 2) || (arguments.Length == 3)))
            {
                ProcessAddEventCommand(arguments);
            }
            else if ((command == "DeleteEvents") && (arguments.Length == 1))
            {
                ProcessDeleteEventsCommand(arguments);
            }
            else if ((command == "ListEvents") && (arguments.Length == 2))
            {
                ProcessListEventsCommand(arguments);
            }
            else
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }
        }

        private static void ProcessAddEventCommand(string[] arguments)
        {
            Event e = new Event();
            e.Date = DateTime.ParseExact(
                arguments[0], Event.DateFormat, CultureInfo.InvariantCulture);
            e.Title = arguments[1];
            if (arguments.Length == 3)
            {
                e.Location = arguments[2];
            }

            eventsProcessor.AddEvent(e);

            Print("Event added");
        }

        private static void ProcessDeleteEventsCommand(string[] arguments)
        {
            string eventTitle = arguments[0];
            int deletedCount = eventsProcessor.DeleteEventsByTitle(eventTitle);
            if (deletedCount > 0)
            {
                Print("" + deletedCount + " events deleted");
            }
            else
            {
                Print("No events found");
            }
        }

        private static void ProcessListEventsCommand(string[] arguments)
        {
            DateTime date = DateTime.ParseExact(
                arguments[0], Event.DateFormat, CultureInfo.InvariantCulture);
            string countStr = arguments[1];
            int count = int.Parse(countStr);

            IEnumerable<Event> events = eventsProcessor.ListEvents(date, count);

            if (events.FirstOrDefault() != null)
            {
                foreach (var e in events)
                {
                    string eventStr = e.ToString();
                    Print(eventStr);
                }
            }
            else
            {
                Print("No events found");
            }
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }

    class Event : IComparable<Event>
    {
        public const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            string eventFormat = "{0:" + DateFormat + "} | {1}";
            if (Location != null)
            {
                eventFormat += " | {2}";
            }
            string eventAsString =
                String.Format(eventFormat, Date, Title, Location);
            return eventAsString;
        }

        public int CompareTo(Event other)
        {
            int compareResult = DateTime.Compare(this.Date, other.Date);
            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Title, other.Title);
            }
            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, other.Location);
            }
            return compareResult;
        }
    }

    class EventsProcessorSlow
    {
        private List<Event> events = new List<Event>();

        public void AddEvent(Event e)
        {
            this.events.Add(e);
        }

        public int DeleteEventsByTitle(string eventTitle)
        {
            string eventTitleLower = eventTitle.ToLowerInvariant();
            int deletedCount = this.events.RemoveAll(
                e => e.Title.ToLowerInvariant() == eventTitleLower);
            return deletedCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var matchedEvents =
                from e in this.events
                where e.Date >= date
                orderby e.Date, e.Title, e.Location
                select e;
            var limitedMatchedEvents = matchedEvents.Take(count);
            return limitedMatchedEvents;
        }
    }

    class EventsProcessorFast
    {
        private MultiDictionary<string, Event> eventsByTitle =
            new MultiDictionary<string, Event>(true);
        private OrderedMultiDictionary<DateTime, Event> eventsByDate =
            new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event e)
        {
            string eventTitleLowerCase = e.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, e);
            this.eventsByDate.Add(e.Date, e);
        }

        public int DeleteEventsByTitle(string eventTitle)
        {
            string eventTitleLowerCase = eventTitle.ToLowerInvariant();
            var eventsToDelete = this.eventsByTitle[eventTitleLowerCase];
            int deletedCount = eventsToDelete.Count;

            // Delete from this.eventsByDate
            foreach (var e in eventsToDelete)
            {
                this.eventsByDate.Remove(e.Date, e);
            }

            // Delete from this.eventsByTitle
            this.eventsByTitle.Remove(eventTitleLowerCase);

            return deletedCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var matchedEvents =
                from e in this.eventsByDate.RangeFrom(date, true).Values
                select e;
            var limitedMatchedEvents = matchedEvents.Take(count);
            return limitedMatchedEvents;
        }
    }
}
