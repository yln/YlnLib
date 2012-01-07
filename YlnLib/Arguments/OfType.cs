using System;

namespace YlnLib.Arguments
{
  // TODO: Test
  public static partial class ArgumentValidatorExtensions
  {
    public static ArgumentValidator<TNew> OfType<TNew, TOld>(this ArgumentValidator<TOld> validator)
    {
      OfType(validator, typeof (TNew));
      var value = (TNew) (object) validator.Value; // Trick the compiler

      return new ArgumentValidator<TNew>(value, validator.ParameterName);
    }

    public static ArgumentValidator<T> OfType<T>(this ArgumentValidator<T> validator, Type exactType)
    {
      var value = validator.GetNonNullValue();

      if (value.GetType() != exactType)
        throw new ArgumentException(
          string.Format("Invalid argument type '{0}', expected exact type '{1}'", value.GetType(), exactType),
          validator.ParameterName);

      return validator;
    }
  }
}