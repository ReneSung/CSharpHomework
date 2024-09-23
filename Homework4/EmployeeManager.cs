using System.Collections.Generic;
using System.Linq;

namespace Homework4
{
  /// <summary>
  /// Класс для управления сотрудниками.
  /// </summary>
  /// <typeparam name="T">Объект Employee.</typeparam>
  internal class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Колекция сотрудников.
    /// </summary>
    public List<T> employees = new List<T>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить сотрудника в коллекцию.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    public void Add(T employee)
    {
      employees.Add(employee);
    }

    /// <summary>
    /// Получить сотрудника из коллекции по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns>Объект Employee.</returns>
    public T Get(string name)
    {
      return employees.FirstOrDefault(e => e.Name == name);
    }

    /// <summary>
    /// Обновить информацию о сотруднике.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    public void Update(T employee)
    {
      int index = employees.IndexOf(Get(employee.Name));
      employees[index] = employee;
    }

    #endregion
  }
}
