using System;
using System.Text;

namespace Homework3
{
  internal class Program
  {
    static void Main(string[] args)
    {
			Console.InputEncoding = Encoding.GetEncoding(1251);
			var phonebook = Phonebook.GetInstance();
			bool isRunnig = true;
			while (isRunnig)
			{
				Console.WriteLine("Выберете действие\n" +
												"1 - добавить контакт\n" +
												"2 - удалить контакт\n" +
												"3 - отобразить контакты по номеру телефона\n" +
												"4 - отобразить контакты по имени абонента\n" +
												"5 - выйти из программы");
				string userInput = Console.ReadLine();
				string name;
				long phoneNumber;
				Abonent abonent;
				switch (userInput)
				{
					case "1":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());
						abonent = new Abonent(name, phoneNumber);
						if (phonebook.AddAbonent(abonent))
							Console.WriteLine("Абонент добавлен");
						else
							Console.WriteLine("Такой абонент уже есть");
						break;
					case "2":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());
						abonent = new Abonent(name, phoneNumber);
						if (phonebook.DropAbonent(abonent))
							Console.WriteLine("Абонент удален");
						else
							Console.WriteLine("Абонент не найден");
						break;
					case "3":
						Console.Clear();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());

						abonent = new Abonent(phoneNumber);

						if (phonebook.GetAbonentByPhoneNumber(abonent).Count > 0)
						{
							foreach (var entry in phonebook.GetAbonentByPhoneNumber(abonent))
							{
								Console.WriteLine($"{entry.Name}: {entry.PhoneNumber}");
							}
						}
						else
							Console.WriteLine("Абонент не найден");
						break;
					case "4":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						abonent = new Abonent(name);
            if (phonebook.GetAbonentByName(abonent).Count > 0)
            {
              foreach (var entry in phonebook.GetAbonentByName(abonent))
              {
                Console.WriteLine($"{entry.Name}: {entry.PhoneNumber}");
              }
            }
            else
              Console.WriteLine("Абонент не найден");
            phonebook.GetAbonentByName(abonent);
						break;
					case "5":
						isRunnig = false;
						break;
				}
			}
		}
  }
}
