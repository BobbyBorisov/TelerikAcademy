using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    class Tomcat: Cat
    {

        public override void Sound()
        {
            Console.WriteLine("Miayyyyy, Im a Tomcat");
        }

        public Tomcat(string name,int age) {
            this.Name = name;
            this.Sex = Sex.Male;
            this.Age = age;

        }

        
    }
}
