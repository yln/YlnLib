using System;

namespace YlnLib.Arguments
{
  public static partial class ArgumentHelper
  {
    public static T ThrowIfNull<T>([CanBeNull] this T argument)
      where T : class
    {
      return ThrowIfNull(argument, "value");
    }

    public static T ThrowIfNull<T>([CanBeNull] this T argument, string argumentName)
      where T : class
    {
      if (argument == null)
      {
        throw new ArgumentNullException(argumentName);
      }

      return argument;
    }
  }
}