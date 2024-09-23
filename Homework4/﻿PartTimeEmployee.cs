using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
  internal class PartTimeEmployee : Employee
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

    /// <summary>
    /// Отработанные часы.
    /// </summary>
    public int Hours { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать зарплату сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public override decimal CalculateSalary()
    {
      return this.Basesalary * Hours;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="baseSalary">Оклаад.</param>
    /// <param name="hours">Часы.</param>
    public PartTimeEmployee(string name, decimal baseSalary, int hours)
    {
      this.Name = name;
      this.Basesalary = baseSalary;
      this.Hours = hours;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    public PartTimeEmployee() { }

    #endregion
  }
}
