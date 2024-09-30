using System;

namespace Homework5
{
  /// <summary>
  /// Исключение, пользователь уже ссуществует.
  /// </summary>
  internal class UserAlreadyExistsException : Exception
  {
    #region Конструкторы

    /// <summary>
    /// Конструкторы.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public UserAlreadyExistsException(string message)
      : base(message) { }

    #endregion
  }
}
