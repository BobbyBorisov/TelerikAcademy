using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Protoss
{
    class Protoss
    {
        class Point
        {
            public byte X { get; set; }
            public byte Y { get; set; }
            public Point(byte x = 0, byte y = 0)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return this.X.ToString() + " " + this.Y.ToString();
            }

            public override int GetHashCode()
            {
                return this.X.GetHashCode() * 3 + this.Y.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                Point other = obj as Point;
                return this.X.Equals(other.X) && this.Y.Equals(other.Y);
            }
        }

        static int GetDarkTemplarWalkDistance(Point A, Point B)
        {
            return Math.Abs(A.X - B.X) + Math.Abs(A.Y - B.Y); //this is called Manhattan distance (google it or "taxicab geometry")
        }

        static string[] areaNameSeparators = new string[] { "-" };
        static string[] lineMemberSeparators = new string[] { " " };

        static string GetDecodedAreaName(string codedAreaName, Dictionary<string, string> decoder)
        {
            string decodedAreaName = "";
            string[] codedAreaSecretWords = codedAreaName.Split(areaNameSeparators, StringSplitOptions.RemoveEmptyEntries);

            decodedAreaName += decoder[codedAreaSecretWords[0]];
            for (int i = 1; i < codedAreaSecretWords.Length; i++)
            {
                decodedAreaName += areaNameSeparators[0] + decoder[codedAreaSecretWords[i]];
            }

            return decodedAreaName;
        }

        static Point GetLocation(string encodedAreaName, Dictionary<string, string> nameDecoder, Dictionary<string, Point> areaNameToLocationDecoder)
        {
            string decodedAreaName = GetDecodedAreaName(encodedAreaName, nameDecoder);
            Point location = areaNameToLocationDecoder[decodedAreaName];
            return location;
        }

        private static Point ParseTargetAreaLocation(Dictionary<string, string> nameDecoder, Dictionary<string, Point> areaNameToLocationDecoder)
        {
            string encodedTargetAreaName = Console.ReadLine();
            Point targetAreaLocation = GetLocation(encodedTargetAreaName, nameDecoder, areaNameToLocationDecoder);
            return targetAreaLocation;
        }

        private static void ParseMapDimensions(out int mapRows, out int mapCols)
        {
            string[] mapRowsAndCols = Console.ReadLine().Split(lineMemberSeparators, StringSplitOptions.RemoveEmptyEntries);

            mapRows = int.Parse(mapRowsAndCols[0]);
            mapCols = int.Parse(mapRowsAndCols[1]);
        }

        private static Dictionary<string, string> ParseNameEncoder(int secretWordsCount)
        {
            Dictionary<string, string> nameDecoder = new Dictionary<string, string>();
            for (int i = 0; i < secretWordsCount; i++)
            {
                string[] secretWordAndMeaning = Console.ReadLine().Split(lineMemberSeparators, StringSplitOptions.RemoveEmptyEntries);
                nameDecoder.Add(secretWordAndMeaning[0], secretWordAndMeaning[1]);
            }
            return nameDecoder;
        }

        private static void ParseNameToLocationEncoder(int mapRows, int mapCols, Dictionary<string, Point> areaNameToLocationDecoder)
        {
            for (byte row = 0; row < mapRows; row++)
            {
                string[] areaNames = Console.ReadLine().Split(lineMemberSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (byte col = 0; col < mapCols; col++)
                {
                    string areaName = areaNames[col];
                    Point areaLocation = new Point(row, col);
                    areaNameToLocationDecoder.Add(areaName, areaLocation);
                }
            }
        }

        static void Main(string[] args)
        {
            int threatDistance = int.Parse(Console.ReadLine());
            int secretWordsCount = int.Parse(Console.ReadLine());

            Dictionary<string, string> nameDecoder = ParseNameEncoder(secretWordsCount);

            int mapRows;
            int mapCols;
            ParseMapDimensions(out mapRows, out mapCols);

            Dictionary<string, Point> areaNameToLocationDecoder = new Dictionary<string, Point>();
            ParseNameToLocationEncoder(mapRows, mapCols, areaNameToLocationDecoder);

            Point targetAreaLocation = ParseTargetAreaLocation(nameDecoder, areaNameToLocationDecoder);

            int darkTemplarCount = int.Parse(Console.ReadLine());
            Point currentDarkTemplarLocation;

            int threatsCount = 0;
            for (int i = 0; i < darkTemplarCount; i++)
            {
                string darkTemplarEncodedAreaName = Console.ReadLine();
                currentDarkTemplarLocation = GetLocation(darkTemplarEncodedAreaName, nameDecoder, areaNameToLocationDecoder);
                if (GetDarkTemplarWalkDistance(targetAreaLocation, currentDarkTemplarLocation) <= threatDistance)
                {
                    threatsCount++;
                }
            }

            Console.WriteLine(threatsCount);
        }
    }
}
