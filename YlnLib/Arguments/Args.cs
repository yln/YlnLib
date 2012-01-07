using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace YlnLib.Arguments
{
  [DebuggerStepThrough]
  public static class Args
  {
    public static ArgumentValidator<T> Check<T>(Expression<Func<T>> parameterReference)
    {
      var value = parameterReference.Compile().Invoke(); // Might be too slow (add "T value" in signature then)
      var parameterName = ((MemberExpression) parameterReference.Body).Member.Name;

      return new ArgumentValidator<T>(value, parameterName);
    }
  }
}