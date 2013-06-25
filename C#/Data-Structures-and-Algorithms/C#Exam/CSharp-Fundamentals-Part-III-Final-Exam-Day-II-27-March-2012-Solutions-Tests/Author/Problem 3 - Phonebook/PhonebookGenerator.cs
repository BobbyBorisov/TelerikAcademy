using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3___Phonebook
{
    public class PhonebookGenerator
    {
        static readonly string[] names =
	{
		"Baj Mangal", "Bate Bojko", "Baba Yaga", "Kiro", "Pepi", "Kiril Kirilov Kirilov",
		"Prakash Nilesh Katataharhsmaftar", "baba mi", "Kaka Mara", "Nakata Makata Fakata",
		"Lelya.Minka", "Kaka Stoyka (Pleven)", "C# exam testing system", "baba penka",
	};

        static readonly string[] phones =
	{
		"+359444555666", "+359777888999", "123", "00123", "+359 123", "(00359) 123", "(+359) 123",
		"00359123", "(00359) 1-2-3", "0123", "(02) 981 22 33", "(+1) 123 456 789", "0888 / 888-888",
		"0888 88 88 88", "888-88-88-88", "+359 (888) 88-88-88", "+359888888888"
	};

        static readonly Random rnd = new Random();
        static readonly List<string> commands = new List<string>();
        static int addComandsExecuted = 0;

        static void Main()
        {
            GenerateRandomAddCommands(5000);
            GenerateRandomListCommands(2000);
            GenerateInvalidListCommands(1000);
            GenerateInvalidUpdateCommands(1000);
            GenerateRandomUpdateCommands(2000);
            GenerateRandomListCommands(2000);

            DuplicateAllCommands();

            AppendEndCommand();

            PrintCommands();
        }

        private static void GenerateRandomAddCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomAddCommand();
            }
        }

        private static void GenerateRandomAddCommand()
        {
            string name = GenerateRandomName();
            string phones = GenerateRandomPhones();
            string cmd = String.Format("AddPhone({0}, {1})", name, phones);
            commands.Add(cmd);
            addComandsExecuted++;
        }

        private static string GenerateRandomName()
        {
            string name = names[rnd.Next(names.Length)];
            if (rnd.Next(2) == 0)
            {
                name += " - " + rnd.Next(1000000);
            }
            return name;
        }

        private static string GenerateRandomPhones()
        {
            int countOfPhones = 1 + rnd.Next(10);
            string[] phonesArr = new string[countOfPhones];
            for (int i = 0; i < countOfPhones; i++)
            {
                phonesArr[i] = GenerateRandomPhone();
            }
            string phones = String.Join(", ", phonesArr);
            return phones;
        }

        private static string GenerateRandomPhone()
        {
            string phone = phones[rnd.Next(phones.Length)];
            if (rnd.Next(3) == 0)
            {
                phone += " - " + rnd.Next(1000000);
            }
            return phone;
        }

        private static void DuplicateAllCommands()
        {
            commands.AddRange(commands);
        }

        private static void GenerateRandomUpdateCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomUpdateCommand();
            }
        }

        private static void GenerateRandomUpdateCommand()
        {
            string oldPhone = GenerateRandomPhone();
            string newPhone = GenerateRandomPhone();
            string cmd = "ChangePhone(" + oldPhone + ", " + newPhone + ")";
            commands.Add(cmd);
        }

        private static void GenerateInvalidUpdateCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateInvalidUpdateCommand();
            }
        }

        private static void GenerateInvalidUpdateCommand()
        {
            string oldPhone = GenerateRandomPhone() + rnd.Next(1000000, 5000000);
            string newPhone = GenerateRandomPhone();
            string cmd = "ChangePhone(" + oldPhone + ", " + newPhone + ")";
            commands.Add(cmd);
        }

        private static void GenerateRandomListCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomListCommand();
            }
        }

        private static void GenerateRandomListCommand()
        {
            int startIndex = rnd.Next(addComandsExecuted);
            int count = 1 + rnd.Next(20);
            string cmdFormat = "List({0}, {1})";
            string cmd = String.Format(cmdFormat, startIndex, count);
            commands.Add(cmd);
        }

        private static void GenerateInvalidListCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateInvalidListCommand();
            }
        }

        private static void GenerateInvalidListCommand()
        {
            int startIndex = addComandsExecuted + rnd.Next(10) - 5;
            int count = 1 + rnd.Next(20);
            string cmdFormat = "List({0}, {1})";
            string cmd = String.Format(cmdFormat, startIndex, count);
            commands.Add(cmd);
        }

        private static void AppendEndCommand()
        {
            commands.Add("End");
        }

        private static void PrintCommands()
        {
            foreach (var cmd in commands)
            {
                Console.WriteLine(cmd);
            }
        }
    }
}
