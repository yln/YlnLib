using System;

namespace YlnLib
{
  [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
  public class CanBeNullAttribute : Attribute
  {
  }
}