using System;

namespace YlnLib
{
  public static class Slot
  {
    public static Slot<T> New<T>(string itemName = "Item")
    {
      return new Slot<T>(itemName);
    }

    // Different method name to prevent confusion in case T == typeof(string)
    public static Slot<T> WithDefault<T>(T defaultIfItemNotSet, string itemName = "Item")
    {
      return new Slot<T>(itemName, defaultIfItemNotSet);
    }
  }

  public class Slot<T>
  {
    private readonly string _itemName;
    private T _item;

    internal Slot(string itemName)
    {
      _itemName = itemName;
    }

    internal Slot(string itemName, T defaultIfItemNotSet)
      : this(itemName)
    {
      _item = defaultIfItemNotSet;
      HasDefault = true;
    }

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
      if (HasItem)
        throw new InvalidOperationException(_itemName + " already set");

      _item = item;
      HasItem = true;
    }
  }
}