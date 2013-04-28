namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

	public class Minesweeper
	{
		public class Score
		{
			public Score() {
            }

			public Score(string name, int score)
			{
				this.Name = name;
				this.Points = score;
			}

            public string Name { get; set; }

            public int Points { get; set; }
		}

		public static void Main(string[] args)
		{
			string command = string.Empty;
            char[,] field = CreateField();
			char[,] bombs = InitializeBomb();
			int pointsCount = 0;
			bool isGameOver = false;
			List<Score> players = new List<Score>(6);
			int row = 0;
			int col = 0;
			bool isNewGameStarted = true;
			const int MAX_POINTS = 35;
			bool maxPoints = false;

			do
			{
				if (isNewGameStarted)
				{
					Console.WriteLine("Let's play “Minesweapers”. You should find out all fields without mines" +
					": with 'top' you can view the scorelist, 'restart' to start a new game , 'exit' to exit.");
                    DrawField(field);
					isNewGameStarted = false;
				}

				Console.Write("Enter row and col(ex. 1,2) or /top/restart/exit : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						ShowTopPlayers(players);
						break;
					case "restart":
						field = CreateField();
						bombs = InitializeBomb();
                        DrawField(field);
						isGameOver = false;
						isNewGameStarted = false;
						break;
					case "exit":
						Console.WriteLine("Bye! See you soon!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
                                NextMove(field, bombs, row, col);
								pointsCount++;
							}

							if (MAX_POINTS == pointsCount)
							{
								maxPoints = true;
							}
							else
							{
                                DrawField(field);
							}
						}
						else
						{
							isGameOver = true;
						}

						break;
					default:
						Console.WriteLine("\nThere's no such command\n");
						break;
				}

				if (isGameOver)
				{
					DrawField(bombs);
					Console.Write("\nGame Over! Score:{0}" +
						"\nEnter your name: ", pointsCount);
					string name = Console.ReadLine();
					Score t = new Score(name, pointsCount);
					if (players.Count < 5)
					{
						players.Add(t);
					}
					else
					{
						for (int i = 0; i < players.Count; i++)
						{
							if (players[i].Points < t.Points)
							{
								players.Insert(i, t);
								players.RemoveAt(players.Count - 1);
								break;
							}
						}
					}

					players.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
					players.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
					ShowTopPlayers(players);

                    field = CreateField();
					bombs = InitializeBomb();
					pointsCount = 0;
					isGameOver = false;
					isNewGameStarted = true;
				}

				if (maxPoints)
				{
					Console.WriteLine("\nCongratulation! You have the MAX Score!");
					DrawField(bombs);
					Console.WriteLine("Enter your name: ");
					string name = Console.ReadLine();
					Score points = new Score(name, pointsCount);
                    players.Add(points);
					ShowTopPlayers(players);
                    field = CreateField();
					bombs = InitializeBomb();
					pointsCount = 0;
					maxPoints = false;
					isNewGameStarted = true;
				}
			}
			while (command != "exit");
			Console.Read();
		}

		private static void ShowTopPlayers(List<Score> score)
		{
			Console.WriteLine("\nScore:");
			if (score.Count > 0)
			{
                for (int i = 0; i < score.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",i + 1, score[i].Name, score[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Score list is empty!\n");
			}
		}

		private static void NextMove(char[,] field, char[,] bombs, int row, int col)
		{
            char bombCount = GetSurroundingBombCount(bombs, row, col);
            bombs[row, col] = bombCount;
            field[row, col] = bombCount;
		}

		private static void DrawField(char[,] bombsField)
		{
            int rowCount = bombsField.GetLength(0);
            int colCount = bombsField.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowCount; i++)
			{
				Console.Write("{0} | ", i);
                for (int j = 0; j < colCount; j++)
				{
					Console.Write(string.Format("{0} ", bombsField[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] InitializeBomb()
		{
			int rows = 5;
			int cols = 10;
			char[,] field = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					field[i, j] = '-';
				}
			}

			List<int> bombMap = new List<int>();
            while (bombMap.Count < 15)
			{
				Random random = new Random();
				int randomNumber = random.Next(50);
                if (!bombMap.Contains(randomNumber))
				{
                    bombMap.Add(randomNumber);
				}
			}

            foreach (int bombLocation in bombMap)
			{
                int col = (bombLocation / cols);
                int row = (bombLocation % cols);
                if (row == 0 && bombLocation != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}

				field[col, row - 1] = '*';
			}

			return field;
		}

        private static char GetSurroundingBombCount(char[,] bombsField, int row, int col)
		{
			int bombsCount = 0;
            int rowCount = bombsField.GetLength(0);
            int colCount = bombsField.GetLength(1);

			if (row - 1 >= 0)
			{
                if (bombsField[row - 1, col] == '*')
				{
                    bombsCount++; 
				}
			}

            if (row + 1 < rowCount)
			{
                if (bombsField[row + 1, col] == '*')
				{
                    bombsCount++; 
				}
			}

            if (col - 1 >= 0)
			{
                if (bombsField[row, col - 1] == '*')
				{
                    bombsCount++;
				}
			}

            if (col + 1 < colCount)
			{
                if (bombsField[row, col + 1] == '*')
				{
                    bombsCount++;
				}
			}

            if ((row - 1 >= 0) && (col - 1 >= 0))
			{
                if (bombsField[row - 1, col - 1] == '*')
				{
                    bombsCount++; 
				}
			}

            if ((row - 1 >= 0) && (col + 1 < colCount))
			{
                if (bombsField[row - 1, col + 1] == '*')
				{
                    bombsCount++; 
				}
			}

            if ((row + 1 < rowCount) && (col - 1 >= 0))
			{
                if (bombsField[row + 1, col - 1] == '*')
				{
                    bombsCount++; 
				}
			}

            if ((row + 1 < rowCount) && (col + 1 < rowCount))
			{
                if (bombsField[row + 1, col + 1] == '*')
				{
                    bombsCount++; 
				}
			}

            return char.Parse(bombsCount.ToString());
		}
	}
}
