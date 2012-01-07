using System;
using System.Collections;

namespace YlnLib.Arguments
{
  //TODO: test
  public partial class ArgumentValidatorExtensions
  {
    public static ArgumentValidator<T> NotEmpty<T>(this ArgumentValidator<T> validator)
      where T : IEnumerable
    {
      var value = validator.GetNonNullValue();

      if (!value.GetEnumerator().MoveNext())
        new ArgumentException("Argument cannot be empty", validator.ParameterName);

      return validator;
    }
  }
}