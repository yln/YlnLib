using System;

namespace YlnLib
{
  public static class En
  {
    public static void Sure(bool condition, string messageFormat, params object[] messageArguments)
    {
      if (!condition)
        throw new InvalidOperationException(string.Format(messageFormat, messageArguments));
    }
  }
}