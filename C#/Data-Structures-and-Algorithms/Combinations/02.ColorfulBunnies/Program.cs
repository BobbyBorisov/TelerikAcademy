using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ColorfulBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunniesCount = int.Parse(Console.ReadLine());

            var result = 0;
            for (var i = 0; i < bunniesCount; i++) 
            {
                result += int.Parse(Console.ReadLine());
            }

            result++;
            Console.WriteLine(result);
        }
    }
}
