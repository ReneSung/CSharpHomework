using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
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
