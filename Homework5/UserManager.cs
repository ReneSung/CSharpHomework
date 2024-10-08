﻿using System;
using System.Collections.Generic;

namespace Homework5
{
  /// <summary>
  /// Управление пользователями.
  /// </summary>
  internal class UserManager
  {
    #region

    /// <summary>
    /// Коллекция.
    /// </summary>
    private readonly List<User> users = new List<User>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="user">Объект User.</param>
    /// <exception cref="UserAlreadyExistsException">Пользователь с переданным id уже есть.</exception>
    public void AddUser(User user)
    {
      if (this.users.Exists(u => u.Id == user.Id))
        throw new UserAlreadyExistsException($"Пользователь с id {user.Id} уже существует!");

      this.users.Add(user);
    }

    /// <summary>
    /// Удалить пользователя по id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <exception cref="UserNotFoundException">Пользователь не найден.</exception>
    public void RemoveUser(int id)
    {
      int index = this.users.IndexOf(users.Find(u => u.Id == id));
      if (index == -1)
        throw new UserNotFoundException("Пользователь не найден");

      this.users.RemoveAt(index);
    }

    /// <summary>
    /// Получить список пользователей.
    /// </summary>
    public List<User> ListUsers() => this.users;

    /// <summary>
    /// Получить пользователя по id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns>Объект User.</returns>
    /// <exception cref="UserNotFoundException">Пользователь не найден.</exception>
    public User GetUser(int id)
    {
      int index = this.users.IndexOf(users.Find(u => u.Id == id));
      if (index == -1)
        throw new UserNotFoundException("Пользователь не найден");

      return this.users[index];
    }

    #endregion
  }
}
