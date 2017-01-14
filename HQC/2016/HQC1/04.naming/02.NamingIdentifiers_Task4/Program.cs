﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMinesGame
{
	public class Mines
	{
		public class MinesPoints
		{
			string name;
			int points;

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Points
			{
				get { return points; }
				set { points = value; }
			}

			public MinesPoints() { }

			public MinesPoints(string name, int points)
			{
				this.name = name;
				this.points = points;
			}
		}

		static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] field = CreateGameField();
			char[,] bombs = PlaceBombsOnField();
			int counter = 0;
			bool boom = false;
			List<MinesPoints> champions = new List<MinesPoints>(6);
			int row = 0;
			int column = 0;
			bool startFlag = true;
			const int maks = 35;
			bool flag2 = false;

			do
			{
				if (startFlag)
				{
					Console.WriteLine("Let's play the Mines Game. Try to found the fields without mines." +
					" The command 'top' shows the current ranking of the players, 'restart' start a new game, 'exit' exits the game!");
					ShowGameField(field);
					startFlag = false;
				}
				Console.Write("Give me a row and a column: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= field.GetLength(0) && column <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						PrintRanking(champions);
						break;
					case "restart":
						field = CreateGameField();
						bombs = PlaceBombsOnField();
						ShowGameField(field);
						boom = false;
						startFlag = false;
						break;
					case "exit":
						Console.WriteLine("Bye, bye, bye!");
						break;
					case "turn":
						if (bombs[row, column] != '*')
						{
							if (bombs[row, column] == '-')
							{
								PlayerMove(field, bombs, row, column);
								counter++;
							}
							if (maks == counter)
							{
								flag2 = true;
							}
							else
							{
								ShowGameField(field);
							}
						}
						else
						{
							boom = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Invalid command\n");
						break;
				}
				if (boom)
				{
					ShowGameField(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", counter);
					string niknejm = Console.ReadLine();
					MinesPoints t = new MinesPoints(niknejm, counter);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Points < t.Points)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((MinesPoints r1, MinesPoints r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((MinesPoints r1, MinesPoints r2) => r2.Points.CompareTo(r1.Points));
					PrintRanking(champions);

					field = CreateGameField();
					bombs = PlaceBombsOnField();
					counter = 0;
					boom = false;
					startFlag = true;
				}
				if (flag2)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					ShowGameField(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string imeee = Console.ReadLine();
					MinesPoints to4kii = new MinesPoints(imeee, counter);
					champions.Add(to4kii);
					PrintRanking(champions);
					field = CreateGameField();
					bombs = PlaceBombsOnField();
					counter = 0;
					flag2 = false;
					startFlag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void PrintRanking(List<MinesPoints> to4kii)
		{
			Console.WriteLine("\nTo4KI:");
			if (to4kii.Count > 0)
			{
				for (int i = 0; i < to4kii.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, to4kii[i].Name, to4kii[i].Points);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void PlayerMove(char[,] POLE,
			char[,] BOMBI, int RED, int KOLONA)
		{
			char kolkoBombi = kolko(BOMBI, RED, KOLONA);
			BOMBI[RED, KOLONA] = kolkoBombi;
			POLE[RED, KOLONA] = kolkoBombi;
		}

		private static void ShowGameField(char[,] board)
		{
			int RRR = board.GetLength(0);
			int KKK = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < RRR; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < KKK; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateGameField()
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

		private static char[,] PlaceBombsOnField()
		{
			int Редове = 5;
			int Колони = 10;
			char[,] игрално_поле = new char[Редове, Колони];

			for (int i = 0; i < Редове; i++)
			{
				for (int j = 0; j < Колони; j++)
				{
					игрално_поле[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int kol = (i2 / Колони);
				int red = (i2 % Колони);
				if (red == 0 && i2 != 0)
				{
					kol--;
					red = Колони;
				}
				else
				{
					red++;
				}
				игрално_поле[kol, red - 1] = '*';
			}

			return игрално_поле;
		}

		private static void smetki(char[,] pole)
		{
			int kol = pole.GetLength(0);
			int red = pole.GetLength(1);

			for (int i = 0; i < kol; i++)
			{
				for (int j = 0; j < red; j++)
				{
					if (pole[i, j] != '*')
					{
						char kolkoo = kolko(pole, i, j);
						pole[i, j] = kolkoo;
					}
				}
			}
		}

		private static char kolko(char[,] r, int rr, int rrr)
		{
			int brojkata = 0;
			int reds = r.GetLength(0);
			int kols = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rr + 1 < reds)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					brojkata++;
				}
			}
			if (rrr + 1 < kols)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					brojkata++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < kols))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr + 1 < kols))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			return char.Parse(brojkata.ToString());
		}
	}
}
