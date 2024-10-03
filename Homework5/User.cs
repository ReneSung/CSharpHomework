namespace Homework5
{
  /// <summary>
  /// Пользователь.
  /// </summary>
  internal class User
  {
    #region Поля и свойства

    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; }

    #endregion

    #region Коснтрукторы

    /// <summary>
    /// Коснтруктор.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="name">Имя.</param>
    /// <param name="email">Электронная почта.</param>
    public User(int id, string name, string email)
    {
      this.Id = id;
      this.Name = name;
      this.Email = email;
    }

    #endregion
  }
}
