using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    class Frog: Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Quaaak, Im a frog");
        }


        public Frog(string name, Sex sex, int age) {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }
}
