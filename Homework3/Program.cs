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
      Console.InputEncoding = Encoding.GetEncoding("UTF-16");
      Phonebook phonebook = Phonebook.GetInstance();
      phonebook.PrintAbonentList();
      Console.WriteLine("Введите имя абонента");
      string name = Console.ReadLine();
      Console.WriteLine("Введите номер абонента");
      string phoneNumber = Console.ReadLine();
      Console.Clear();
      Abonent abonent = new Abonent(name, phoneNumber);
      phonebook.DropAbonent(abonent);
      phonebook.PrintAbonentList();
      Console.ReadKey();
    }
  }
}
