using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework3
{
  internal class Phonebook
  {
    private static Phonebook instance;
    private const string path = "phonebook.txt";
    public List<Abonent> AbonentList { get; }

    /// <summary>
    /// Добавить абонента в справочник.
    /// </summary>
    /// <param name="abonent">Объект Abonent.</param>
    /// <returns>True, если абонент добавлен. False, если абонент с такими данными есть.</returns>
    public bool AddAbonent(Abonent abonent)
    {
      bool correctEntry = true;
      for (int i = 0; i < AbonentList.Count; i++)
      {
        if (abonent.Equals(AbonentList[i]))
        {
          correctEntry = false;
          return correctEntry;
        }
      }
      if (correctEntry)
      {
        AbonentList.Add(abonent);
        using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
        {
          sw.WriteLine($"{abonent.Name}: {abonent.PhoneNumber}");
        }
        return correctEntry;
      }
      else
        return correctEntry;
		}

    /// <summary>
    /// Удалить объект из коллекции AbonentList, перезаписать обновленную коллекцию в файл.
    /// </summary>
    /// <param name="abonent">Объект Abonent.</param>
    /// <returns>True, если абонент удален. False, если абонент не найден.</returns>
    public bool DropAbonent(Abonent abonent)
    {
      bool isDropped = false;
      for (int i = 0; i < this.AbonentList.Count; i++)
      {
        if (this.AbonentList[i].Equals(abonent))
        {
          AbonentList.RemoveAt(i);
          using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
          {
            foreach (var entry in this.AbonentList)
            {
              sw.WriteLine($"{entry.Name}: {entry.PhoneNumber}");
            }
          }
          isDropped = true;
          return isDropped;
        }
      }
      return isDropped;
    }

    /// <summary>
    /// Получить коллекцию абонентов с соответствующим номером телефона.
    /// </summary>
    /// <param name="abonent">Объект Abonent.</param>
    /// <returns>Коллекция Abonent.</returns>
    public List<Abonent> GetAbonentByPhoneNumber(Abonent abonent)
    {
      return this.AbonentList.Where(a => a.PhoneNumber == abonent.PhoneNumber).ToList();
    }

    /// <summary>
    /// Получить абонентов с соответствующим именем.
    /// </summary>
    /// <param name="abonent">Объект Abonent.</param>
    /// <returns>Коллекция Abonent.</returns>
    public List<Abonent> GetAbonentByName(Abonent abonent)
    {
      return this.AbonentList.Where(a => a.Name.ToLower() == abonent.Name.ToLower()).ToList();
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
				this.AbonentList = new List<Abonent>();
				while (!sr.EndOfStream)
				{
					string[] split = Regex.Split(sr.ReadLine(), ": ");
					Abonent abonent = new Abonent(split[0], long.Parse(split[1]));
					AbonentList.Add(abonent);
				}
			}
		}
  }
}
