using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLooses
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPosition = Console.ReadLine();
            var endPosition = Console.ReadLine();
            var list = new List<int>();
            var forbiddenCombCount = int.Parse(Console.ReadLine());
            for (var j = 0; j < forbiddenCombCount; j++) 
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            var count = 0;
            for (var i = 0; i < 5; i++) 
            {
                var startPos = startPosition[i] - '0';
                var endPos = endPosition[i] - '0';

                count += Math.Min(Math.Abs(startPos - endPos), 10 -Math.Abs(startPos-endPos));
            }
            Console.WriteLine(count);
        }
    }
}
