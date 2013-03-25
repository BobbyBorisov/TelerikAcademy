using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OrganizerCore
{
    internal static class Parser
    {
        internal static DateTime ParseDate()
        {
            string datestring;
            var format = "dd MMMM yyyy H:mm";
            DateTime result;
            bool isParsed;

            do
            {
                //Format of the date is "dd MMMM yyyy H:mm"
                Console.WriteLine("Enter date (ex. 23 June 2013 15:00)");
                datestring = Console.ReadLine();
                isParsed = DateTime.TryParseExact(datestring, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            } while (!isParsed);

            return result;
        }
    }
}
