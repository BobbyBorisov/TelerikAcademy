using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5___Nakov_Number
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] inputParts = input.Split(new string[] { ", " }, StringSplitOptions.None);
            List<string> publications = new List<string>();
            foreach (var inputPart in inputParts)
            {
                publications.Add(inputPart.Replace("\"", ""));
            }

            NakovNumbersCalculator nakovNumbersCalculator = new NakovNumbersCalculator();
            List<string> nakovNumbers = nakovNumbersCalculator.CalculateNumbers(publications);
            foreach (var nakovNumber in nakovNumbers)
            {
                Console.WriteLine(nakovNumber);
            }
        }
    }

    public class NakovNumbersCalculator
    {
        public List<string> CalculateNumbers(List<string> publications)
        {
            Queue<string> bfsAuthorsQueue = new Queue<string>();
            IDictionary<string, int> nakovNumbersDictionary = new SortedDictionary<string, int>();

            // Add all authors in the queue
            foreach (string publication in publications)
            {
                string[] publicationAuthors = publication.Split(' ');
                foreach (string publicationAuthor in publicationAuthors)
                {
                    nakovNumbersDictionary[publicationAuthor] = int.MaxValue;
                }
            }

            // Perform BFS algorithm for the authors in publications, starting from NAKOV
            nakovNumbersDictionary["NAKOV"] = 0;
            bfsAuthorsQueue.Enqueue("NAKOV");

            while (bfsAuthorsQueue.Count > 0)
            {
                string currentAuthor = bfsAuthorsQueue.Dequeue();
                foreach (string publication in publications)
                {
                    string[] publicationAuthors = publication.Split(' ');
                    bool currentAuthorIsAPublicationAuthor = false;
                    foreach (string publicationAuthor in publicationAuthors)
                    {
                        if (currentAuthor == publicationAuthor)
                        {
                            currentAuthorIsAPublicationAuthor = true;
                            break;
                        }
                    }
                    if (currentAuthorIsAPublicationAuthor)
                    {
                        foreach (string publicationAuthor in publicationAuthors)
                        {
                            if (nakovNumbersDictionary[publicationAuthor] == int.MaxValue)
                            {
                                nakovNumbersDictionary[publicationAuthor] = nakovNumbersDictionary[currentAuthor] + 1;
                                bfsAuthorsQueue.Enqueue(publicationAuthor);
                            }
                        }
                    }
                }
            }

            // Convert Nakov numbers to the format required
            List<string> nakovNumbers = new List<string>();
            foreach (var nakovNumber in nakovNumbersDictionary)
            {
                if (nakovNumber.Value == int.MaxValue)
                {
                    nakovNumbers.Add(string.Format("{0} -1", nakovNumber.Key));
                }
                else
                {
                    nakovNumbers.Add(string.Format("{0} {1}", nakovNumber.Key, nakovNumber.Value));
                }
            }

            return nakovNumbers;
        }
    }
}
