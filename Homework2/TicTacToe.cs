using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework2
{
	public class TicTacToe
	{
		private const char cross = 'X';
		private const char nought = 'O';
		public enum PlayerSign
		{
			Cross = 'X',
			Nought = 'O'
		}
		/// <summary>
		/// Задать начальную структуру поля.
		/// </summary>
		private static char[] DefaultStructPlayingField()
		{
			char[] field = new char[9];
			for (int i = 0; i < field.Length; i++)
			{
				field[i] = (char)(i + 49);
			}
			return field;
		}

		/// <summary>
		/// Проверить корректность ввода.
		/// </summary>
		/// <param name="field">Игровое поле.</param>
		/// <param name="value">Значение "X" или "O".</param>
		private static void PlayerTurn(ref char[] field, PlayerSign value)
		{

			bool endTurn = false;
			while (!endTurn)
			{
				Console.WriteLine($"Ход {(char)value}");
				char inputCellNumber = char.Parse(Console.ReadLine());
				if (field.Contains(inputCellNumber) && inputCellNumber != cross && inputCellNumber != nought)
				{
					for (int i = 0; i < field.Length; i++)
					{
						if (field[i] == inputCellNumber)
						{
							field[i] = (char)value;
							break;
						}
					}
					endTurn = true;
				}
				else 
					Console.WriteLine("Введены неверные данные");
			}
		}

		/// <summary>
		/// Проверить на наличии победителя или ничьи.
		/// </summary>
		/// <param name="field">Игровое поле.</param>
		/// <param name="value">Значение "X" или "O".</param>
		/// <returns>
		/// Победитель или ничья. Если результат не определился, будет пустая строка.
		/// </returns>
		private static string CheckWinner(char[] field, PlayerSign value)
		{
			string winner = string.Empty;
			if (field[0] == (char)value && field[1] == (char)value && field[2] == (char)value)
				winner = ((char)value).ToString();
			else if (field[3] == (char)value && field[4] == (char)value && field[5] == (char)value)
				winner = ((char)value).ToString();
			else if (field[6] == (char)value && field[7] == (char)value && field[8] == (char)value)
				winner = ((char)value).ToString();
			else if (field[0] == (char)value && field[3] == (char)value && field[6] == (char)value)
				winner = ((char)value).ToString();
			else if (field[1] == (char)value && field[4] == (char)value && field[7] == (char)value)
				winner = ((char)value).ToString();
			else if (field[2] == (char)value && field[5] == (char)value && field[8] == (char)value)
				winner = ((char)value).ToString();
			else if (field[0] == (char)value && field[4] == (char)value && field[8] == (char)value)
				winner = ((char)value).ToString();
			else if (field[2] == (char)value && field[4] == (char)value && field[6] == (char)value)
				winner = ((char)value).ToString();
			else if (!field.Contains('1') && !field.Contains('2') && !field.Contains('3') && !field.Contains('4') && !field.Contains('5') &&
					!field.Contains('6') && !field.Contains('7') && !field.Contains('8') && !field.Contains('9'))
			{
				winner = "draw";
			}
			return winner;
		}

		/// <summary>
		/// Отобразить отформатированное игровое поле.
		/// </summary>
		/// <param name="field">Игровое поле.</param>
		private static void PrintField(char[] field)
		{
			for (int i = 0; i < field.Length; i++)
			{
				Console.Write(" ");
				Console.Write(field[i]);
				Console.Write(" ");
				if ((i + 1) % 3 != 0)
					Console.Write("|");
				if ((i + 1) % 3 == 0 && i + 1 != 9)
					Console.WriteLine("\n---|---|---");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Ход компьютера.
		/// </summary>
		/// <param name="field">Игровое поле.</param>
		/// <param name="computerValue">Символ компьютера.</param>
		/// <param name="playerValue">Символ игрока.</param>
		private static void ComputerTurn(ref char[] field, PlayerSign computerValue, PlayerSign playerValue)
		{
			Console.WriteLine("Ход противника");
			Thread.Sleep(2000);
			int cellCounter = 0;
			for (int i = 0; i < field.Length; i++)
			{
				if (field[i] != cross && field[i] != nought)
					cellCounter++;
			}
			int[] freeCells = new int[cellCounter];
			int index = 0;
			for (int i = 0; i < field.Length; i++)
			{
				if (field[i] != cross && field[i] != nought)
				{
					freeCells[index] = i;
					index++;
				}
			}
			//Проверка победной комбинации по горизонтали
			if (field[0] == (char)computerValue && field[1] == (char)computerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			else if (field[0] == (char)computerValue && field[2] == (char)computerValue && field[1] != cross && field[1] != nought)
				field[1] = (char)computerValue;
			else if (field[1] == (char)computerValue && field[2] == (char)computerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[3] == (char)computerValue && field[4] == (char)computerValue && field[5] != cross && field[5] != nought)
				field[5] = (char)computerValue;
			else if (field[3] == (char)computerValue && field[5] == (char)computerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)computerValue && field[5] == (char)computerValue && field[3] != cross && field[3] != nought)
				field[3] = (char)computerValue;
			else if (field[6] == (char)computerValue && field[7] == (char)computerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[6] == (char)computerValue && field[8] == (char)computerValue && field[7] != cross && field[7] != nought)
				field[7] = (char)computerValue;
			else if (field[7] == (char)computerValue && field[8] == (char)computerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			//Проверка победной комбинации по вертикали
			else if (field[0] == (char)computerValue && field[3] == (char)computerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			else if (field[0] == (char)computerValue && field[6] == (char)computerValue && field[3] != cross && field[3] != nought)
				field[3] = (char)computerValue;
			else if (field[3] == (char)computerValue && field[6] == (char)computerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[1] == (char)computerValue && field[4] == (char)computerValue && field[7] != cross && field[7] != nought)
				field[7] = (char)computerValue;
			else if (field[1] == (char)computerValue && field[7] == (char)computerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)computerValue && field[7] == (char)computerValue && field[1] != cross && field[1] != nought)
				field[1] = (char)computerValue;
			else if (field[2] == (char)computerValue && field[5] == (char)computerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[2] == (char)computerValue && field[8] == (char)computerValue && field[5] != cross && field[5] != nought)
			field[5] = (char)computerValue;
			else if (field[5] == (char)computerValue && field[8] == (char)computerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			//Проверка победной комбинации по диагонали
			else if (field[0] == (char)computerValue && field[4] == (char)computerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[0] == (char)computerValue && field[8] == (char)computerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)computerValue && field[8] == (char)computerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[2] == (char)computerValue && field[4] == (char)computerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			else if (field[2] == (char)computerValue && field[6] == (char)computerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)computerValue && field[6] == (char)computerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			//Блокировка игрока по горизонтали
			else if (field[0] == (char)playerValue && field[1] == (char)playerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			else if (field[0] == (char)playerValue && field[2] == (char)playerValue && field[1] != cross && field[1] != nought)
				field[1] = (char)computerValue;
			else if (field[1] == (char)playerValue && field[2] == (char)playerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[3] == (char)playerValue && field[4] == (char)playerValue && field[5] != cross && field[5] != nought)
				field[5] = (char)computerValue;
			else if (field[3] == (char)playerValue && field[5] == (char)playerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)playerValue && field[5] == (char)playerValue && field[3] != cross && field[3] != nought)
				field[3] = (char)computerValue;
			else if (field[6] == (char)playerValue && field[7] == (char)playerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[6] == (char)playerValue && field[8] == (char)playerValue && field[7] != cross && field[7] != nought)
				field[7] = (char)computerValue;
			else if (field[7] == (char)playerValue && field[8] == (char)playerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			//Блокировка игрока по вертикали
			else if (field[0] == (char)playerValue && field[3] == (char)playerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			else if (field[0] == (char)playerValue && field[6] == (char)playerValue && field[3] != cross && field[3] != nought)
				field[3] = (char)computerValue;
			else if (field[3] == (char)playerValue && field[6] == (char)playerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[1] == (char)playerValue && field[4] == (char)playerValue && field[7] != cross && field[7] != nought)
				field[7] = (char)computerValue;
			else if (field[1] == (char)playerValue && field[7] == (char)playerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)playerValue && field[7] == (char)playerValue && field[1] != cross && field[1] != nought)
				field[1] = (char)computerValue;
			else if (field[2] == (char)playerValue && field[5] == (char)playerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[2] == (char)playerValue && field[8] == (char)playerValue && field[5] != cross && field[5] != nought)
				field[5] = (char)computerValue;
			else if (field[5] == (char)playerValue && field[8] == (char)playerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			//Блокировка игрока по диагонали
			else if (field[0] == (char)playerValue && field[4] == (char)playerValue && field[8] != cross && field[8] != nought)
				field[8] = (char)computerValue;
			else if (field[0] == (char)playerValue && field[8] == (char)playerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)playerValue && field[8] == (char)playerValue && field[0] != cross && field[0] != nought)
				field[0] = (char)computerValue;
			else if (field[2] == (char)playerValue && field[4] == (char)playerValue && field[6] != cross && field[6] != nought)
				field[6] = (char)computerValue;
			else if (field[2] == (char)playerValue && field[6] == (char)playerValue && field[4] != cross && field[4] != nought)
				field[4] = (char)computerValue;
			else if (field[4] == (char)playerValue && field[6] == (char)playerValue && field[2] != cross && field[2] != nought)
				field[2] = (char)computerValue;
			else
			{
				Random random = new Random();
				int randomCell = random.Next(freeCells.Length);
				field[freeCells[randomCell]] = (char)computerValue;
			}
		}
		public void Play()
		{
			Console.WriteLine("Выберете режим игры");
			Console.WriteLine("1 - одиночная игра");
			Console.WriteLine("2 - 2 игрока");
			char gameMode = char.Parse(Console.ReadLine());


			Console.Clear();
			char[] field = DefaultStructPlayingField();
			switch (gameMode)
			{
				case '1':
					Console.Clear();
					Console.WriteLine("Выберите сторону");
					Console.WriteLine("1 - X");
					Console.WriteLine("2 - O");
					char playerCharacter = char.Parse(Console.ReadLine());
					Console.Clear();
					PrintField(field);
					switch (playerCharacter)
					{
						case '1':
							while (true)
							{
								PlayerTurn(ref field, PlayerSign.Cross);
								Console.Clear();
								PrintField(field);
								if (CheckWinner(field, PlayerSign.Cross) == cross.ToString())
								{
									Console.WriteLine("Победили X");
									break;
								}
								else if (CheckWinner(field, PlayerSign.Cross) == "draw")
								{
									Console.WriteLine("Ничья");
									break;
								}
								ComputerTurn(ref field, PlayerSign.Nought, PlayerSign.Cross);
								Console.Clear();
								PrintField(field);
								if (CheckWinner(field, PlayerSign.Nought) == nought.ToString())
								{
									Console.WriteLine("Победили O");
									break;
								}
								else if (CheckWinner(field, PlayerSign.Nought) == "draw")
								{
									Console.WriteLine("Ничья");
									break;
								}
							}
							break;
						case '2':
							while (true)
							{
								ComputerTurn(ref field, PlayerSign.Cross, PlayerSign.Nought);
								Console.Clear();
								PrintField(field);
								if (CheckWinner(field, PlayerSign.Cross) == cross.ToString())
								{
									Console.WriteLine("Победили X");
									break;
								}
								else if (CheckWinner(field, PlayerSign.Cross) == "draw")
								{
									Console.WriteLine("Ничья");
									break;
								}
								PlayerTurn(ref field, PlayerSign.Nought);
								Console.Clear();
								PrintField(field);
								if (CheckWinner(field, PlayerSign.Nought) == nought.ToString())
								{
									Console.WriteLine("Победили O");
									break;
								}
								else if (CheckWinner(field, PlayerSign.Nought) == "draw")
								{
									Console.WriteLine("Ничья");
									break;
								}
							}
							break;
					}

					break;
				case '2':
					while (true)
					{
						PrintField(field);
						PlayerTurn(ref field, PlayerSign.Cross);
						Console.Clear();
						PrintField(field);

						if (CheckWinner(field, PlayerSign.Cross) == cross.ToString())
						{
							Console.WriteLine("Победили X");
							break;
						}
						else if (CheckWinner(field, PlayerSign.Cross) == "draw")
						{
							Console.WriteLine("Ничья");
							break;
						}
						PlayerTurn(ref field, PlayerSign.Nought);
						Console.Clear();
						PrintField(field);
						if (CheckWinner(field, PlayerSign.Nought) == nought.ToString())
						{
							Console.WriteLine("Победили O");
							break;
						}
						else if (CheckWinner(field, PlayerSign.Nought) == "draw")
						{
							Console.WriteLine("Ничья");
							break;
						}
						Console.Clear();
					}
					break;
			}
		}
	}
}
