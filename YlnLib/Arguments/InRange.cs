using System;

namespace YlnLib.Arguments
{
  // TODO: test
  public static partial class ArgumentValidatorExtensions
  {
    public static ArgumentValidator<int> InRange(this ArgumentValidator<int> validator,
                                                 int minInclusive, int maxExclusive)
    {
      var value = validator.Value;

      if (value < minInclusive || value > maxExclusive)
        throw new ArgumentOutOfRangeException(validator.ParameterName, value,
                                              string.Format("Range: [{0},{1})", minInclusive, maxExclusive));
      return validator;
    }
  }
}