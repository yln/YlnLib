using System;

namespace YlnLib
{
  [AttributeUsage(
    AttributeTargets.All ^ (AttributeTargets.Assembly | AttributeTargets.Parameter | AttributeTargets.Module |
                            AttributeTargets.GenericParameter | AttributeTargets.ReturnValue),
    AllowMultiple = false)]
  public class VisibleForTestingAttribute : Attribute
  {
    public Visibility IntendedVisibility { get; set; }

    public string Description { get; set; }
  }

  public enum Visibility
  {
    Private,
    Internal,
    Protected,
    ProtectedOrInternal
  }
}