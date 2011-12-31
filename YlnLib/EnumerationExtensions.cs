using System.Collections.Generic;

namespace YlnLib
{
  public static class EnumerationExtensions
  {
    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element)
    {
      foreach (T item in source)
      {
        yield return item;
      }

      yield return element;
    }

    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
    {
      yield return element;

      foreach (T item in source)
      {
        yield return item;
      }
    }
  }
}