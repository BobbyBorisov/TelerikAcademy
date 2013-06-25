using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5___Horse_Matrix
{
    class HorseMatrix
    {
        static readonly int[] rowDirection = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
        static readonly int[] colDirection = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        static int N;
        static char[,] matrix;

        static void Main()
        {
            ReadInput();

            List<int> path = GetShortestPath();

            // PrintOutput(path);

            if (path.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(path.Count - 1);
            }
        }

        static void ReadInput()
        {
            N = int.Parse(Console.ReadLine());
            matrix = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = row[j][0];
                }
            }
        }

        static bool IsInMatrix(int row, int col)
        {
            if (row >= 0 && row < N && col >= 0 && col < N)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static List<int> GetShortestPath()
        {
            Queue<int> queue = new Queue<int>();
            bool[,] used = new bool[N, N];
            int[,] previous = new int[N, N];
            int endCell = 0;
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    switch (matrix[row, column])
                    {
                        case 's':
                            {
                                queue.Enqueue(row * N + column);
                                used[row, column] = true;
                                previous[row, column] = -1;
                                break;
                            }
                        case 'e':
                            {
                                endCell = row * N + column;
                                break;
                            }
                    }
                }
            }

            while (queue.Count > 0)
            {
                int currentCell = queue.Dequeue();
                int row = currentCell / N;
                int col = currentCell % N;
                for (int i = 0; i < rowDirection.Length; i++)
                {
                    int newRow = row + rowDirection[i];
                    int newCol = col + colDirection[i];
                    if (!IsInMatrix(newRow, newCol) ||
                        used[newRow, newCol] ||
                        matrix[newRow, newCol] == 'x')
                    {
                        continue;
                    }
                    previous[newRow, newCol] = row * N + col;
                    queue.Enqueue(newRow * N + newCol);
                    used[newRow, newCol] = true;
                }
            }

            List<int> path = new List<int>();
            if (used[endCell / N, endCell % N])
            {
                for (int cell = endCell;
                    cell != -1;
                    cell = previous[cell / N, cell % N])
                {
                    path.Add(cell);
                }
                path.Reverse();
            }
            return path;
        }

        /*
        static void PrintOutput(List<int> path)
        {
            if (path.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(path.Count - 1);
                for (int i = 0; i < path.Count; i++)
                {
                    if (i > 0)
                    {
                        Console.Write(" -> ");
                    }
                    Console.Write("({0}, {1})", path[i] / N, path[i] % N);
                }
                Console.WriteLine();
            }
        }
         */
    }
}
