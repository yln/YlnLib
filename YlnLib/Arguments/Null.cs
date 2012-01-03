using System;

namespace YlnLib.Arguments
{
  public static partial class ArgumentHelper
  {
    public static T NotNull<T>([CanBeNull] this T argument, string argumentName = "value")
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