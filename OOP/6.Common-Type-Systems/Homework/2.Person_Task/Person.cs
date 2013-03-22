using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person_Task
{
    class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person(string name)
            : this(name, null) { }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: "+this.Name);
            sb.Append("Age: ");
            if (this.Age.HasValue)
            {
                sb.Append(this.Age.ToString());
            }
            else sb.Append("undefined");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
