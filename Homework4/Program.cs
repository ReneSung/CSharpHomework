using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework4
{
  internal class Program
  {
    /// <summary>
    /// Заполнение списка рандомными записями.
    /// </summary>
    /// <param name="manager">Объект EmployeeManager.</param>
    private static void FillOutList(ref EmployeeManager<Employee> manager)
    {
      manager.employees = new List<Employee>();
      manager.employees.Add(new FullTimeEmployee("Иванов Иван", 1000));
      manager.employees.Add(new FullTimeEmployee("Боб", 2000));
      manager.employees.Add(new PartTimeEmployee("Стив", 20, 50));
      manager.employees.Add(new PartTimeEmployee("Дмитрий", 50, 50));
    }

    /// <summary>
    /// Добавить сотрудника.
    /// </summary>
    /// <param name="employee">Тип объекта, FullTimeEmployee или PartTimeEmployee.</param>
    /// <param name="manager">Объект EmployeeManager.</param>
    private static void AddEmployee(Employee employee, EmployeeManager<Employee> manager)
    {
      Console.WriteLine("Введите имя");
      string name = Console.ReadLine();

      Console.WriteLine("Введите оклад.");
      string salary = Console.ReadLine();

      if (name == string.Empty || salary == string.Empty)
      {
        Console.WriteLine("Необходимо ввести данные.\n" +
                          "Нажмите любую клавишу, чтобы продолжить");
        Console.ReadKey();
      }
      else
      {
        if (employee is PartTimeEmployee)
        {
          Console.WriteLine("Введите количество отработанных часов");
          int workedHours = int.Parse(Console.ReadLine());
          PartTimeEmployee partTimeEmployee = new PartTimeEmployee(name, decimal.Parse(salary), workedHours);
          manager.employees.Add(partTimeEmployee);
        }
        else if (employee is FullTimeEmployee)
        {
          FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(name, decimal.Parse(salary));
          manager.employees.Add(fullTimeEmployee);
        }
      }
    }

    /// <summary>
    /// Вывести запись по имени.
    /// </summary>
    /// <param name="manager">Объект EmployeeManager.</param>
    private static void FindEmployee(EmployeeManager<Employee> manager)
    {
      Console.WriteLine("Введите имя сотрудника");
      string name = Console.ReadLine();

      Console.WriteLine();

      if (manager.Get(name) == null)
        Console.WriteLine("Сотрудник не найден.");
      else if (manager.Get(name) is FullTimeEmployee)
      {
        FullTimeEmployee fullTimeEmployee = manager.Get(name) as FullTimeEmployee;
        Console.WriteLine($"Имя: {fullTimeEmployee.Name}\n" +
                          $"Оклад: {fullTimeEmployee.Basesalary}\n" +
                          $"Зарплата: {fullTimeEmployee.CalculateSalary()}");
      }
      else if (manager.Get(name) is PartTimeEmployee)
      {
        PartTimeEmployee partTimeEmployee = manager.Get(name) as PartTimeEmployee;
        Console.WriteLine($"Имя: {partTimeEmployee.Name}\n" +
                          $"Оклад {partTimeEmployee.Basesalary}\n" +
                          $"Отработанные часы: {partTimeEmployee.Hours}\n" +
                          $"Зарплата: {partTimeEmployee.CalculateSalary()}");
      }
      Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
      Console.ReadKey();
    }

    /// <summary>
    /// Обновить оклад сотрудника.
    /// </summary>
    /// <param name="manager">Объект EmployeeManager.</param>
    private static void UpdateSalaryEmployee(EmployeeManager<Employee> manager)
    {
      Console.WriteLine("Введите имя сотрудника");
      string name = Console.ReadLine();

      Console.WriteLine("Введите  новый размер оклада");
      decimal salary = decimal.Parse(Console.ReadLine());

      if (manager.Get(name) is FullTimeEmployee)
      {
        FullTimeEmployee employee = manager.Get(name) as FullTimeEmployee;
        employee.Basesalary = salary;
        manager.Update(employee);
      }
      else if (manager.Get(name) is PartTimeEmployee)
      {
        PartTimeEmployee employee = manager.Get(name) as PartTimeEmployee;
        employee.Basesalary = salary;
        manager.Update(employee);
      }
    }

    /// <summary>
    /// Вывести список сотрудников в консоль.
    /// </summary>
    /// <param name="manager">Объект EmployeeManager.</param>
    private static void PrintEmployeeList(EmployeeManager<Employee> manager)
    {
      Console.WriteLine("Список сотрудников\n" +
                        "=======================\n");
      foreach (var i in manager.employees)
      {
        if (i is FullTimeEmployee)
         Console.WriteLine($"Имя: {i.Name}\n" +
                            $"Оклад: {i.Basesalary}\n" +
                            $"Размер оплаты: {i.CalculateSalary()}\n");
        else if (i is PartTimeEmployee)
        {
          PartTimeEmployee prtTimeEmployee = i as PartTimeEmployee;
          Console.WriteLine($"Имя: {prtTimeEmployee.Name}\n" +
                            $"Оклад: {prtTimeEmployee.Basesalary}\n" +
                            $"Отработанные часы: {prtTimeEmployee.Hours}\n" +
                            $"Размер оплаты: {prtTimeEmployee.CalculateSalary()}\n");
        }
      }
    }

    static void Main(string[] args)
    {
      bool isRunning = true;

      EmployeeManager<Employee> manager = new EmployeeManager<Employee>();
      FillOutList(ref manager);
      while (isRunning)
      {
        PrintEmployeeList(manager);

        Console.WriteLine("\n1 - Добавить полного сотрудника\n" +
                          "2 - Добавить частичного сотрудника\n" +
                          "3 - получить информацию о сотруднике\n" +
                          "4 - обновить данные сотрудника\n" +
                          "5 - выйти");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee();
            AddEmployee(fullTimeEmployee, manager);
            break;
          case "2":
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee();
            AddEmployee(partTimeEmployee, manager);
            break;
          case "3":
            FindEmployee(manager);
            break;
          case "4":
            UpdateSalaryEmployee(manager);
            break;
          case "5":
            isRunning = false;
            break;
        }
      }
    }
  }
}
