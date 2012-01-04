using System;

namespace YlnLib.Arguments
{
  // TODO: test
  public static partial class ArgumentHelper
  {
    public static int InRange(this int argument, int minInclusive, int maxExclusive, string argumentName = "value")
    {
      if (argument < minInclusive || argument >= maxExclusive)
        throw new ArgumentOutOfRangeException(argumentName, argument,
                                              string.Format("Range: [{0},{1})", minInclusive, maxExclusive));

      return argument;
    }
  }
}