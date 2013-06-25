using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Events
{
    public class EventsGenerator
    {
        static string[] eventTitles =
	{
		"party", "exam", "C# course", "C# exam (again)", "PARTY", "Chalga party",
		"party Lora", "party Kiro", "Exam", "EXAM", "Party LORA", "Rock party"
	};

        static string[] eventLocations =
	{
		"home", "at school", "Sofia", "sofia", "Home", "at home", "Kaspichan",
		"Telerik academy", "telerik academy", "Varna", "Plovdiv", null, null,
		null, null, null, null, null
	};

        static DateTime[] eventDates =
	{
		new DateTime(2000, 1, 1, 0, 0, 0),
		new DateTime(2001, 1, 1, 0, 0, 0),
		new DateTime(2001, 1, 1, 10, 0, 0),
		new DateTime(2001, 1, 1, 10, 30, 0),
		new DateTime(2001, 1, 1, 10, 30, 1),
		new DateTime(2001, 1, 1, 10, 30, 2),
		new DateTime(2001, 1, 1, 10, 30, 3),
		new DateTime(2001, 1, 1, 11, 0, 0),
		new DateTime(2001, 1, 1, 11, 30, 0),
		new DateTime(2001, 1, 1, 12, 0, 0),
		new DateTime(2001, 1, 1, 16, 0, 0),
		new DateTime(2001, 1, 1, 20, 0, 0),
		new DateTime(2001, 1, 1, 22, 0, 0),
		new DateTime(2001, 1, 1, 22, 30, 0),
		new DateTime(2001, 2, 1, 0, 0, 0),
		new DateTime(2012, 3, 31, 23, 59, 57),
		new DateTime(2012, 3, 31, 23, 59, 58),
		new DateTime(2012, 3, 31, 23, 59, 59),
		new DateTime(2019, 1, 1, 0, 0, 0),
	};

        static Random rnd = new Random();
        const string DateFormat = "yyyy-MM-ddTHH:mm:ss";
        static List<string> commands = new List<string>();

        static void Main()
        {
            GenerateRandomListCommands(10);
            GenerateRandomAddCommands(1000);
            GenerateInvalidListCommands(10);
            GenerateRandomListCommands(10);
            GenerateRandomAddCommands(5000);
            GenerateInvalidListCommands(10);
            GenerateRandomListCommands(10);
            GenerateRandomAddCommands(15000);
            GenerateRandomListCommands(20);
            DuplicateAllCommands();
            DuplicateAllCommands();
            GenerateRandomListCommands(50);
            GenerateRandomDeleteCommands(10000);
            GenerateRandomListCommands(50);
            GenerateInvalidListCommands(100);
            AppendEndCommand();

            PrintCommands();
        }

        private static void GenerateRandomAddCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomAddCommand();
            }
        }

        private static void GenerateRandomAddCommand()
        {
            string title = GenerateRandomTitle();
            string location = GenerateRandomLocation();
            DateTime date = GenerateRandomDate();

            // Generate AddEvent command
            string addEventCommandFormat = "AddEvent {0:" + DateFormat + "} | {1}";
            if (location != null)
            {
                addEventCommandFormat += " | {2}";
            }
            string addEventCommand =
                String.Format(addEventCommandFormat, date, title, location);

            commands.Add(addEventCommand);
        }

        private static string GenerateRandomTitle()
        {
            string title = eventTitles[rnd.Next(eventTitles.Length)];
            if (rnd.Next(3) == 0)
            {
                title += " - " + rnd.Next(1000000);
            }
            return title;
        }

        private static string GenerateRandomLocation()
        {
            string location = eventLocations[rnd.Next(eventLocations.Length)];
            if (rnd.Next(5) == 0)
            {
                location += " - " + rnd.Next(1000000);
            }
            return location;
        }

        private static DateTime GenerateRandomDate()
        {
            DateTime date = eventDates[rnd.Next(eventDates.Length)];
            if (rnd.Next(5) == 0)
            {
                date.AddSeconds(rnd.Next(1000000));
            }
            return date;
        }

        private static void DuplicateAllCommands()
        {
            commands.AddRange(commands);
        }

        private static void GenerateRandomDeleteCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomDeleteCommand();
            }
        }

        private static void GenerateRandomDeleteCommand()
        {
            string title = GenerateRandomTitle();
            string deleteEventsCommand = "DeleteEvents " + title;
            commands.Add(deleteEventsCommand);
        }

        private static void GenerateRandomListCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomListCommand();
            }
        }

        private static void GenerateRandomListCommand()
        {
            DateTime date = GenerateRandomDate();
            string eventFormat = "{0:" + DateFormat + "} | {1}";
            int count = rnd.Next(1, 20);
            string listEventsCommandFormat = "ListEvents {0:" + DateFormat + "} | {1}";
            string listEventsCommand =
                String.Format(listEventsCommandFormat, date, count);
            commands.Add(listEventsCommand);
        }

        private static void GenerateInvalidListCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateInvalidListCommand();
            }
        }

        private static void GenerateInvalidListCommand()
        {
            DateTime date = new DateTime(2019, 11, 11, 11, 11, 11);
            string eventFormat = "{0:" + DateFormat + "} | {1}";
            int count = rnd.Next(50, 100);
            string listEventsCommandFormat = "ListEvents {0:" + DateFormat + "} | {1}";
            string listEventsCommand =
                String.Format(listEventsCommandFormat, date, count);
            commands.Add(listEventsCommand);
        }

        private static void AppendEndCommand()
        {
            commands.Add("End");
        }

        private static void PrintCommands()
        {
            foreach (var cmd in commands)
            {
                Console.WriteLine(cmd);
            }
        }
    }
}
