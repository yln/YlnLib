using System;

namespace YlnLib
{
  public class Slot<T>
  {
    private readonly string _itemName;
    private T _item;

    public Slot(string itemName = "Item")
    {
      _itemName = itemName;
    }

    public Slot(T defaultIfItemNotSet, string itemName = "Item")
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