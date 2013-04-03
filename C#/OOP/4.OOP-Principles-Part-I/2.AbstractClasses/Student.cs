using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Task
{
    class Student : Human
    {
        public int Grade { get; set; }

        public Student(string firstname, string lastname,int grade) 
            :base(firstname,lastname)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName + " "+ LastName + " "+Grade);
            return sb.ToString();
        }
    }
}
