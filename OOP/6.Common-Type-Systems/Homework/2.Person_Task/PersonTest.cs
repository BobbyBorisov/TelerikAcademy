using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person_Task
{
    class PersonTest
    {
        static void Main()
        {
            Person person = new Person("Bobby");
            Person person1 = new Person("Robby", 12);

            Console.WriteLine(person.ToString());
            Console.WriteLine(person1.ToString());
        }
    }
}
