using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    class Kitten: Cat
    {
        public override void Sound()
        {
            Console.WriteLine("Miiiiiiaaauuu, Im a kitten");
        }

        public Kitten(string name,int age) {
            this.Name = name;
            this.Sex = Sex.Female;
            this.Age = age;
        }
    }
}
