using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Task
{
    class AnimalsExample
    {
        //Get Average by Lambda
        static double CalcAverageLambda(Animal[] a) 
        {
            return a.Average(x => x.Age);
        }

        //Get Average by LINQ
        static void CalcGroupAverageLINQ(Animal[] a) 
        {
            var animalGroups =
                (from animal in a
                 group animal by animal.GetType().Name into groups
                 select new
                 {
                     groupName = groups.Key,
                     averageSum =
                         (from anim in groups
                          select anim.Age).Average()
                 });
            foreach (var item in animalGroups)
            {
                Console.WriteLine(item);
            }         
        }

        static void Main()
        {

            var dogs = new[]
            {
                new Dog("Gosho",Sex.Male,5),
                new Dog("Pesho",Sex.Male,6),
                new Dog("Pecka",Sex.Female,7)
            };

            var averageAge = AnimalsExample.CalcAverageLambda(dogs);
            Console.WriteLine("Dogs average age:{0}",averageAge);

            var kittens = new[]
            {
                new Kitten("firstKitten",8),
                new Kitten("secondKitten",7),
                new Kitten("thirtKitten",9)
            };

            var averageAge_kittens = AnimalsExample.CalcAverageLambda(kittens);
            Console.WriteLine("Kittens average age:{0}",averageAge_kittens);
            
            
            AnimalsExample.CalcGroupAverageLINQ(kittens);
            
            
            var animals = new Animal[]
            {
               new Dog("Gosho",Sex.Male,5),
               new Dog("Pesho",Sex.Male,6),
               new Kitten("firstKitten",8),
               new Kitten("secondKitten",7),
               new Tomcat("Tomcat1",9),
               new Frog("Frog1",Sex.Male,10)
            };
            
            AnimalsExample.CalcGroupAverageLINQ(animals);

            foreach (var a in animals)
            {
                a.Sound();
            }

            
            
        }
    }
}
