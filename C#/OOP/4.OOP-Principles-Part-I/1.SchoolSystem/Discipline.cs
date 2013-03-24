using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class Discipline
    {
        public string Name { get; set; }
        public int Lectures_count { get; set; }
        public int Exercises_count { get; set; }

        public Discipline(string name, int lectures_count, int exercises_count) {
            this.Name = name;
            this.Lectures_count = lectures_count;
            this.Exercises_count = exercises_count;
        }

        
    }
}
