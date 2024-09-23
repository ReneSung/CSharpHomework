namespace Homework4
{
  /// <summary>
  /// Интерфейс управления сотрудниками.
  /// </summary>
  /// <typeparam name="T">Объек Employee.</typeparam>
  internal interface IEmployeeManager<T>
	{
    #region Методы.

    /// <summary>
    /// Добавить сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Add(T employee);

    /// <summary>
    /// Получить сотрудника по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns></returns>
    T Get(string name);

    /// <summary>
    /// Обновить информацию о сотруднике.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Update(T employee);

    #endregion
  }
}
