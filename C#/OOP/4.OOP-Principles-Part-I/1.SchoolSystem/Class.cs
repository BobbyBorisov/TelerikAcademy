using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class Class
    {
        public string Id { get; private set; }
        public List<Teacher> Teachers {get;set;}
        public List<Student> Students {get;set;}

        public Class(string id){
            this.Id = id;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }

        List<string> temp_teacher_names = new List<string>() { "teacher1", "teacher2", "teacher3" };

        public void FillWithTeachers() {
           foreach(var n in temp_teacher_names){
            Teacher t = new Teacher(n);
            this.Teachers.Add(t);
           }
        }

        List<string> temp_student_names = new List<string>() { "student1", "student2", "student3" };

        public void FillWithStudents()
        {
            foreach (var n in temp_student_names)
            {
                Student s = new Student(n, 1);
                this.Students.Add(s);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-----Class #"+this.Id+"-----");
            sb.Append("\nTeachers:");
            foreach (var t in this.Teachers) {
                sb.AppendLine(t.ToString());
            }
            sb.AppendLine("\nStudents:");
            foreach (var s in this.Students)
            {
                sb.AppendLine(s.Id + s.Name);
            }
            return sb.ToString();
        }
    }
}
