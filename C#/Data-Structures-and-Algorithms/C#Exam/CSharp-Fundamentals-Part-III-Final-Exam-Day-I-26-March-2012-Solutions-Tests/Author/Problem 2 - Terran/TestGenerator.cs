using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2___Terran
{
    public static class Extensions
    {
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

    class TerranTestGenerator
    {
        static int maxCreatedEncodedCoordinate = 0;
        const int codewordPieceLength = 4;

        const int minCodeValue = -1000;
        const int maxCodeValue = 1000;

        //const int minCodeValue = -10;
        //const int maxCodeValue = 10;

        const int minCoordinate = -5000;
        const int maxCoordinate = 5000;

        //const int minCoordinate = -20;
        //const int maxCoordinate = 20;

        const int maxBanshees = 1000;

        const double safetyOffset = 0.1;

        static string allLetters = "thequickbrownfoxjumpsoverthelazydogTHEQUICKBROWNFOXJUMPSOVERTHELAZYDOG";

        static Random randomGenerator = new Random();

        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x = 0, double y = 0)
            {
                this.X = x;
                this.Y = y;
            }

            public static Point operator +(Point A, Point B)
            {
                return new Point(A.X + B.X, A.Y + B.Y);
            }

            public static Point operator -(Point A, Point B)
            {
                return new Point(A.X - B.X, A.Y - B.Y);
            }

            public override string ToString()
            {
                return this.X.ToString() + " " + this.Y.ToString();
            }
        }

        class BoundingSphere
        {
            private Point center;
            private double radius;
            private double sqRadius;
            public BoundingSphere(Point center, double radius)
            {
                this.center = center;
                this.radius = radius;
                this.sqRadius = radius * radius;
            }

            public void TryExtend(Point tryPoint)
            {
                double centerToTryPointSquared = GetSquaredDistance(this.center, tryPoint);
                if (centerToTryPointSquared > this.sqRadius)
                {
                    this.radius = Math.Sqrt(centerToTryPointSquared);
                    this.sqRadius = centerToTryPointSquared;
                }
            }

            public void Extend(double radiusIncrease)
            {
                this.radius += radiusIncrease;
                this.sqRadius = this.radius * this.radius;
            }

            public bool Intersects(BoundingSphere other)
            {
                double radiusesSum = this.radius + other.radius;
                double sqRadiusesSum = radiusesSum * radiusesSum;
                double sqCenterDistance = GetSquaredDistance(this.center, other.center);

                return (sqRadiusesSum >= sqCenterDistance);
            }

            public override string ToString()
            {
                return this.center + ", " + this.radius;
            }
        }

        static double GetSquaredDistance(Point A, Point B)
        {
            return (A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y);
        }

        static double GetDistance(Point A, Point B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        static string[] SplitIntoEqualPieces(string strToSplit, int pieceLength)
        {
            string[] pieces = new string[strToSplit.Length / pieceLength];
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = strToSplit.Substring(pieceLength * i, pieceLength);
            }
            return pieces;
        }

        class Banshee
        {
            //public string Name { get; private set; }
            public Point Location { get; private set; }
            public Banshee(/*string name,*/ Point location)
            {
                //this.Name = name;
                this.Location = location;
            }

            public static string EncodeCoordinate(int coordinateToEncode, Dictionary<int, string> locationEncoder)
            {
                int[] coordinateSumSequence = GetSequenceSummingTo(coordinateToEncode, minCodeValue, maxCodeValue);
                StringBuilder encodedCoordinate = new StringBuilder();
                foreach (var element in coordinateSumSequence)
                {
                    //Console.WriteLine(element);
                    encodedCoordinate.Append(locationEncoder[element]);
                }

                maxCreatedEncodedCoordinate = Math.Max(maxCreatedEncodedCoordinate, encodedCoordinate.Length);
                return encodedCoordinate.ToString();
            }

            private static int DecodeCoordinate(string codedCoordinate, Dictionary<string, int> locationDecoder)
            {
                string[] sumPieces = SplitIntoEqualPieces(codedCoordinate, codewordPieceLength);
                int coordinate = 0;
                foreach (var piece in sumPieces)
                {
                    coordinate += locationDecoder[piece];
                }
                return coordinate;
            }

            public static Banshee Parse(string codedBansheeIDString, Dictionary<string, int> locationDecoder, string[] separators)
            {
                string[] bansheeNameAndLocationStrings = codedBansheeIDString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                //string bansheeName = bansheeNameAndLocationStrings[0];
                string codedBansheeXCoord = bansheeNameAndLocationStrings[0];
                string codedBansheeYCoord = bansheeNameAndLocationStrings[1];

                int bansheeXCoord = Banshee.DecodeCoordinate(codedBansheeXCoord, locationDecoder);
                int bansheeYCoord = Banshee.DecodeCoordinate(codedBansheeYCoord, locationDecoder);

                return new Banshee(/*bansheeName, */new Point(bansheeXCoord, bansheeYCoord));
            }

            public override string ToString()
            {
                return /*this.Name + " " + */this.Location.ToString();
            }
        }

        class BansheeGroup
        {
            private double commDistance;
            private Banshee[] banshees;
            public BoundingSphere BoundingSphere { get; private set; }
            public BansheeGroup(int bansheesToGenerateCount, Point firstLocation, double communicationDistance, bool loopConnectionsPossible = true)
            {
                this.commDistance = communicationDistance;
                this.banshees = new Banshee[bansheesToGenerateCount];
                this.banshees[0] = new Banshee(firstLocation);
                if (loopConnectionsPossible)
                {
                    GenerateAsGraph(bansheesToGenerateCount, communicationDistance);
                }

                Point boundingSphereCenter = new Point();
                foreach (var banshee in this.banshees)
                {
                    boundingSphereCenter = boundingSphereCenter + banshee.Location;
                }

                this.BoundingSphere = new BoundingSphere(boundingSphereCenter, 0);

                foreach (var banshee in this.banshees)
                {
                    this.BoundingSphere.TryExtend(banshee.Location);
                }

                this.BoundingSphere.Extend(communicationDistance + safetyOffset);
            }

            public BansheeGroup(Banshee[] banshees, double communicationDistance)
            {
                this.banshees = banshees;

                Point boundingSphereCenter = new Point();
                foreach (var banshee in this.banshees)
                {
                    boundingSphereCenter = boundingSphereCenter + banshee.Location;
                }

                this.BoundingSphere = new BoundingSphere(boundingSphereCenter, 0);

                foreach (var banshee in this.banshees)
                {
                    this.BoundingSphere.TryExtend(banshee.Location);
                }

                this.BoundingSphere.Extend(communicationDistance + safetyOffset);
            }

            private void GenerateAsGraph(int bansheesToGenerateCount, double communicationDistance)
            {
                for (int currentInd = 1; currentInd < bansheesToGenerateCount; currentInd++)
                {
                    bool canCommunicate = false;
                    Point currentLocation = new Point(0, 0);
                    while (!canCommunicate)
                    {
                        currentLocation = new Point(randomGenerator.Next(minCoordinate, maxCoordinate + 1), randomGenerator.Next(minCoordinate, maxCoordinate + 1));
                        for (int alreadyAddedInd = 0; alreadyAddedInd < currentInd; alreadyAddedInd++)
                        {
                            Point alreadyAddedLocation = this.banshees[alreadyAddedInd].Location;
                            double sqDistance = GetSquaredDistance(currentLocation, alreadyAddedLocation);
                            if (sqDistance <= communicationDistance - safetyOffset)
                            {
                                canCommunicate = true;
                                break;
                            }
                        }
                    }
                    this.banshees[currentInd] = new Banshee(currentLocation);
                }
            }

            public bool Contacts(BansheeGroup other)
            {
                return this.BoundingSphere.Intersects(other.BoundingSphere);
            }

            public Point[] GetBansheeLocations()
            {
                Point[] locations = new Point[this.banshees.Length];
                for (int i = 0; i < this.banshees.Length; i++)
                {
                    locations[i] = new Point(this.banshees[i].Location.X, this.banshees[i].Location.Y);
                }
                return locations;
            }

            public int GetBansheesCount()
            {
                return this.banshees.Length;
            }

            public BansheeGroup GetTranslatedCopy(Point translation, int bansheesToCopyCount)
            {
                Banshee[] copyBanshees = new Banshee[bansheesToCopyCount];
                for (int i = 0; i < bansheesToCopyCount; i++)
                {
                    copyBanshees[i] = new Banshee(this.banshees[i].Location + translation);
                }

                return new BansheeGroup(copyBanshees, this.commDistance);
            }
        }

        static string GetRandomString(int stringLength)
        {
            StringBuilder randomString = new StringBuilder(new string('a', stringLength));
            for (int i = 0; i < stringLength; i++)
            {
                randomString[i] = allLetters[randomGenerator.Next(0, allLetters.Length)];
            }
            return randomString.ToString();
        }

        static Dictionary<int, string> GetEncoderRandom(int numbersRangeLower, int numbersRangeUpper, int codewordLength)
        {
            Dictionary<int, string> numberCodewords = new Dictionary<int, string>();
            HashSet<string> generatedCodewords = new HashSet<string>();
            for (int i = numbersRangeLower; i <= numbersRangeUpper; i++)
            {
                string currentCodeword = GetRandomString(codewordLength);
                while (generatedCodewords.Contains(currentCodeword))
                {
                    currentCodeword = GetRandomString(codewordLength);
                }
                numberCodewords.Add(i, currentCodeword);
                generatedCodewords.Add(currentCodeword);
            }
            return numberCodewords;
        }

        static Dictionary<string, int> GetDecoder(Dictionary<int, string> encoder)
        {
            Dictionary<string, int> decoder = new Dictionary<string, int>(encoder.Count);
            foreach (var numberEncodingPair in encoder)
            {
                decoder.Add(numberEncodingPair.Value, numberEncodingPair.Key);
            }
            return decoder;
        }

        static int[] GetSequenceSummingTo(int targetSum, int numbersRangeLower, int numbersRangeUpper)
        {
            List<int> sequence = new List<int>();

            if ((targetSum < 0 && numbersRangeLower >= 0) ||
                (targetSum >= 0 && numbersRangeUpper < 0))
            {
                throw new InvalidOperationException("targetNumber cannot be achieved with this range");
            }

            int nextNumber = randomGenerator.Next(numbersRangeLower, numbersRangeUpper);
            while (nextNumber == 0)
            {
                nextNumber = randomGenerator.Next(numbersRangeLower, numbersRangeUpper);
            }
            sequence.Add(nextNumber);
            int currentSum = nextNumber;

            int maxFarRange = Math.Min(Math.Abs(numbersRangeLower), Math.Abs(numbersRangeUpper));
            //Console.WriteLine(maxFarRange);

            int nextNumberFarRange = (targetSum - currentSum) % maxFarRange; //from zero to this
            int nextNumberLowerRange = Math.Min(0, nextNumberFarRange),
                nextNumberUpperRange = Math.Max(0, nextNumberFarRange);

            while (currentSum != targetSum)
            {
                nextNumber = 0;
                while (nextNumber == 0)
                {
                    nextNumber = (randomGenerator.Next(nextNumberLowerRange, nextNumberUpperRange + 1) % maxFarRange);
                }

                sequence.Add(nextNumber);
                currentSum += nextNumber;

                nextNumberFarRange = targetSum - currentSum; //from zero to this
                nextNumberLowerRange = Math.Min(0, nextNumberFarRange);
                nextNumberUpperRange = Math.Max(0, nextNumberFarRange);
            }

            return sequence.ToArray();
        }

        static void TestEncodeCoordinate()
        {
            Dictionary<int, string> numberEncoder = GetEncoderRandom(minCodeValue, maxCodeValue, codewordPieceLength);
            Dictionary<string, int> numberDecoder = GetDecoder(numberEncoder);

            string[] bansheeLines = new string[]{
                Banshee.EncodeCoordinate(100, numberEncoder) + " " + Banshee.EncodeCoordinate(100, numberEncoder),
                Banshee.EncodeCoordinate(-50, numberEncoder) + " " + Banshee.EncodeCoordinate(100, numberEncoder),
                Banshee.EncodeCoordinate(500, numberEncoder) + " " + Banshee.EncodeCoordinate(100, numberEncoder),
            };

            string[] separators = new string[] { " " };

            foreach (var line in bansheeLines)
            {
                Banshee b = Banshee.Parse(line, numberDecoder, separators);
                Console.WriteLine(line + " = " + b);
            }
        }

        private static void TestGetSequenceSummingTo()
        {
            int[] sumSequence = GetSequenceSummingTo(-500, minCodeValue, maxCodeValue);
            foreach (var item in sumSequence)
            {
                Console.WriteLine(item);
            }
        }

        static void TestBansheeGroup()
        {
            double communicationDistance = 3;
            BansheeGroup bansheeGroup = new BansheeGroup(10, new Point(1, 3), communicationDistance);
            Point[] bansheeLocations = bansheeGroup.GetBansheeLocations();

            bool hasNeighbours = false;
            for (int i = 0; i < bansheeLocations.Length; i++)
            {
                for (int j = 0; j < bansheeLocations.Length; j++)
                {
                    if (i == j) continue;
                    double distance = GetDistance(bansheeLocations[i], bansheeLocations[j]);
                    if (distance <= communicationDistance)
                    {
                        Console.WriteLine("location " + bansheeLocations[i] + " has neighbour at " + bansheeLocations[j] + " with distance " + distance);

                        hasNeighbours = true;
                        break;
                    }
                }
                if (!hasNeighbours)
                {
                    Console.WriteLine("location " + bansheeLocations[i] + " does NOT have neighbours");
                }
            }
        }

        static void TestBoundingSphere()
        {
            BoundingSphere sphereA = new BoundingSphere(new Point(1, 0), 0),
                sphereB = new BoundingSphere(new Point(-1, 0), 0);
            Console.WriteLine("sphereA intersects sphereB: " + sphereA.Intersects(sphereB));

            sphereA.TryExtend(new Point(0, 0));
            sphereA.TryExtend(new Point(0.5, 0.5));
            Console.WriteLine("extended A with point (0, 0)");
            Console.WriteLine("sphereA intersects sphereB: " + sphereA.Intersects(sphereB));

            sphereA.Extend(1);
            Console.WriteLine("additionally extended A with 1 units");
            Console.WriteLine("sphereA intersects sphereB: " + sphereA.Intersects(sphereB));

        }

        static void GenerateTest(string testName, int separateBansheeGroupsCount, int maxBansheesCount, double communicationDistance)
        {
            Dictionary<int, string> encoder = GetEncoderRandom(minCodeValue, maxCodeValue, codewordPieceLength);
            Dictionary<string, int> decoder = GetDecoder(encoder);

            int maxBansheeGroupSize = maxBansheesCount / separateBansheeGroupsCount;

            List<BansheeGroup> groups = new List<BansheeGroup>(separateBansheeGroupsCount);

            Point firstLocation = new Point(randomGenerator.Next(minCoordinate, maxCoordinate + 1), randomGenerator.Next(minCoordinate, maxCoordinate + 1));

            groups.Add(new BansheeGroup(randomGenerator.Next(1, maxBansheeGroupSize + 1), firstLocation, communicationDistance));

            for (int currentGroupInd = 1; currentGroupInd < separateBansheeGroupsCount; currentGroupInd++)
            {
                BansheeGroup currentGroup = null;
                bool isIsolated = false;
                while (!isIsolated)
                {
                    isIsolated = true;
                    Point translation = new Point(randomGenerator.Next(minCoordinate, maxCoordinate + 1), randomGenerator.Next(minCoordinate, maxCoordinate + 1));
                    currentGroup = groups[0].GetTranslatedCopy(translation, randomGenerator.Next(1, groups[0].GetBansheesCount() + 1));

                    for (int alreadyAddedInd = 0; alreadyAddedInd < currentGroupInd; alreadyAddedInd++)
                    {
                        if (currentGroup.Contacts(groups[alreadyAddedInd]))
                        {
                            isIsolated = false;
                        }
                    }
                }
                groups.Add(currentGroup);
            }

            Console.WriteLine("generated...");
            List<Banshee> allBanshees = new List<Banshee>();
            foreach (var group in groups)
            {
                Point[] bansheeLocations = group.GetBansheeLocations();
                foreach (var location in bansheeLocations)
                {
                    allBanshees.Add(new Banshee(location));
                }
            }

            Console.WriteLine("shuffling...");
            allBanshees.Shuffle(randomGenerator);

            Console.WriteLine("encoding...");
            string[] codedBanshees = new string[allBanshees.Count];
            for (int i = 0; i < allBanshees.Count; i++)
            {
                codedBanshees[i] = Banshee.EncodeCoordinate((int)allBanshees[i].Location.X, encoder) + " " + Banshee.EncodeCoordinate((int)allBanshees[i].Location.Y, encoder);
            }

            string testInFilename = testName + ".in.txt";
            string testOutFilename = testName + ".out.txt";

            try
            {
                System.IO.File.Delete(testInFilename);
                System.IO.File.Delete(testOutFilename);
            }
            catch (System.IO.FileNotFoundException)
            {
            }

            Console.WriteLine("printing test...");
            System.IO.File.AppendAllText(testInFilename, communicationDistance + "\n");
            System.IO.File.AppendAllText(testInFilename, decoder.Count + "\n");
            foreach (var decoderEntry in decoder)
            {
                System.IO.File.AppendAllText(testInFilename, decoderEntry.Key + " " + decoderEntry.Value + "\n");
            }
            System.IO.File.AppendAllText(testInFilename, codedBanshees.Length + "\n");
            foreach (var bansheeString in codedBanshees)
            {
                System.IO.File.AppendAllText(testInFilename, bansheeString + "\n");
            }

            System.IO.File.AppendAllText(testOutFilename, separateBansheeGroupsCount + "\n");

            Console.WriteLine("done!");
            Console.WriteLine();
        }

        static void Main()
        {
            //TestGetSequenceSummingTo();
            TestEncodeCoordinate();
            //TestBansheeGroup();
            //TestBoundingSphere();

            while (true)
            {
                Console.WriteLine("Test name:");
                string testName = Console.ReadLine();
                Console.WriteLine("Separate banshee groups count:");
                int separateBansheeGroupsCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Max banshee count:");
                int maxBansheeCount = int.Parse(Console.ReadLine());
                Console.WriteLine("Communication distance:");
                double communicationDistance = double.Parse(Console.ReadLine());
                GenerateTest(testName, separateBansheeGroupsCount, maxBansheeCount, communicationDistance);

                Console.WriteLine(maxCreatedEncodedCoordinate);

                System.IO.File.AppendAllText("tests-generation-data.txt", testName + "\n" + separateBansheeGroupsCount + "\n" + maxBansheeCount + "\n" + communicationDistance + "\n");
            }
        }
    }
}
