using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Labyrinth
{
    public static class LabyrinthWalk
    {
        private const string startSymbol = "*";
        private const string wallSymbol = "x";
        private const string unreachableSymbol = "u";

        private static bool IsInRange(Coord position, string[,] matrix)
        {

            if (position.Y >= matrix.GetLength(0) || position.X >= matrix.GetLength(1) ||
                position.X < 0 || position.Y < 0)
            {
                return false;
            }

            return true;
        }

        private static bool MoveDirection(string[,] inputField, Coord currentPosition, Coord nextPosition)
        {
            if (!IsInRange(nextPosition, inputField))
            {
                return false;
            }

            if (inputField[nextPosition.Y, nextPosition.X] == wallSymbol
                || inputField[nextPosition.Y, nextPosition.X] != "0")
            {
                return false;
            }

            var nextValue = 1;
            if (inputField[currentPosition.Y, currentPosition.X] != "*")
            {
                nextValue = (int.Parse(inputField[currentPosition.Y, currentPosition.X]) + 1);
            }

            inputField[nextPosition.Y, nextPosition.X] = nextValue.ToString();

            return true;
        }

        private static void PerformMove(string[,] inputField, Coord currentPosition, Queue<Coord> positionsQueue)
        {
            //Building Coords with the possible directions
            //1.Down
            //2.Right
            //3.Up
            //4.Left
            Coord[] possibleDirections = {
                new Coord(currentPosition.Y+1, currentPosition.X),
                new Coord(currentPosition.Y, currentPosition.X + 1),
                new Coord(currentPosition.Y-1, currentPosition.X),
                new Coord(currentPosition.Y, currentPosition.X-1)
            };

            foreach (var direction in possibleDirections)
            {

                var isMoveSuccessful = MoveDirection(inputField, currentPosition, direction);

                if (isMoveSuccessful)
                {
                    positionsQueue.Enqueue(direction);
                }
            }

        }

        public static string[,] Walk(string[,] inputField)
        {
            var positionsQueue = new Queue<Coord>();
            positionsQueue.Enqueue(FindStartIndex(inputField));

            while (positionsQueue.Count > 0)
            {
                var currentPosition = positionsQueue.Dequeue();
                PerformMove(inputField, currentPosition, positionsQueue);
            }

            ReplaceZeros(inputField);

            return inputField;
        }

        private static void ReplaceZeros(string[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)

                    if (matrix[row, col] == "0")
                    {
                        matrix[row, col] = "u";
                    }
            }

        }



        private static Coord FindStartIndex(string[,] matrix)
        {
            var startCoords = new Coord();
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == "*")
                    {
                        startCoords.X = col;
                        startCoords.Y = row;

                        return startCoords;
                    }
                }

            }

            throw new ArgumentException("Start index cannot be found!");
        }
    }
}
