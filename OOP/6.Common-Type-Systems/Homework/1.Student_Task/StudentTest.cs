using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Student_Task
{
    class StudentTest
    {

        static void Main()
        {

            Student s1 = new Student("Borislav", "Borisov", 6004399);
            Console.WriteLine(s1.ToString());

            Student s2 = new Student("Ivan", "Borisov", 600123);
            
            //Hashcode of student 1
            Console.WriteLine(s2.GetHashCode());

            //Doing shadow clone of s1
            Student s3 = (Student)s1.Clone();
            s3.FirstName = "Robert";

            Console.WriteLine(s1.ToString());
            Console.WriteLine(s3.ToString());

            int result = s1.CompareTo(s3);
            if (result < 0)
            {
                Console.WriteLine("s1 is smaller");
            }
            else if (result > 0)
            {
                Console.WriteLine("s2 is smaller");
            }
            else
            {
                Console.WriteLine("they are equal");
            }
            Console.WriteLine(s1 == s2);
        }
    }
}
