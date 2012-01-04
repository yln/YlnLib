using System;

namespace YlnLib
{
  public static class Slot
  {
    public static Slot<T> New<T>(string itemName = "Item", bool allowsNull = false)
    {
      return new Slot<T>(itemName, allowsNull);
    }

    // Different method name to prevent confusion in case T == typeof(string)
    public static Slot<T> WithDefault<T>(T defaultIfItemNotSet, string itemName = "Item", bool allowsNull = false)
    {
      return new Slot<T>(itemName, allowsNull, defaultIfItemNotSet);
    }
  }

  public class Slot<T>
  {
    private readonly string _itemName;
    private T _item;

    internal Slot(string itemName, bool allowsNull)
    {
      _itemName = itemName;
      AllowsNull = allowsNull;
    }

    internal Slot(string itemName, bool allowsNull, T defaultIfItemNotSet)
      : this(itemName, allowsNull)
    {
      _item = defaultIfItemNotSet;
      HasDefault = true;
    }

    public bool AllowsNull { get; private set; }
    public bool HasItem { get; private set; }
    public bool HasDefault { get; private set; }

    public bool CanGet
    {
      get { return HasItem || HasDefault; }
    }

    public T Item
    {
      get
      {
        if (!CanGet)
          throw new InvalidOperationException(_itemName + " not set");

        return _item;
      }

      set { Set(value); }
    }

    public void Set(T item)
    {
// ReSharper disable CompareNonConstrainedGenericWithNull
      var isItemNull = item == null;
// ReSharper restore CompareNonConstrainedGenericWithNull

      if (isItemNull && !AllowsNull)
        throw new ArgumentNullException(_itemName);

      if (HasItem)
        throw new InvalidOperationException(_itemName + " already set");

      _item = item;
      HasItem = true;
    }
  }
}