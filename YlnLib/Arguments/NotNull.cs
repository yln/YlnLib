using System;

namespace YlnLib.Arguments
{
  public static partial class ArgumentValidatorExtensions
  {
    public static ArgumentValidator<T> NotNull<T>(this ArgumentValidator<T> validator)
      where T : class
    {
      if (validator.Value == null)
        throw new ArgumentNullException(validator.ParameterName);

      return validator;
    }
  }
}