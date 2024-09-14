using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
  internal class Abonent
  {
    public string Name { get; set; }
    public long PhoneNumber { get; set; }

    public override bool Equals(object obj)
    {
      Abonent other = obj as Abonent;
      return other.Name.ToLower() == Name.ToLower() && other.PhoneNumber == PhoneNumber;
    }

    public override int GetHashCode()
    {
      int hashCode = 1992402788;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      hashCode = hashCode * -1521134295 + PhoneNumber.GetHashCode();
      return hashCode;
    }

    public Abonent(string name, long phoneNumber)
    {
      this.Name = name;
      this.PhoneNumber = phoneNumber;
    }
    public Abonent(long phoneNumber)
      : this(string.Empty, phoneNumber)
    {
      this.PhoneNumber = phoneNumber;
    }
    public Abonent(string name)
      : this(name, 0)
    {
      this.Name = name;
    }
  }
}
