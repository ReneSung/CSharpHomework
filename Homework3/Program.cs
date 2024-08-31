using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Phonebook phonebook = Phonebook.GetInstance();
      phonebook.PrintAbonentList();
			bool isRunnig = true;
      while (isRunnig)
      {
				Console.WriteLine("Выберете действие\n" +
												"1 - отобразить список всех контактов\n" +
												"2 - добавить контакт\n" +
												"3 - удалить контакт\n" +
												"4 - отобразить контакты по номеру телефона\n" +
												"5 - отобразить контакты по имени абонента\n" +
												"6 - выйти из программы");
				string userInput = Console.ReadLine();
				string name;
				long phoneNumber;
				Abonent abonent;
				switch (userInput)
				{
					case "1":
						Console.Clear();
						phonebook.PrintAbonentList();
						break;
					case "2":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());
						abonent = new Abonent(name, phoneNumber);
						phonebook.AddAbonent(abonent);
						break;
					case "3":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());
						abonent = new Abonent(name, phoneNumber);
						phonebook.DropAbonent(abonent);
						break;
					case "4":
						Console.Clear();
						Console.WriteLine("Введите номер абонента");
						phoneNumber = long.Parse(Console.ReadLine());
						abonent = new Abonent(phoneNumber);
						phonebook.PrintAbonentByPhoneNumber(abonent);
						break;
					case "5":
						Console.Clear();
						Console.WriteLine("Введите имя абонента");
						name = Console.ReadLine();
						abonent = new Abonent(name);
						phonebook.PrintAbonentByName(abonent);
						break;
					case "6":
						isRunnig = false;
						break;
				}
			}
    }
  }
}
