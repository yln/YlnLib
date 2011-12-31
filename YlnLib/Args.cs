using System;

namespace YlnLib
{
  public static class Args
  {
    public static T NotNull<T>(T argument)
      where T : class
    {
      return NotNull(argument, "value");
    }

    public static T NotNull<T>(T argument, string argumentName)
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