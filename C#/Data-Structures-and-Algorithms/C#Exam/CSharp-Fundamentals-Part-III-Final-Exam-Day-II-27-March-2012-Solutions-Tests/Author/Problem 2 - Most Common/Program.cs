using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2___Most_Common
{
    class Program
    {
        static void Main()
        {
            // TestGenerator.GenerateTests(); return;

            MostCommonCharacteristicsFinder finder = new MostCommonCharacteristicsFinder();
            int numberOfHuman = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfHuman; i++)
            {
                string human = Console.ReadLine();
                finder.AddHuman(human);
            }
            Console.WriteLine(finder.GetMostCommonFirstName());
            Console.WriteLine(finder.GetMostCommonLastName());
            Console.WriteLine(finder.GetMostCommonYearOfBirth());
            Console.WriteLine(finder.GetMostCommonEyeColor());
            Console.WriteLine(finder.GetMostCommonHairColor());
            Console.WriteLine(finder.GetMostCommonHeight());
        }
    }

    class MostCommonCharacteristicsFinder
    {
        private readonly Dictionary<string, int> firstNamesCount;
        private readonly Dictionary<string, int> lastNamesCount;
        private readonly int[] yearsOfBirthCount;
        private readonly Dictionary<string, int> eyeColorsCount;
        private readonly Dictionary<string, int> hairColorsCount;
        private readonly int[] heightsCount;

        public MostCommonCharacteristicsFinder()
        {
            firstNamesCount = new Dictionary<string, int>();
            lastNamesCount = new Dictionary<string, int>();
            yearsOfBirthCount = new int[2012 + 1];
            eyeColorsCount = new Dictionary<string, int>();
            hairColorsCount = new Dictionary<string, int>();
            heightsCount = new int[220 + 1];
        }

        public void AddHuman(string human)
        {
            string[] humanCharacteristics = human.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] names = humanCharacteristics[0].Split(' ');

            // First name
            string firstName = names[0];
            if (!firstNamesCount.ContainsKey(firstName))
            {
                firstNamesCount.Add(firstName, 1);
            }
            else
            {
                firstNamesCount[firstName]++;
            }

            // Last name
            string lastName = names[1];
            if (!lastNamesCount.ContainsKey(lastName))
            {
                lastNamesCount.Add(lastName, 1);
            }
            else
            {
                lastNamesCount[lastName]++;
            }

            // Year of birth
            int yearOfBirth = int.Parse(humanCharacteristics[1]);
            yearsOfBirthCount[yearOfBirth]++;

            // Eye color
            string eyeColor = humanCharacteristics[2];
            if (!eyeColorsCount.ContainsKey(eyeColor))
            {
                eyeColorsCount.Add(eyeColor, 1);
            }
            else
            {
                eyeColorsCount[eyeColor]++;
            }

            // Hair color
            string hairColor = humanCharacteristics[3];
            if (!hairColorsCount.ContainsKey(hairColor))
            {
                hairColorsCount.Add(hairColor, 1);
            }
            else
            {
                hairColorsCount[hairColor]++;
            }

            // Height
            int height = int.Parse(humanCharacteristics[4]);
            heightsCount[height]++;
        }

        private int GetMostCommonIntInArray(int[] array)
        {
            int best = 0;
            int bestCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > bestCount)
                {
                    best = i;
                    bestCount = array[i];
                }
                // else if (array[i] == bestCount)  ->  not the least one
            }

            return best;
        }

        private string GetMostCommonStringInDictionary(Dictionary<string, int> dictionary)
        {
            string best = string.Empty;
            int bestCount = 0;

            foreach (var element in dictionary)
            {
                if (element.Value > bestCount)
                {
                    best = element.Key;
                    bestCount = element.Value;
                }
                else if (element.Value == bestCount && element.Key.CompareTo(best) < 0)
                {
                    // element.Key is lexicographically smaller
                    best = element.Key;
                }
            }

            return best;
        }

        public string GetMostCommonFirstName()
        {
            return GetMostCommonStringInDictionary(firstNamesCount);
        }

        public string GetMostCommonLastName()
        {
            return GetMostCommonStringInDictionary(lastNamesCount);
        }

        public int GetMostCommonYearOfBirth()
        {
            return GetMostCommonIntInArray(yearsOfBirthCount);
        }

        public string GetMostCommonEyeColor()
        {
            return GetMostCommonStringInDictionary(eyeColorsCount);
        }

        public string GetMostCommonHairColor()
        {
            return GetMostCommonStringInDictionary(hairColorsCount);
        }

        public int GetMostCommonHeight()
        {
            return GetMostCommonIntInArray(heightsCount);
        }
    }
}
