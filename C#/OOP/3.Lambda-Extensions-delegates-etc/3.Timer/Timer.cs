using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Timer
{
    //TODO HOMEWORK LINQ TASK 7 DONE
    public delegate void MyDelegate(int seconds);
    class Timer
    {
        public static void ShowMe(int seconds)
        {
            while (true)
            {
                Console.WriteLine("Invoking");
                System.Threading.Thread.Sleep(1000 * seconds);
            }
        }
        static void Main(string[] args)
        {
            MyDelegate d = ShowMe;
            Console.Write("Enter value for the timer:");
            int timer = int.Parse(Console.ReadLine());
            d(timer);
            
        }
    }
}
