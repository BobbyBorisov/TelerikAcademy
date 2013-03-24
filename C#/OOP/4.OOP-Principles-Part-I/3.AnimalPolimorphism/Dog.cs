using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    class Dog : Animal
    {

        public override void Sound()
        {
            Console.WriteLine("Bau-bau");
        }

        public Dog(string name,Sex sex, int age) {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    
       
}
}
