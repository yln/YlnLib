using System;

namespace YlnLib.Arguments
{
  // TODO: Test
  public static partial class ArgumentHelper
  {
    public static T OfType<T>(this object argument, string argumentName = "value")
    {
      return (T) OfType(argument, typeof (T), argumentName);
    }

    public static T OfType<T>(this T argument, Type expectedType, string argumentName = "value")
    {
// ReSharper disable CompareNonConstrainedGenericWithNull
      var notNull = argument != null;
// ReSharper restore CompareNonConstrainedGenericWithNull

      if (notNull && argument.GetType() == expectedType)
        throw new ArgumentException(
          string.Format("Invalid argument type '{0}', expected exact type '{1}'", argument.GetType(), expectedType),
          argumentName);

      return argument;
    }
  }
}