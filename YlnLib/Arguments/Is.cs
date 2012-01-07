using System;

namespace YlnLib.Arguments
{
  // TODO: test
  public static partial class ArgumentValidatorExtensions
  {
    public static ArgumentValidator<TNew> Is<TNew, TOld>(this ArgumentValidator<TOld> validator)
    {
      Is(validator, typeof (TNew));
      var value = (TNew) (object) validator.Value; // Trick the compiler

      return new ArgumentValidator<TNew>(value, validator.ParameterName);
    }

    public static ArgumentValidator<T> Is<T>(this ArgumentValidator<T> validator, Type instanceOfType)
    {
      var value = validator.GetNonNullValue();

      if (!instanceOfType.IsInstanceOfType(value))
        throw new ArgumentException(
          string.Format("Invalid argument type '{0}', expected instance of '{1}'", value.GetType(), instanceOfType),
          validator.ParameterName);

      return validator;
    }
  }
}