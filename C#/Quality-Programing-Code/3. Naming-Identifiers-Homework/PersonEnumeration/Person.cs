using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonEnumeration
{
    class Person
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Name:"+this.Name);
            sb.AppendLine("Age:" + this.Age);
            sb.AppendLine("Sex:" + this.Sex);

            return sb.ToString();
        }
    }
}
