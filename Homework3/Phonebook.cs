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
    /// Чтение файла в формате txt, добавление объектов в AbonentList.
    /// </summary>
    public void ReadFile()
    {
      /*using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
      {
				this.AbonentList = new List<Abonent>();
				//string line = string.Empty;
				while (!sr.EndOfStream)
        {
          string[] split = Regex.Split(sr.ReadLine(), ": ");
          Abonent abonent = new Abonent(split[0], split[1]);
          AbonentList.Add(abonent);
        }
      }*/
    }

    /// <summary>
    /// 
    /// </summary>
    public void PrintAbonentList()
    {
      foreach (var abonent in AbonentList)
      {
        Console.WriteLine($"{abonent.Name}: {abonent.PhoneNumber}");
      }
    }
    public static Phonebook GetInstance()
    {
      if (instance == null)
        instance = new Phonebook();
      return instance;
    }
    private Phonebook()
    {
      /*this.AbonentList = new List<string>();
      using (StreamReader sr = new StreamReader(path))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          AbonentList.Add(line);
        }
      }*/
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
