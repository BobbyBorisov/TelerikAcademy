using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OutOfRangeExeption
{

    class ExeptionExample
    {
        public static DateTime ParseDate()
        {
            string datestring;
            var format = "dd MMMM yyyy H:mm";
            DateTime result;
            bool isParsed;

            do
            {
                //Format of the date is "dd MMMM yyyy H:mm"
                Console.WriteLine("Example date:23 June 2013 15:00)");
                datestring = Console.ReadLine();
                isParsed = DateTime.TryParseExact(datestring, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            } while (!isParsed);

            return result;
        }

        static void Main() {
            int start = 0;
            int end = 100;
            try
            {
                Console.WriteLine("Enter number in range[{0}...{1}]",start,end);
                int number = int.Parse(Console.ReadLine());

                if (number < start || number > end) {
                    throw new OutOfRangeExeption<int>(start, end, "Your number is out of range");
                }
                Console.WriteLine("Successfull input!");
            }
            catch (OutOfRangeExeption<int> ex)
            {
                Console.WriteLine("{0}.Range is [{1} .. {2}]",ex.Message,ex.Start,ex.Stop);
            }

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddMinutes(60);

            try
            {
                Console.WriteLine("\nEnter Date in range[{0}...{1}]",startDate,endDate);
                var date = ExeptionExample.ParseDate();
                if (date < startDate || date > endDate) {
                    throw new OutOfRangeExeption<DateTime>(startDate, endDate, "Your date is out of range");
                }
                Console.WriteLine("Successfull input!");
            }
            catch (OutOfRangeExeption<DateTime> ex)
            {
                Console.WriteLine("{0}.\nRange is [{1} .. {2}]", ex.Message, ex.Start, ex.Stop);
            }
        }
    }
}
