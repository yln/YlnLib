using System;

namespace YlnLib.Arguments
{
  // TODO: test
  public static partial class ArgumentHelper
  {
    public static T Is<T>(this object argument, string argumentName = "value")
    {
      return (T) Is(argument, typeof (T), argumentName);
    }

    public static T Is<T>(this T argument, Type expectedType, string argumentName = "value")
    {
// ReSharper disable CompareNonConstrainedGenericWithNull
      var notNull = argument != null;
// ReSharper restore CompareNonConstrainedGenericWithNull

      if (notNull && !expectedType.IsInstanceOfType(argument))
        throw new ArgumentException(
          string.Format("Invalid argument type '{0}', expected instance of '{1}'", argument.GetType(), expectedType),
          argumentName);

      return argument;
    }
  }
}