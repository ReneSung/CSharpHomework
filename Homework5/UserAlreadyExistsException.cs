using System;

namespace Homework5
{
  /// <summary>
  /// Исключение, пользователь уже существует.
  /// </summary>
  internal class UserAlreadyExistsException : Exception
  {
    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public UserAlreadyExistsException(string message)
      : base(message) { }

    #endregion
  }
}
