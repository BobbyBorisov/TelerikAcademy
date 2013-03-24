using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Task
{
    class AbstractExample
    {
        static void Main() {


            var students = new Student[] 
            {
                new Student("Borislav","Borisov",5),
                new Student("Pesho","Ivanov",4),
                new Student("Ivan","Ivanov",6),
                new Student("Petur","Stoev",1),
                new Student("Ivan","Draganov",6),
                new Student("Dragan","Petkanov",3),
                new Student("Joro","Georgiev",8)
            };

            var sortedStudents = students.OrderBy(s => s.Grade);
            foreach (var item in sortedStudents) {
                Console.WriteLine(item);
            }

            var workers = new Worker[] 
            {
                new Worker("Rosen","Borisov",500,10),
                new Worker("Worker2","Ivanov",422,6),
                new Worker("Worker3","Ivanov",600,7),
                new Worker("Petur","Worker5",100,6),
                new Worker("Georgi","Draganov",600,10),
                new Worker("Hary","Petkanov",300,5),
                new Worker("Joro","Georgiev",800,6)
            };

            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());

            Console.WriteLine("merged:");
            List<Human> allhumans = new List<Human>();
            
            var haha  = allhumans.Concat(sortedWorkers).Concat(sortedStudents);
            
            var mergedandsorted = haha.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var h in mergedandsorted) {
                Console.WriteLine(h);
            }
           
        }
    }
}
