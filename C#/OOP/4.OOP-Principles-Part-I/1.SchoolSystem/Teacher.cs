using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class Teacher:People
    {
        public List<Discipline> Disciplines {get;set;}

        public Teacher(string name) 
            : base(name) 
        {
            this.Disciplines= new List<Discipline>();
        }
        
        public  void FillWithDisciplines() {
            for (int i = 69; i < 75; i++)
            {
                Discipline d = new Discipline(i.ToString(), i-10, i-30);
                this.Disciplines.Add(d);
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Disciplines of teacher:"+this.Name);
            foreach (var d in Disciplines)
            {
                sb.AppendLine("-->" + d.Name+ ", " +d.Exercises_count + " E, " + d.Lectures_count+" L.");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
