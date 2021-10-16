using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mushrooms.Models;

namespace Mushrooms.Extensions
{
  public class Enum<T> where T : struct, IConvertible
  {
    public static List<string> ToList
    {
      get
      {
        if (!typeof(T).IsEnum)
          throw new ArgumentException("T must be an enumerated type");

        return Enum.GetNames(typeof(T)).Select(b => b.SplitCamelCase()).ToList();
      }
    }
  }
}
