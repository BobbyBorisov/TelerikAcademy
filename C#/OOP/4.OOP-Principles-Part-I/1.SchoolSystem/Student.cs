using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class Student: People
    {
        public int Id { get; private set; }

        public Student(string name, int id)
            : base(name) 
        {
            this.Id = id;
        }
    }
}
