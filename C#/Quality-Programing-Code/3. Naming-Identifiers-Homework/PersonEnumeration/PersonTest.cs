namespace PersonWithEnumerations
{
    using PersonEnumeration;
    using System;


    static class PersonTest
    {
        public static Person ProducePerson(int age)
        {
            Person person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Batka";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Mace";
                person.Sex = Sex.Female;
            }

            return person;
        }

        static void Main()
        {
            var firstPerson = ProducePerson(10);
            Console.WriteLine(firstPerson.ToString());
        }
    }
}