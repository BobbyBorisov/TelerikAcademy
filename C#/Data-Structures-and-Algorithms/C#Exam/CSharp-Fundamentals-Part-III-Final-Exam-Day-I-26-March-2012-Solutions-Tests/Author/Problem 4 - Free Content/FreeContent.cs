using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Wintellect.PowerCollections;

namespace Problem_4___Free_Content
{
    class FreeContent
    {
        //private static CatalogSlow catalog = new CatalogSlow();
        private static CatalogFast catalog = new CatalogFast();
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
            int colonIndex = commandText.IndexOf(':');
            if (colonIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }
            string command = commandText.Substring(0, colonIndex);
            string argumentsStr = commandText.Substring(colonIndex + 1);
            string[] arguments = argumentsStr.Split(';');
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = arguments[i].Trim();
            }

            // Execute the parsed command
            if ((command.StartsWith("Add ")) && (arguments.Length == 4))
            {
                ProcessAddItemCommand(command, arguments);
            }
            else if ((command == "Update") && (arguments.Length == 2))
            {
                ProcessUpdateItemCommand(arguments);
            }
            else if ((command == "Find") && (arguments.Length == 2))
            {
                ProcessFindItemsCommand(arguments);
            }
            else
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }
        }

        private static void ProcessAddItemCommand(string command, string[] arguments)
        {
            Item item = new Item();
            item.Type = command.Substring("Add ".Length);
            item.Type = char.ToUpper(item.Type[0]) + item.Type.Substring(1);
            item.Title = arguments[0];
            item.Author = arguments[1];
            item.Size = long.Parse(arguments[2]);
            item.Url = arguments[3];
            catalog.AddItem(item);
            Print(item.Type + " added");
        }

        private static void ProcessUpdateItemCommand(string[] arguments)
        {
            string oldUrl = arguments[0];
            string newUrl = arguments[1];
            int updatedCount = catalog.UpdateItemsUrl(oldUrl, newUrl);
            Print("" + updatedCount + " items updated");
        }

        private static void ProcessFindItemsCommand(string[] arguments)
        {
            string title = arguments[0];
            int count = int.Parse(arguments[1]);

            IEnumerable<Item> items = catalog.FindItemsByTitle(title, count);

            if (items.FirstOrDefault() != null)
            {
                foreach (var item in items)
                {
                    string itemStr = item.ToString();
                    Print(itemStr);
                }
            }
            else
            {
                Print("No items found");
            }
        }

        private static void Print(string text)
        {
            output.AppendLine(text);
        }
    }

    class Item : IComparable<Item>
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            string itemFormat = "{0}: {1}; {2}; {3}; {4}";
            string itemAsString = String.Format(itemFormat,
                this.Type, this.Title, this.Author, this.Size, this.Url);
            return itemAsString;
        }

        public int CompareTo(Item other)
        {
            int compareResult = string.Compare(this.ToString(), other.ToString());
            return compareResult;
        }
    }

    class CatalogSlow
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public int UpdateItemsUrl(string oldUrl, string newUrl)
        {
            int updatedCount = 0;
            var itemsToUpdate = this.items.Where(item => item.Url == oldUrl);
            foreach (var item in itemsToUpdate)
            {
                item.Url = newUrl;
                updatedCount++;
            }
            return updatedCount;
        }

        public IEnumerable<Item> FindItemsByTitle(string title, int count)
        {
            var matchedItems =
                from item in this.items
                where item.Title == title
                orderby item.ToString()
                select item;
            var limitedMatchedItems = matchedItems.Take(count);
            return limitedMatchedItems;
        }
    }

    class CatalogFast
    {
        OrderedMultiDictionary<string, Item> itemsByTitle =
            new OrderedMultiDictionary<string, Item>(true);
        MultiDictionary<string, Item> itemsByUrl =
            new MultiDictionary<string, Item>(true);

        public void AddItem(Item item)
        {
            this.itemsByTitle.Add(item.Title, item);
            this.itemsByUrl.Add(item.Url, item);
        }

        public int UpdateItemsUrl(string oldUrl, string newUrl)
        {
            // Find the items to update
            var itemsToUpdate = this.itemsByUrl[oldUrl].ToList();

            // Remove all items mathing the old URL
            this.itemsByUrl.Remove(oldUrl);
            foreach (var item in itemsToUpdate)
            {
                this.itemsByTitle.Remove(item.Title, item);
            }

            // Add the removed items with the new URL
            foreach (var item in itemsToUpdate)
            {
                item.Url = newUrl;
                this.AddItem(item);
            }
            return itemsToUpdate.Count;
        }

        public IEnumerable<Item> FindItemsByTitle(string title, int count)
        {
            var matchedItems = this.itemsByTitle[title].ToList();
            var limitedMatchedItems = matchedItems.Take(count);
            return limitedMatchedItems;
        }
    }
}
