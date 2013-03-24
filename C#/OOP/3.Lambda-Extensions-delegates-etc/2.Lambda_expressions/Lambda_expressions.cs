using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Lambda_expressions
{
    class Lambda_expressions
    {
        static void Main(string[] args)
        {
            var studentTest = new[]
		{
			new { firstname = "Borislav", lastname = "Borisov", age = 15 },
            new { firstname = "Galina", lastname = "Mihaylova", age = 22 }, 
			new { firstname = "Robert", lastname = "Borisov" , age = 24} 
		};


            //TODO HOMEWORK LINQ TASK 3 DONE
            var listche =
                from element in studentTest
                where (string.Compare(element.firstname, element.lastname) == -1)
                select element;

            foreach (var element in listche)
            {
                Console.WriteLine(element);
            }

            //TODO HOMEWORK LINQ TASK 4 DONE
            var anotherlist =
                from element in studentTest
                where ((element.age >= 18) && (element.age <= 24))
                //select element;
                select new { element.firstname, element.lastname };

            foreach (var element in anotherlist)
            {
                Console.WriteLine(element);
            }


            var studentTest_1 = new[]
		{
			new { firstname = "Borislav", lastname = "Borisov", age = 15 },
            new { firstname = "Galina", lastname = "Mihaylova", age = 22 }, 
			new { firstname = "Ivan", lastname = "Ivanov" , age = 21},
            new { firstname = "Robert", lastname = "Borisov" , age = 24},
            new { firstname = "Timbaland", lastname = "Borisov" , age = 21},
            new { firstname = "Mihail", lastname = "Borisov" , age = 24},
            new { firstname = "Bojidar", lastname = "Borisov" , age = 24},
            new { firstname = "Boaislav", lastname = "Borisov" , age = 24},
            new { firstname = "Borislav", lastname = "Atanasov" , age = 23}
		};

            Console.WriteLine("Using Lambda expressions");
            Console.WriteLine("Ascending order:");



            var example = studentTest_1.OrderBy(student => student.firstname).ThenBy(student => student.lastname);
            foreach (var element in example)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();




            Console.WriteLine("Using LINQ:");
            Console.WriteLine("Ascending order:");


            var sortedAscByLinq =
                from element in studentTest
                orderby element.firstname ascending, element.lastname descending
                select new { element.firstname, element.lastname };

            foreach (var element in sortedAscByLinq)
            {
                Console.WriteLine(element);
            }

            //TODO HOMEWORK LINQ TASK 6 DONE
            Console.WriteLine("With Lambda");
            List<int> mylist = new List<int>() { 3, 4, 5, 6, 7, 9, 10, 14, 21, 42 };

            var query = mylist.FindAll((x) => ((x % 3 == 0) && (x % 7 == 0)));
            foreach (var element in query)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("With Linq");
            var newquery =
                from element in mylist
                where (element % 3 == 0) && (element % 7 == 0)
                select element;

            foreach (var element in newquery)
            {
                Console.WriteLine(element);
            }
        }
    }
}
