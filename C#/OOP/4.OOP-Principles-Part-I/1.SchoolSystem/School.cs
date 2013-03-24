using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class School
    {
        public string Name { get; private set; }
        public List<Class> Classes { get; set; }

        public School(string name) {
            this.Name = name;
            this.Classes = new List<Class>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("School:" + this.Name);
            foreach (var c in this.Classes) {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
    }
}
