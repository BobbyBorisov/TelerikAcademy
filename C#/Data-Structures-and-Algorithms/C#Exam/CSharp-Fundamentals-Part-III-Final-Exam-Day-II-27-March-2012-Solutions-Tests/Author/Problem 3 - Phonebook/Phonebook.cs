using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Problem_3___Phonebook
{
    public class Phonebook
    {
        private const string DefaultPhonePrefix = "+359";

        //private static PhonebookRepositorySlow phoneBook = new PhonebookRepositorySlow();
        private static PhonebookRepositoryFast phoneBook = new PhonebookRepositoryFast();
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
                ProcessCommand(commandText);
            }
        }

        private static void ProcessCommand(string commandText)
        {
            // Parse the command and its arguments
            int colonIndex = commandText.IndexOf('(');
            if (colonIndex == -1)
            {
                throw new ArgumentException("Invalid command format: " + commandText);
            }
            string command = commandText.Substring(0, colonIndex);
            if (!commandText.EndsWith(")"))
            {
                throw new ArgumentException("Invalid command format: " + commandText);
            }
            string argumentsStr = commandText.Substring(
                colonIndex + 1, commandText.Length - colonIndex - 2);
            string[] arguments = argumentsStr.Split(',');
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            // Execute the parsed command
            if ((command.StartsWith("AddPhone")) && (arguments.Length >= 2))
            {
                ProcessAddPhoneCommand(arguments);
            }
            else if ((command == "ChangePhone") && (arguments.Length == 2))
            {
                ProcessChangePhoneCommand(arguments);
            }
            else if ((command == "List") && (arguments.Length == 2))
            {
                ProcessListCommand(arguments);
            }
            else
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }
        }

        private static void ProcessAddPhoneCommand(string[] arguments)
        {
            string name = arguments[0];
            var phones = arguments.Skip(1).ToList();
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i] = ConvertPhoneToCannonicalForm(phones[i]);
            }

            bool isNewEntry = phoneBook.AddPhone(name, phones);
            if (isNewEntry)
            {
                Print("Phone entry created");
            }
            else
            {
                Print("Phone entry merged");
            }
        }

        private static void ProcessChangePhoneCommand(string[] arguments)
        {
            string oldPhoneNumber = ConvertPhoneToCannonicalForm(arguments[0]);
            string newPhoneNumber = ConvertPhoneToCannonicalForm(arguments[1]);
            int updatedCount = phoneBook.ChangePhone(oldPhoneNumber, newPhoneNumber);
            Print("" + updatedCount + " numbers changed");
        }

        private static void ProcessListCommand(string[] arguments)
        {
            int startIndex = int.Parse(arguments[0]);
            int count = int.Parse(arguments[1]);

            try
            {
                IEnumerable<PhonebookEntry> entries =
                    phoneBook.ListEntries(startIndex, count);
                foreach (var entry in entries)
                {
                    string entryStr = entry.ToString();
                    Print(entryStr);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Print("Invalid range");
            }
        }

        public static string ConvertPhoneToCannonicalForm(string phoneNumber)
        {
            // Skip all non-digit characters except '+'
            // (+359) 888 999 111 --> +359888999111
            StringBuilder cannonicalPhoneBuilder = new StringBuilder();
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    cannonicalPhoneBuilder.Append(ch);
                }
            }

            if (cannonicalPhoneBuilder.Length >= 2 &&
                cannonicalPhoneBuilder[0] == '0' && cannonicalPhoneBuilder[1] == '0')
            {
                // The phone number starts with "00", replace it with "+"
                // 00359888999111 --> +359888999111
                cannonicalPhoneBuilder.Remove(0, 1);
                cannonicalPhoneBuilder[0] = '+';
            }

            while (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] == '0')
            {
                // Remove any leading zeros
                // 0894778899 --> 894778899
                cannonicalPhoneBuilder.Remove(0, 1);
            }

            if (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] != '+')
            {
                // Insert the default country code the first char is not "+"
                // 894778899 --> +359894778899
                cannonicalPhoneBuilder.Insert(0, DefaultPhonePrefix);
            }

            string cannonicalPhoneNumber = cannonicalPhoneBuilder.ToString();
            return cannonicalPhoneNumber;
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }

        private static void PrintCollectedOutput()
        {
            Console.Write(output);
        }
    }

    class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameLowerCase;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.nameLowerCase = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Phones;

        public override string ToString()
        {
            StringBuilder entryBuilder = new StringBuilder();
            entryBuilder.Append('[');
            entryBuilder.Append(this.Name);
            bool firstPhone = true;
            foreach (var phone in this.Phones)
            {
                if (firstPhone)
                {
                    entryBuilder.Append(": ");
                    firstPhone = false;
                }
                else
                {
                    entryBuilder.Append(", ");
                }
                entryBuilder.Append(phone);
            }
            entryBuilder.Append(']');
            return entryBuilder.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameLowerCase.CompareTo(other.nameLowerCase);
        }
    }

    class PhonebookRepositorySlow
    {
        private List<PhonebookEntry> entries = new List<PhonebookEntry>();

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var existingEntries =
                from e in this.entries
                where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select e;

            bool isNewEntry;
            if (existingEntries.Count() == 0)
            {
                PhonebookEntry newEntry = new PhonebookEntry();
                newEntry.Name = name;
                newEntry.Phones = new SortedSet<string>();
                foreach (var phoneNumber in phoneNumbers)
                {
                    newEntry.Phones.Add(phoneNumber);
                }
                this.entries.Add(newEntry);
                isNewEntry = true;
            }
            else if (existingEntries.Count() == 1)
            {
                PhonebookEntry existingEntry = existingEntries.First();
                foreach (var phoneNumber in phoneNumbers)
                {
                    existingEntry.Phones.Add(phoneNumber);
                }
                isNewEntry = false;
            }
            else
            {
                throw new InvalidOperationException("Duplicated name in the phonebook found: " + name);
            }

            return isNewEntry;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var matchedEntries =
                from e in this.entries
                where e.Phones.Contains(oldPhoneNumber)
                select e;

            int changedCount = 0;
            foreach (var entry in matchedEntries)
            {
                entry.Phones.Remove(oldPhoneNumber);
                entry.Phones.Add(newPhoneNumber);
                changedCount++;
            }

            return changedCount;
        }

        public PhonebookEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();
            PhonebookEntry[] matchedEntries = new PhonebookEntry[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhonebookEntry entry = this.entries[i];
                matchedEntries[i - startIndex] = entry;
            }
            return matchedEntries;
        }
    }

    class PhonebookRepositoryFast
    {
        private OrderedSet<PhonebookEntry> entriesSorted =
            new OrderedSet<PhonebookEntry>();
        private Dictionary<string, PhonebookEntry> entriesByName =
            new Dictionary<string, PhonebookEntry>();
        private MultiDictionary<string, PhonebookEntry> entriesByPhone =
            new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            // Create / find the phonebook entry
            string nameLowercase = name.ToLowerInvariant();
            PhonebookEntry entry;
            bool isNewEntry = !this.entriesByName.TryGetValue(nameLowercase, out entry);
            if (isNewEntry)
            {
                entry = new PhonebookEntry();
                entry.Name = name;
                entry.Phones = new SortedSet<string>();
                this.entriesByName.Add(nameLowercase, entry);
                this.entriesSorted.Add(entry);
            }

            // Add the entry by phone
            foreach (var phoneNumber in phoneNumbers)
            {
                this.entriesByPhone.Add(phoneNumber, entry);
            }

            // Add / merge the phone numbers
            entry.Phones.UnionWith(phoneNumbers);

            return isNewEntry;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var matchedEntries = this.entriesByPhone[oldPhoneNumber].ToList();
            foreach (var entry in matchedEntries)
            {
                entry.Phones.Remove(oldPhoneNumber);
                this.entriesByPhone.Remove(oldPhoneNumber, entry);
                entry.Phones.Add(newPhoneNumber);
                this.entriesByPhone.Add(newPhoneNumber, entry);
            }
            return matchedEntries.Count;
        }

        public PhonebookEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            PhonebookEntry[] matchedEntries = new PhonebookEntry[count];
            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhonebookEntry entry = this.entriesSorted[i];
                matchedEntries[i - startIndex] = entry;
            }
            return matchedEntries;
        }
    }
}
