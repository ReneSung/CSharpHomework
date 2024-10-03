using System;

namespace Homework5
{
  internal class Program
  {
    /// <summary>
    /// Вывести список пользователей в консоль.
    /// </summary>
    /// <param name="userManager">Объект userManager.</param>
    private static void PrintUsers(UserManager userManager)
    {
      foreach (var item in userManager.ListUsers())
      {
        Console.WriteLine($"id: {item.Id}\n" +
                          $"Имя: {item.Name}\n" +
                          $"Email: {item.Email}\n");
      }
    }

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="userManager">Объект userManager</param>
    /// <param name="user">Объект User.</param>
    private static void AddUser(UserManager userManager, User user)
    {
      try
      {
        userManager.AddUser(user);
        Console.WriteLine("Пользователь добавлен");
      }
      catch (UserAlreadyExistsException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Удалить пользователя по id.
    /// </summary>
    private static void RemoveUser(UserManager userManager, int id)
    {
      try
      {
        userManager.RemoveUser(id);
        Console.WriteLine("Пользователь удален");
      }
      catch (UserNotFoundException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Вывести полльзователя по id.
    /// </summary>
    /// <param name="userManager">Объект UserManager.</param>
    /// <param name="id">Id.</param>
    private static void FindUser(UserManager userManager, int id)
    {
      try
      {
        User user = userManager.GetUser(id);

        Console.WriteLine($"id: {user.Id}\n" +
                            $"Имя: {user.Name}\n" +
                            $"Email: {user.Email}\n");
      }
      catch (UserNotFoundException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();

      bool isRunning = true;

      while (isRunning)
      {
        Console.WriteLine("1 - добавить пользователя\n" +
                          "2 - удалить пользователя по id\n" +
                          "3 - найти пользователя по id\n" +
                          "4 - вывести всех пользователей\n" +
                          "5 - выйти из программы");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            Console.Clear();
            
            try
            {
              Console.WriteLine("Введите id пользователя");
              int userId = int.Parse(Console.ReadLine());

              Console.WriteLine("Введите имя пользователя");
              string name = Console.ReadLine();

              Console.WriteLine("Введите адрес электронной почты");
              string email = Console.ReadLine();

              User user = new User(userId, name, email);

              Console.Clear();

              AddUser(userManager, user);
            }
            catch (FormatException ex)
            {
              Console.WriteLine($"id: {ex.Message}");
            }

            break;
          case "2":
            Console.Clear();
            Console.WriteLine("Введите id пользователя");

            try
            {
              int userId = int.Parse(Console.ReadLine());
              Console.Clear();
              RemoveUser(userManager, userId);
            }
            catch (FormatException ex)
            {
              Console.WriteLine($"id: {ex.Message}");
            }
            break;
          case "3":
            Console.Clear();
            try
            {
              Console.WriteLine("Введите id пользователя");
              int userId = int.Parse(Console.ReadLine());
              Console.Clear();
              FindUser(userManager, userId);
            }
            catch (FormatException ex)
            {
              Console.WriteLine($"id: {ex.Message}");
            }

            break;
          case "4":
            Console.Clear();
            PrintUsers(userManager);
            
            break;
          case "5":
            isRunning = false;

            break;
        }
      }
    }
  }
}
