using System;
using System.Globalization;
using System.Linq;

namespace OrganizerCore
{
    public class ConsoleComunicator : IComunicator
    {
        public string ReadStringData()
        {
            return Console.ReadLine();
        }

        public void DisplayMessage(string[] entryInfo)
        {
            foreach (string str in entryInfo)
            {
                Console.WriteLine(str);
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public DateTime ParseDate()
        {
            string datestring;
            var format = "dd MMMM yyyy H:mm";
            DateTime result;
            bool isParsed;

            do
            {
                // Format of the date is "dd MMMM yyyy H:mm"
                Console.WriteLine("Enter date (ex. 23 June 2013 15:00)");
                datestring = Console.ReadLine();
                isParsed = DateTime.TryParseExact(datestring, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            }
            while (!isParsed);

            return result;
        }
    }
}
