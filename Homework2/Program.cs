using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework2
{
  public class Program
  {
    /*/// <summary>
    /// Задать начальную структуру поля.
    /// </summary>
    static char[] DefaultStructPlayingField()
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
    static void PlayerTurn(ref char[] field, char value)
    {

      bool endTurn = false;
      while (!endTurn)
      {
        Console.WriteLine($"Ход {value}");
        char inputCellNumber = char.Parse(Console.ReadLine());
        if (field.Contains(inputCellNumber) && inputCellNumber != 'X' && inputCellNumber != 'O')
        {
          for (int i = 0; i < field.Length; i++)
          {
            if (field[i] == inputCellNumber) { field[i] = value; break; }
          }
          endTurn = true;
        }
        else { Console.WriteLine("Введены неверные данные"); }
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
    static string CheckWinner(char[] field, char value)
    {
      string winner = string.Empty;
      if (field[0] == value && field[1] == value && field[2] == value) { winner = value.ToString(); }
      else if (field[3] == value && field[4] == value && field[5] == value) { winner = value.ToString(); }
      else if (field[6] == value && field[7] == value && field[8] == value) { winner = value.ToString(); }
      else if (field[0] == value && field[3] == value && field[6] == value) { winner = value.ToString(); }
      else if (field[1] == value && field[4] == value && field[7] == value) { winner = value.ToString(); }
      else if (field[2] == value && field[5] == value && field[8] == value) { winner = value.ToString(); }
      else if (field[0] == value && field[4] == value && field[8] == value) { winner = value.ToString(); }
      else if (field[2] == value && field[4] == value && field[6] == value) { winner = value.ToString(); }
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
    static void PrintField(char[] field)
    {
      for (int i = 0; i < field.Length; i++)
      {
        Console.Write(" ");
        Console.Write(field[i]);
        Console.Write(" ");
        if ((i + 1) % 3 != 0) Console.Write("|");
        if ((i + 1) % 3 == 0 && i + 1 != 9) { Console.WriteLine("\n---|---|---"); }
      }
      Console.WriteLine();
    }

    /// <summary>
    /// Ход компьютера.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <param name="computerValue">Символ компьютера.</param>
    /// <param name="playerValue">Символ игрока.</param>
    static void ComputerTurn(ref char[] field, char computerValue, char playerValue)
    {
      Console.WriteLine("Ход противника");
      Thread.Sleep(2000);
      int cellCounter = 0;
      for (int i = 0; i < field.Length; i++)
      {
        if (field[i] != 'X' && field[i] != 'O') { cellCounter++; }
      }
      int[] freeCells = new int[cellCounter];
      int index = 0;
      for (int i = 0; i < field.Length; i++)
      {
        if (field[i] != 'X' && field[i] != 'O')
        {
          freeCells[index] = i;
          index++;
        }
      }
      //Проверка победной комбинации по горизонтали
      if (field[0] == computerValue && field[1] == computerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      else if (field[0] == computerValue && field[2] == computerValue && field[1] != 'X' && field[1] != 'O') { field[1] = computerValue; }
      else if (field[1] == computerValue && field[2] == computerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[3] == computerValue && field[4] == computerValue && field[5] != 'X' && field[5] != 'O') { field[5] = computerValue; }
      else if (field[3] == computerValue && field[5] == computerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == computerValue && field[5] == computerValue && field[3] != 'X' && field[3] != 'O') { field[3] = computerValue; }
      else if (field[6] == computerValue && field[7] == computerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[6] == computerValue && field[8] == computerValue && field[7] != 'X' && field[7] != 'O') { field[7] = computerValue; }
      else if (field[7] == computerValue && field[8] == computerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      //Проверка победной комбинации по вертикали
      else if (field[0] == computerValue && field[3] == computerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      else if (field[0] == computerValue && field[6] == computerValue && field[3] != 'X' && field[3] != 'O') { field[3] = computerValue; }
      else if (field[3] == computerValue && field[6] == computerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[1] == computerValue && field[4] == computerValue && field[7] != 'X' && field[7] != 'O') { field[7] = computerValue; }
      else if (field[1] == computerValue && field[7] == computerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == computerValue && field[7] == computerValue && field[1] != 'X' && field[1] != 'O') { field[1] = computerValue; }
      else if (field[2] == computerValue && field[5] == computerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[2] == computerValue && field[8] == computerValue && field[5] != 'X' && field[5] != 'O') { field[5] = computerValue; }
      else if (field[5] == computerValue && field[8] == computerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      //Проверка победной комбинации по диагонали
      else if (field[0] == computerValue && field[4] == computerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[0] == computerValue && field[8] == computerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == computerValue && field[8] == computerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[2] == computerValue && field[4] == computerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      else if (field[2] == computerValue && field[6] == computerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == computerValue && field[6] == computerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      //Блокировка игрока по горизонтали
      else if (field[0] == playerValue && field[1] == playerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      else if (field[0] == playerValue && field[2] == playerValue && field[1] != 'X' && field[1] != 'O') { field[1] = computerValue; }
      else if (field[1] == playerValue && field[2] == playerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[3] == playerValue && field[4] == playerValue && field[5] != 'X' && field[5] != 'O') { field[5] = computerValue; }
      else if (field[3] == playerValue && field[5] == playerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == playerValue && field[5] == playerValue && field[3] != 'X' && field[3] != 'O') { field[3] = computerValue; }
      else if (field[6] == playerValue && field[7] == playerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[6] == playerValue && field[8] == playerValue && field[7] != 'X' && field[7] != 'O') { field[7] = computerValue; }
      else if (field[7] == playerValue && field[8] == playerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      //Блокировка игрока по вертикали
      else if (field[0] == playerValue && field[3] == playerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      else if (field[0] == playerValue && field[6] == playerValue && field[3] != 'X' && field[3] != 'O') { field[3] = computerValue; }
      else if (field[3] == playerValue && field[6] == playerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[1] == playerValue && field[4] == playerValue && field[7] != 'X' && field[7] != 'O') { field[7] = computerValue; }
      else if (field[1] == playerValue && field[7] == playerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == playerValue && field[7] == playerValue && field[1] != 'X' && field[1] != 'O') { field[1] = computerValue; }
      else if (field[2] == playerValue && field[5] == playerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[2] == playerValue && field[8] == playerValue && field[5] != 'X' && field[5] != 'O') { field[5] = computerValue; }
      else if (field[5] == playerValue && field[8] == playerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      //Блокировка игрока по диагонали
      else if (field[0] == playerValue && field[4] == playerValue && field[8] != 'X' && field[8] != 'O') { field[8] = computerValue; }
      else if (field[0] == playerValue && field[8] == playerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == playerValue && field[8] == playerValue && field[0] != 'X' && field[0] != 'O') { field[0] = computerValue; }
      else if (field[2] == playerValue && field[4] == playerValue && field[6] != 'X' && field[6] != 'O') { field[6] = computerValue; }
      else if (field[2] == playerValue && field[6] == playerValue && field[4] != 'X' && field[4] != 'O') { field[4] = computerValue; }
      else if (field[4] == playerValue && field[6] == playerValue && field[2] != 'X' && field[2] != 'O') { field[2] = computerValue; }
      else
      {
        Random random = new Random();
        int randomCell = random.Next(freeCells.Length);
        field[freeCells[randomCell]] = computerValue;
      }
    }
*/
    static void Main(string[] args)
    {
      /*Console.WriteLine("Выберете режим игры");
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
                PlayerTurn(ref field, 'X');
                Console.Clear();
                PrintField(field);
                if (CheckWinner(field, 'X') == "X")
                {
                  Console.WriteLine("Победили X");
                  break;
                }
                else if (CheckWinner(field, 'X') == "draw")
                {
                  Console.WriteLine("Ничья");
                  break;
                }
                ComputerTurn(ref field, 'O', 'X');
                Console.Clear();
                PrintField(field);
                if (CheckWinner(field, 'O') == "O")
                {
                  Console.WriteLine("Победили O");
                  break;
                }
                else if (CheckWinner(field, 'O') == "draw")
                {
                  Console.WriteLine("Ничья");
                  break;
                }
              }
              break;
            case '2':
              while (true)
              {
                ComputerTurn(ref field, 'X', 'O');
                Console.Clear();
                PrintField(field);
                if (CheckWinner(field, 'X') == "X")
                {
                  Console.WriteLine("Победили X");
                  break;
                }
                else if (CheckWinner(field, 'X') == "draw")
                {
                  Console.WriteLine("Ничья");
                  break;
                }
                PlayerTurn(ref field, 'O');
                Console.Clear();
                PrintField(field);
                if (CheckWinner(field, 'O') == "O")
                {
                  Console.WriteLine("Победили O");
                  break;
                }
                else if (CheckWinner(field, 'O') == "draw")
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
            PlayerTurn(ref field, 'X');
            Console.Clear();
            PrintField(field);

            if (CheckWinner(field, 'X') == "X")
            {
              Console.WriteLine("Победили X");
              break;
            }
            else if (CheckWinner(field, 'X') == "draw")
            {
              Console.WriteLine("Ничья");
              break;
            }
            PlayerTurn(ref field, 'O');
            Console.Clear();
            PrintField(field);
            if (CheckWinner(field, 'O') == "O")
            {
              Console.WriteLine("Победили O");
              break;
            }
            else if (CheckWinner(field, 'O') == "draw")
            {
              Console.WriteLine("Ничья");
              break;
            }
            Console.Clear();
          }
          break;
      }*/
      var ticTacToe = new TicTacToe();
      ticTacToe.Play();
      Console.ReadKey();
    }
  }
}
