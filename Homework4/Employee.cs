namespace Homework4
{
  /// <summary>
  /// Абстрактный класс сотрудника.
  /// </summary>
  internal abstract class Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Оклад.
    /// </summary>
    public abstract decimal Basesalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать зарплату сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public abstract decimal CalculateSalary();

    #endregion
  }
}
