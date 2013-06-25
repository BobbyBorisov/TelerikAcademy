using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2___Terran
{
    class Terran
    {
        static void Main()
        {
            Dictionary<string, int> locationDecoder;
            Banshee[] banshees;
            string[] separators = new string[] { " " };

            string communicationDistanceLine = Console.ReadLine();
            double communicationDistance = double.Parse(communicationDistanceLine);

            int codewordsCount = int.Parse(Console.ReadLine());

            locationDecoder = new Dictionary<string, int>(codewordsCount);
            for (int i = 0; i < codewordsCount; i++)
            {
                string codewordAndValueLine = Console.ReadLine();
                string[] codewordAndValue = codewordAndValueLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string codeword = codewordAndValue[0];
                int codewordValue = int.Parse(codewordAndValue[1]);
                locationDecoder.Add(codeword, codewordValue);
            }

            int bansheesCount = int.Parse(Console.ReadLine());
            banshees = new Banshee[bansheesCount];
            for (int i = 0; i < bansheesCount; i++)
            {
                string codedBansheeIDLine = Console.ReadLine();
                banshees[i] = Banshee.Parse(codedBansheeIDLine, locationDecoder, separators);
            }

            BansheeGraph bansheeGroups = new BansheeGraph(banshees, communicationDistance);

            Console.WriteLine(bansheeGroups.GetConnectedComponentsCount());
        }

        const int codewordPieceLength = 4;
        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x = 0, double y = 0)
            {
                this.X = x;
                this.Y = y;
            }
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
            public Point Location { get; private set; }
            public Banshee(Point location)
            {
                this.Location = location;
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

                string codedBansheeXCoord = bansheeNameAndLocationStrings[0];
                string codedBansheeYCoord = bansheeNameAndLocationStrings[1];

                int bansheeXCoord = Banshee.DecodeCoordinate(codedBansheeXCoord, locationDecoder);
                int bansheeYCoord = Banshee.DecodeCoordinate(codedBansheeYCoord, locationDecoder);

                return new Banshee(new Point(bansheeXCoord, bansheeYCoord));
            }
        }

        class BansheeGraph
        {
            private double maxConnectionDistance;
            private Banshee[] banshees;
            private List<int>[] bansheeNeighbours;
            public BansheeGraph(Banshee[] banshees, double communicationDistance)
            {
                this.banshees = new Banshee[banshees.Length];
                Array.Copy(banshees, this.banshees, banshees.Length);
                this.maxConnectionDistance = communicationDistance;

                this.bansheeNeighbours = new List<int>[banshees.Length];
                for (int bansheeInd = 0; bansheeInd < this.bansheeNeighbours.Length; bansheeInd++)
                {
                    this.bansheeNeighbours[bansheeInd] = new List<int>();
                }

                BuildGraph();
            }

            private void BuildGraph()
            {
                for (int currentBansheeInd = 0; currentBansheeInd < this.banshees.Length; currentBansheeInd++)
                {
                    for (int targetBansheeInd = currentBansheeInd + 1; targetBansheeInd < this.banshees.Length; targetBansheeInd++)
                    {
                        double distanceBetweenCurrentAndTarget = GetDistance(this.banshees[currentBansheeInd].Location, this.banshees[targetBansheeInd].Location);
                        if (distanceBetweenCurrentAndTarget <= this.maxConnectionDistance)
                        {
                            this.bansheeNeighbours[currentBansheeInd].Add(targetBansheeInd);
                            this.bansheeNeighbours[targetBansheeInd].Add(currentBansheeInd);
                        }
                    }
                }
            }

            public void TraverseDFS(int toVisitIndex, bool[] visited)
            {
                int currentBansheeIndex = toVisitIndex;
                visited[currentBansheeIndex] = true;

                foreach (var neighbourBansheeIndex in this.bansheeNeighbours[currentBansheeIndex])
                {
                    if (!visited[neighbourBansheeIndex])
                    {
                        TraverseDFS(neighbourBansheeIndex, visited);
                    }
                }
            }

            public int GetConnectedComponentsCount()
            {
                bool[] visited = new bool[this.banshees.Length];
                bool allAreVisited = false;
                int connectedComponentsCount = 0;

                int traverseStartIndex = 0;
                while (!allAreVisited)
                {
                    connectedComponentsCount++;

                    TraverseDFS(traverseStartIndex, visited);

                    allAreVisited = true;
                    for (int i = 0; i < visited.Length; i++)
                    {
                        if (!visited[i])
                        {
                            traverseStartIndex = i;
                            allAreVisited = false;
                            break;
                        }
                    }
                }

                return connectedComponentsCount;
            }
        }
    }
}
