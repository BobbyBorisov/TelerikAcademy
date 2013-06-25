using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.BinaryPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfStars = 0;
            string line = Console.ReadLine();
            for (var j = 0; j < line.Length; j++) 
            {
                if (line[j] == '*') 
                {
                    countOfStars++;
                }
            }

            
            BigInteger raisedvalue = (BigInteger)Math.Pow(2, countOfStars);
            Console.WriteLine(raisedvalue);
        }
    }
}
