using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1___Protoss
{
    static class Extensions
    {
        public static void Print<T>(this T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Shuffle<T>(this List<T> list, Random randomGenerator)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int swapIndex = randomGenerator.Next(list.Count);
                T currentElement = list[i];
                list[i] = list[swapIndex];
                list[swapIndex] = currentElement;
            }
        }
    }

    class ProtossTestGenerator
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

        class DarkTemplar
        {
            public Point Location { get; private set; }
            public DarkTemplar(Point location)
            {
                this.Location = location;
            }

            public static int GetWalkDistance(Point locationA, Point locationB)
            {
                return Math.Abs(locationA.X - locationB.X) + Math.Abs(locationA.Y - locationB.Y);
            }

            public string GetLocationAsSecretString(string[,] mapEncoded)
            {
                return mapEncoded[this.Location.X, this.Location.Y];
            }
        }

        const int maxSecretWordLength = 4;
        const int maxCoordinate = 250;

        static string[] areaNameSeparators = new string[] { "-" };
        static string[] lineMemberSeparators = new string[] { " " };
        static string allLetters = "thequickbrownfoxjumpsoverthelazydog" + "THEQUICKBROWNFOXJUMPSOVERTHELAZYDOG";
        static string unusedLetters = "-";
        static Random randomGenerator = new Random();

        static string GetRandomString(int stringLength)
        {
            StringBuilder randomString = new StringBuilder(new string('a', stringLength));
            for (int i = 0; i < stringLength; i++)
            {
                randomString[i] = allLetters[randomGenerator.Next(0, allLetters.Length)];
            }
            return randomString.ToString();
        }

        static Dictionary<string, string> GetRandomEncoder(int secretWordsCount)
        {
            Dictionary<string, string> meaningsToSecretWords = new Dictionary<string, string>(secretWordsCount);
            HashSet<string> generatedSecretWords = new HashSet<string>();

            for (int i = 0; i < secretWordsCount; i++)
            {
                string secretWord = GetRandomString(randomGenerator.Next(1, maxSecretWordLength + 1));
                while (generatedSecretWords.Contains(secretWord))
                {
                    secretWord = GetRandomString(randomGenerator.Next(1, maxSecretWordLength + 1));
                }

                string meaning = GetRandomString(randomGenerator.Next(1, maxSecretWordLength + 1));
                while (meaningsToSecretWords.ContainsKey(meaning))
                {
                    meaning = GetRandomString(randomGenerator.Next(1, 2 * maxSecretWordLength + 1));
                }
                generatedSecretWords.Add(secretWord);
                meaningsToSecretWords.Add(meaning, secretWord);
            }

            return meaningsToSecretWords;
        }

        static Dictionary<string, string> GetDecoder(Dictionary<string, string> encoder)
        {
            Dictionary<string, string> decoder = new Dictionary<string, string>(encoder.Count);

            foreach (var secretWordAndMeaning in encoder)
            {
                decoder.Add(secretWordAndMeaning.Value, secretWordAndMeaning.Key);
            }

            return decoder;
        }

        static string[,] GetRandomAreaMapCoded(byte mapRows, byte mapCols, string[] secretWords)
        {
            string[,] matrix = new string[mapRows, mapCols];
            HashSet<string> generatedAreaNames = new HashSet<string>();

            for (int row = 0; row < mapRows; row++)
            {
                for (int col = 0; col < mapCols; col++)
                {
                    matrix[row, col] += secretWords[randomGenerator.Next(secretWords.Length)];
                    while (generatedAreaNames.Contains(matrix[row, col]))
                    {
                        matrix[row, col] += "-" + secretWords[randomGenerator.Next(secretWords.Length)];
                    }
                    generatedAreaNames.Add(matrix[row, col]);
                }
            }

            return matrix;
        }

        static string GetDecodedAreaName(string codedAreaName, Dictionary<string, string> decoder)
        {
            string decodedAreaName = "";
            string[] codedAreaSecretWords = codedAreaName.Split(areaNameSeparators, StringSplitOptions.RemoveEmptyEntries);

            decodedAreaName += decoder[codedAreaSecretWords[0]];
            for (int i = 1; i < codedAreaSecretWords.Length; i++)
            {
                decodedAreaName += "-" + decoder[codedAreaSecretWords[i]];
            }

            /*
            foreach (var secretWord in codedAreaSecretWords)
            {
                decodedAreaName += decoder[secretWord] + unusedLetters[randomGenerator.Next(0, unusedLetters.Length)];
            }*/

            return decodedAreaName;
        }

        static string[,] GetAreaMapDecoded(string[,] codedAreaMap, Dictionary<string, string> decoder)
        {
            int rows = codedAreaMap.GetLength(0),
                cols = codedAreaMap.GetLength(1);
            string[,] decodedAreaMap = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    decodedAreaMap[row, col] = GetDecodedAreaName(codedAreaMap[row, col], decoder);
                }
            }

            return decodedAreaMap;
        }

        static Dictionary<string, Point> GetAreaNameToCoordinateMap(string[,] areaMap)
        {
            checked
            {
                Dictionary<string, Point> areaNameToCoordinateMap = new Dictionary<string, Point>();
                for (byte row = 0; row < areaMap.GetLength(0); row++)
                {
                    for (byte col = 0; col < areaMap.GetLength(1); col++)
                    {
                        areaNameToCoordinateMap.Add(areaMap[row, col], new Point(row, col));
                    }
                }
                return areaNameToCoordinateMap;
            }
        }

        static Dictionary<Point, string> GetCoordinateToAreaNameMap(string[,] areaMap)
        {
            Dictionary<Point, string> coordinateToAreaNameMap = new Dictionary<Point, string>();
            for (byte row = 0; row < areaMap.GetLength(0); row++)
            {
                for (byte col = 0; col < areaMap.GetLength(1); col++)
                {
                    coordinateToAreaNameMap.Add(new Point(row, col), areaMap[row, col]);
                }
            }
            return coordinateToAreaNameMap;
        }

        static List<Point> GetAllMapCoordinatesWithin(Point center, int darkTemplarDistance, string[,] areaMap)
        {
            List<Point> coordinatesInDistance = new List<Point>();

            for (byte row = 0; row < areaMap.GetLength(0); row++)
            {
                for (byte col = 0; col < areaMap.GetLength(1); col++)
                {
                    Point currentCoordinates = new Point(row, col);

                    if (DarkTemplar.GetWalkDistance(currentCoordinates, center) <= darkTemplarDistance)
                    {
                        coordinatesInDistance.Add(currentCoordinates);
                    }
                }
            }

            return coordinatesInDistance;
        }

        static List<Point> GetAllMapCoordinatesDifferentThan(List<Point> unwanted, string[,] areaMap)
        {
            List<Point> coordinatesDifferent = new List<Point>();
            HashSet<Point> unwantedCoordinates = new HashSet<Point>(unwanted);
            for (byte row = 0; row < areaMap.GetLength(0); row++)
            {
                for (byte col = 0; col < areaMap.GetLength(1); col++)
                {
                    Point currentCoordinate = new Point(row, col);
                    if (!unwantedCoordinates.Contains(currentCoordinate))
                    {
                        coordinatesDifferent.Add(currentCoordinate);
                    }
                }
            }
            return coordinatesDifferent;
        }

        static void GenerateTest(string name, byte matrixRows, byte matrixCols, int secretWordsCount, int templarCount, int templarNearCount, int templarNearDistance)
        {
            Dictionary<string, string> encoder = GetRandomEncoder(secretWordsCount);
            Dictionary<string, string> decoder = GetDecoder(encoder);

            var areaMapCoded = GetRandomAreaMapCoded(matrixRows, matrixCols, encoder.Values.ToArray());
            var areaMapDecoded = GetAreaMapDecoded(areaMapCoded, decoder);

            var areaNameToCoordinate = GetAreaNameToCoordinateMap(areaMapDecoded);
            var coordinateToAreaName = GetCoordinateToAreaNameMap(areaMapDecoded);

            int templarFarCount = templarCount - templarNearCount;
            List<DarkTemplar> templarsNear = new List<DarkTemplar>();
            List<DarkTemplar> templarsFar = new List<DarkTemplar>();

            Point targetAreaCoordinates = new Point((byte)randomGenerator.Next(matrixRows), (byte)randomGenerator.Next(matrixCols));

            List<Point> coordinatesNearTargetArea = GetAllMapCoordinatesWithin(targetAreaCoordinates, templarNearDistance, areaMapDecoded);
            List<Point> coordinatesNotNearTargetArea = GetAllMapCoordinatesDifferentThan(coordinatesNearTargetArea, areaMapDecoded);

            for (int i = 0; i < templarNearCount; i++)
            {
                templarsNear.Add(new DarkTemplar(coordinatesNearTargetArea[randomGenerator.Next(coordinatesNearTargetArea.Count)]));
            }

            for (int i = 0; i < templarFarCount; i++)
            {
                templarsFar.Add(new DarkTemplar(coordinatesNotNearTargetArea[randomGenerator.Next(coordinatesNotNearTargetArea.Count)]));
            }

            List<DarkTemplar> allTemplars = new List<DarkTemplar>();
            foreach (var templar in templarsNear)
            {
                allTemplars.Add(templar);
            }
            foreach (var templar in templarsFar)
            {
                allTemplars.Add(templar);
            }

            List<string> allTemplarsSecretLocations = new List<string>(allTemplars.Count);
            for (int i = 0; i < allTemplars.Count; i++)
            {
                allTemplarsSecretLocations.Add(allTemplars[i].GetLocationAsSecretString(areaMapCoded));
            }
            /*
            foreach (var secretWordMeaning in decoder)
            {
                Console.WriteLine(secretWordMeaning.Key + " " + secretWordMeaning.Value);
            }

            Console.WriteLine();
            Console.WriteLine("Coded matrix:");
            areaMapCoded.Print();
            Console.WriteLine();
            Console.WriteLine("Decoded matrix:");
            areaMapDecoded.Print();

            Console.WriteLine("Target area:");
            Console.WriteLine(areaMapCoded[targetAreaCoordinates.X, targetAreaCoordinates.Y]);

            Console.WriteLine("Templars:");
            foreach (var templarSecretLocation in allTemplarsSecretLocations)
            {
                Console.WriteLine(templarSecretLocation);
            }*/

            allTemplarsSecretLocations.Shuffle(randomGenerator);

            string testInFilename = name + ".in.txt";
            string testOutFilename = name + ".out.txt";

            List<string> testLines = new List<string>();
            testLines.Add(templarNearDistance.ToString());
            testLines.Add(decoder.Count.ToString());
            foreach (var decoderEntry in decoder)
            {
                testLines.Add(decoderEntry.Key + " " + decoderEntry.Value);
            }

            testLines.Add(matrixRows + " " + matrixCols);
            StringBuilder matrixLine = new StringBuilder(matrixCols);
            for (int row = 0; row < matrixRows; row++)
            {
                matrixLine.Clear();
                for (int col = 0; col < matrixCols; col++)
                {
                    matrixLine.Append(areaMapDecoded[row, col]);
                    matrixLine.Append(' ');
                }
                testLines.Add(matrixLine.ToString());
            }

            testLines.Add(areaMapCoded[targetAreaCoordinates.X, targetAreaCoordinates.Y]);
            testLines.Add(allTemplarsSecretLocations.Count.ToString());
            foreach (var templarSecretLocation in allTemplarsSecretLocations)
            {
                testLines.Add(templarSecretLocation);
            }

            System.IO.File.WriteAllLines(testInFilename, testLines.ToArray());
            System.IO.File.WriteAllLines(testOutFilename, new string[] { templarNearCount.ToString() });
        }

        private static void TestEncodeDecodeMap()
        {
            Dictionary<string, string> encoder = GetRandomEncoder(10);
            Dictionary<string, string> decoder = GetDecoder(encoder);
            var areaMapCoded = GetRandomAreaMapCoded(4, 4, encoder.Values.ToArray());
            var areaMapDecoded = GetAreaMapDecoded(areaMapCoded, decoder);

            Console.WriteLine("coded map");
            areaMapCoded.Print();
            Console.WriteLine();
            Console.WriteLine("decoded map");
            areaMapDecoded.Print();

            Console.WriteLine();
            Console.WriteLine("encoder:");
            foreach (var encoderEntry in encoder)
            {
                Console.WriteLine(encoderEntry.Key + " " + encoderEntry.Value);
            }
        }

        private static void TestCoordinateMapping()
        {
            Dictionary<string, string> encoder = GetRandomEncoder(10);
            Dictionary<string, string> decoder = GetDecoder(encoder);
            var areaMapCoded = GetRandomAreaMapCoded(4, 4, encoder.Values.ToArray());
            var areaMapDecoded = GetAreaMapDecoded(areaMapCoded, decoder);

            Console.WriteLine("coded map");
            areaMapCoded.Print();

            Console.WriteLine("area names to coordinates");
            var areaNameToCoordinateMap = GetAreaNameToCoordinateMap(areaMapCoded);
            foreach (var areaNameCoordinates in areaNameToCoordinateMap)
            {
                Console.WriteLine("Coordinates of {0} are {1}", areaNameCoordinates.Key, areaNameCoordinates.Value);
            }

            Console.WriteLine("coordinates to area names");
            var coordinateToAreaNameMap = GetCoordinateToAreaNameMap(areaMapCoded);
            foreach (var areaNameCoordinates in areaNameToCoordinateMap)
            {
                Console.WriteLine("Area at {0} has name {1}", areaNameCoordinates.Value, areaNameCoordinates.Key);
            }
        }

        private static void TestGetAllCoordinatesWithinAndDifferent()
        {
            Dictionary<string, string> encoder = GetRandomEncoder(10);
            Dictionary<string, string> decoder = GetDecoder(encoder);
            var areaMapCoded = GetRandomAreaMapCoded(4, 4, encoder.Values.ToArray());
            var areaMapDecoded = GetAreaMapDecoded(areaMapCoded, decoder);

            Console.WriteLine("coded map");
            areaMapCoded.Print();

            List<Point> coordinatesNear11 = GetAllMapCoordinatesWithin(new Point(1, 1), 2, areaMapCoded);
            List<Point> coordinatesNotNear11 = GetAllMapCoordinatesDifferentThan(coordinatesNear11, areaMapCoded);

            var coordinateToAreaNameMap = GetCoordinateToAreaNameMap(areaMapCoded);

            Console.WriteLine("coordinates near (1, 1):");
            foreach (var coordinate in coordinatesNear11)
            {
                Console.WriteLine(coordinate.X + " " + coordinate.Y + " with value " + coordinateToAreaNameMap[coordinate]);
            }

            Console.WriteLine("other coordinates:");
            foreach (var coordinate in coordinatesNotNear11)
            {
                Console.WriteLine(coordinate.X + " " + coordinate.Y + " with value " + coordinateToAreaNameMap[coordinate]);
            }
        }

        static void Main(string[] args)
        {
            //TestEncodeDecodeMap();
            //TestCoordinateMapping();
            //TestGetAllCoordinatesWithinAndDifferent();
            if (System.IO.File.Exists("tests-generation-data.txt"))
            {
                System.IO.File.Delete("tests-generation-data.txt");
            }

            while (true)
            {
                Console.WriteLine("Test name:");
                string testName = Console.ReadLine();
                Console.WriteLine("Matrix rows:");
                byte matrixRows = byte.Parse(Console.ReadLine());
                Console.WriteLine("Matrix cols:");
                byte matrixCols = byte.Parse(Console.ReadLine());
                Console.WriteLine("Secret words count:");
                int secretWordsCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Total templars count:");
                int templarsTotalCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Templars near count:");
                int templarsNearCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Templar distance considered near:");
                int templarNearDistance = int.Parse(Console.ReadLine());

                GenerateTest(testName, matrixRows, matrixCols, secretWordsCount, templarsTotalCount, templarsNearCount, templarNearDistance);

                System.IO.File.AppendAllLines("tests-generation-data.txt",
                    new string[]{
                    testName,
                    matrixRows.ToString(),
                    matrixCols.ToString(),
                    secretWordsCount.ToString(),
                    templarsTotalCount.ToString(),
                    templarsNearCount.ToString(),
                    templarNearDistance.ToString()
                    }
                    );
            }
        }
    }
}
