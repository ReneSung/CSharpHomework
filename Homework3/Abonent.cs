using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
  /// <summary>
  /// Абонент.
  /// </summary>
  internal class Abonent
  {
		#region Поля и свойства

    /// <summary>
    /// Имя абонента.
    /// </summary>
		public string Name { get; set; }

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public long PhoneNumber { get; set; }

		#endregion

		#region Методы

		/// <summary>
		/// Сравнить объекты.
		/// </summary>
		/// <param name="obj">Объект для сравнения.</param>
		/// <returns>True, если значения объектов равны. Иначе - false.</returns>
		public override bool Equals(object obj)
    {
      Abonent other = obj as Abonent;
      return other.Name.ToLower() == Name.ToLower() && other.PhoneNumber == PhoneNumber;
    }

    /// <summary>
    /// Получить хэш объекта.
    /// </summary>
    /// <returns>Хэш объекта.</returns>
    public override int GetHashCode()
    {
      int hashCode = 1992402788;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      hashCode = hashCode * -1521134295 + PhoneNumber.GetHashCode();
      return hashCode;
    }

		#endregion

		#region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
		public Abonent(string name, long phoneNumber)
    {
      this.Name = name;
      this.PhoneNumber = phoneNumber;
    }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="phoneNumber">Номер телефона.</param>
		public Abonent(long phoneNumber)
      : this(string.Empty, phoneNumber)
    {
      this.PhoneNumber = phoneNumber;
    }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="name">Имя.</param>
		public Abonent(string name)
      : this(name, 0)
    {
      this.Name = name;
    }

		#endregion
	}
}
