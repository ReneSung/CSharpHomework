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
    /// Колекция.
    /// </summary>
    private List<T> employees = new List<T>();

    /// <summary>
    /// Коллекция для чтения.
    /// </summary>
    public IReadOnlyCollection<T> Employees
    {
      get
      {
        return employees.AsReadOnly();
      }
    }

    #endregion

    #region Интерфейс IEmployeeManager

    public void Add(T employee)
    {
      employees.Add(employee);
    }

    public T Get(string name)
    {
      return employees.FirstOrDefault(e => e.Name == name);
    }

    public void Update(T employee)
    {
      int index = employees.IndexOf(Get(employee.Name));
      employees[index] = employee;
    }

    #endregion
  }
}
