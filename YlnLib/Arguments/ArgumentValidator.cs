using System;
using System.Diagnostics;

namespace YlnLib.Arguments
{
  [DebuggerStepThrough]
  public class ArgumentValidator<T>
  {
    internal ArgumentValidator(T parameterValue, string parameterName)
    {
      Value = parameterValue;
      ParameterName = parameterName;
    }

    public T Value { get; private set; }

    internal string ParameterName { get; private set; }

    internal T GetNonNullValue()
    {
// ReSharper disable CompareNonConstrainedGenericWithNull
      if (Value == null)
        throw new ArgumentNullException(ParameterName);
// ReSharper restore CompareNonConstrainedGenericWithNull

      return Value;
    }
  }
}