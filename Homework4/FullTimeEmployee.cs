using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
  /// <summary>
  /// Полный сотрудник.
  /// </summary>
  internal class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// Оклад.
    /// </summary>
    public override decimal Basesalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать заплату сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public override decimal CalculateSalary()
    {
      return this.Basesalary;
    }
 
    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="salary">Оклад.</param>
    public FullTimeEmployee(string name, decimal salary)
    {
      this.Name = name;
      this.Basesalary = salary;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public FullTimeEmployee() { }

    #endregion
  }
}
