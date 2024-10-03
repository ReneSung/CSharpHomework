using System;

namespace Homework5
{
  /// <summary>
  /// Пользователь не найден.
  /// </summary>
  internal class UserNotFoundException : Exception
  {
    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public UserNotFoundException(string message)
      : base(message) { }

    #endregion
  }
}
