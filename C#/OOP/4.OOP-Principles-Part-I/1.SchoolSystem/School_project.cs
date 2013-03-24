using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_project
{
    class School_project
    {
        static void Main() {

            Class firstClass = new Class("8b");
            School school = new School("My school");
            school.Classes.Add(firstClass);
            //Console.WriteLine(school.ToString());
            firstClass.FillWithStudents();

            Teacher Joreto = new Teacher("Joreto");
            Joreto.Disciplines.Add(new Discipline("Math", 1, 1));
            Joreto.Disciplines.Add(new Discipline("Physic", 2, 3));
            Joreto.Disciplines.Add(new Discipline("Drawing", 3, 3));

            Teacher Pesho = new Teacher("Pesho");
            Pesho.Disciplines.Add(new Discipline("Math", 1, 1));
            Pesho.Disciplines.Add(new Discipline("Physic", 2, 3));

            firstClass.Teachers.Add(Joreto);
            firstClass.Teachers.Add(Pesho);
            Console.WriteLine("Teacher");
            Console.WriteLine(firstClass.Teachers.ToString());


            
            Console.WriteLine(firstClass.ToString());
            Console.WriteLine("end of haha");
            Console.WriteLine(school.ToString());

            Console.WriteLine(school.Classes[0].Teachers[0].ToString());
        }
    }
}
