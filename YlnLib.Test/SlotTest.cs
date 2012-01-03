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
      var slot = Slot.New<string>();

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
      var slot = Slot.WithDefault("def");

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
      var slot = Slot.New<string>();

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
      var slot = Slot.WithDefault("def");

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
      var slot = Slot.New<string>();

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
      var slot = Slot.New<string>("blub");

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

    [NukitoFact]
    public void ShouldAlsoWorkWithValueTypes()
    {
      // Arrange
      var slot = Slot.New<int>();

      // Act
      slot.Set(7);
      int item = slot.Item;

      // Assert
      item.Should().Be(7);

      slot.HasItem.Should().BeTrue();
      slot.HasDefault.Should().BeFalse();
      slot.CanGet.Should().BeTrue();
    }

    [NukitoFact]
    public void ShouldAlsoWorkWithValueTypesAndDefaults()
    {
      // Arrange
      var slot = Slot.WithDefault('u');

      // Act
      char item = slot.Item;

      // Assert
      item.Should().Be('u');

      slot.HasItem.Should().BeFalse();
      slot.HasDefault.Should().BeTrue();
      slot.CanGet.Should().BeTrue();
    }
  }
}