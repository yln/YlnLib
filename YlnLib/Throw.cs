using System;
using System.Diagnostics;

namespace YlnLib
{
  [DebuggerStepThrough]
  public static class Throw
  {
    public static void If(bool condition, string messageFormat, params object[] messageArguments)
    {
      if (condition)
        throw new InvalidOperationException(string.Format(messageFormat, messageArguments));
    }
  }
}