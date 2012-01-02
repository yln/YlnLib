using System;
using FluentAssertions;
using Nukito;

namespace YlnLib.Test
{
  public class SlotTest
  {
    [NukitoFact]
    public void ShouldThrowForEmptySlotWithoutDefault()
    {
      // Arrange
      var slot = new Slot<string>();

      // Act
      string item = null;
      Action action = () => item = slot.Item;

      // Assert
      slot.HasItem.Should().BeFalse();
      slot.HasDefault.Should().BeFalse();
      slot.CanGet.Should().BeFalse();

      action.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("Item not set");
      item.Should().BeNull();
    }

    [NukitoFact]
    public void ShouldNotThrowForEmptySlotWithDefault()
    {
      // Arrange
      var slot = new Slot<string>(defaultIfItemNotSet: "def");

      // Act
      string item = null;
      Action action = () => item = slot.Item;

      // Assert
      slot.HasItem.Should().BeFalse();
      slot.HasDefault.Should().BeTrue();
      slot.CanGet.Should().BeTrue();

      action.ShouldNotThrow();
      item.Should().Be("def");
    }

    [NukitoFact]
    public void ShouldNotThrowForStandardUsageWithoutDefault()
    {
      // Arrange
      var slot = new Slot<string>();

      // Act
      slot.Set("abc");
      string item = null;
      Action action = () => item = slot.Item;

      // Assert
      slot.HasItem.Should().BeTrue();
      slot.HasDefault.Should().BeFalse();
      slot.CanGet.Should().BeTrue();

      action.ShouldNotThrow();
      item.Should().Be("abc");
    }

    [NukitoFact]
    public void ShouldNotThrowForStandardUsageWithDefaultAndReturnItem()
    {
      // Arrange
      var slot = new Slot<string>(defaultIfItemNotSet: "def");

      // Act
      slot.Set("abc");
      string item = null;
      Action action = () => item = slot.Item;

      // Assert
      slot.HasItem.Should().BeTrue();
      slot.HasDefault.Should().BeTrue();
      slot.CanGet.Should().BeTrue();

      action.ShouldNotThrow();
      item.Should().Be("abc");
    }

    [NukitoFact]
    public void ShouldThrowForSecondSet()
    {
      // Arrange
      var slot = new Slot<string>();

      // Act
      slot.Set("first");
      Action action = () => slot.Set("second");

      // Assert
      slot.HasItem.Should().BeTrue();

      action.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("Item already set");
    }

    [NukitoFact]
    public void ShouldUseProvidedItemNameForExceptionMessages()
    {
      // Arrange
      var slot = new Slot<string>(itemName: "blub");

      // Act
      string item = null;
      Action getWithNoItem = () => item = slot.Item;
      Action setTooOften = () => slot.Set("second");

      // Assert
      getWithNoItem.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("blub not set");

      slot.Set("first");

      setTooOften.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("blub already set");
    }
  }
}