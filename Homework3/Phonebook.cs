using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework3
{
  internal class Phonebook
  {
    private static Phonebook instance;
    private static string path = "phonebook.txt";
    public List<Abonent> AbonentList { get; }

    /// <summary>
    /// Добавляет нового абонента в коллекцию AbonentList и записывает абонента в конец файла.
    /// </summary>
    /// <param name="abonent">Объект Abonent с именем и номером телефона.</param>
    public void AddAbonent(Abonent abonent)
    {
      bool isFreeEntry = true;
      foreach (var entry in AbonentList)
      {
        if (entry.Name.ToLower() == abonent.Name.ToLower() && entry.PhoneNumber == abonent.PhoneNumber)
        {
          isFreeEntry = false;
          break;
        }
      }
      if (isFreeEntry)
      {
        AbonentList.Add(abonent);
        using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
        {
          sw.WriteLine($"{abonent.Name}: {abonent.PhoneNumber}");
        }
        Console.WriteLine("Добавлен новый абонент.");
      }
      else
        Console.WriteLine("Абонент с таким именем уже есть.");
    }

    /// <summary>
    /// Вывод абонентов в консоль.
    /// </summary>
    public void PrintAbonentList()
    {
      foreach (var abonent in AbonentList)
      {
        Console.WriteLine($"{abonent.Name}: {abonent.PhoneNumber}");
      }
    }
    
    /// <summary>
    /// Удалить объект из коллекции AbonentList, перезаписать обновленную коллекцию в файл.
    /// </summary>
    /// <param name="abonent">Объект Abonent с именем и номером телефона.</param>
    public void DropAbonent(Abonent abonent)
    {
      bool isDrop = false;
      for (int i = 0; i < this.AbonentList.Count; i++)
      {
        if (this.AbonentList[i].Name.ToLower() == abonent.Name.ToLower() && this.AbonentList[i].PhoneNumber == abonent.PhoneNumber)
        {
          AbonentList.RemoveAt(i);
          using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
          {
            foreach (var entry in this.AbonentList)
            {
              sw.WriteLine($"{entry.Name}: {entry.PhoneNumber}");
            }
          }
          isDrop = true;
          break;
        }
      }

      if (isDrop)
        Console.WriteLine("Абонент удален");
      else
        Console.WriteLine("Абонент не найден");
    }

    public List<Abonent> GetAbonentByPhoneNumber(Abonent abonent)
    {
      //List<Abonent> filteredList = this.AbonentList.Where(a => a.PhoneNumber == "1111");
      return this.AbonentList;
    }
    public static Phonebook GetInstance()
    {
      if (instance == null)
        instance = new Phonebook();
      return instance;
    }
    private Phonebook()
    {
			using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
			{
				//string line = string.Empty;
				this.AbonentList = new List<Abonent>();
				while (!sr.EndOfStream)
				{
					string[] split = Regex.Split(sr.ReadLine(), ": ");
					Abonent abonent = new Abonent(split[0], split[1]);
					AbonentList.Add(abonent);
				}
			}
		}
  }
}
