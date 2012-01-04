using System;

namespace YlnLib
{
  public static class Throw
  {
    public static void If(bool condition, string messageFormat, params object[] messageArguments)
    {
      if (condition)
        throw new InvalidOperationException(string.Format(messageFormat, messageArguments));
    }
  }
}