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
