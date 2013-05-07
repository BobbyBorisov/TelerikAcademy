using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string courseName)
            : base(courseName, null)
        {
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName,students)
        {
            this.Lab = null;
        }

        public override string ToString()
        {
            var result = string.Empty;
            if (this.Lab != null)
            {
                result = "; Lab = " + this.Lab;
            }

           return base.ToString() + result + "}";
        }
    }
}
