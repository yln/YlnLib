using System;
using FluentAssertions;
using Nukito;
using YlnLib.Arguments;

namespace YlnLib.Test.Arguments
{
  public class NullTest
  {
    [NukitoFact]
    public void ShouldThrowArgumentNullExceptionForNullReference()
    {
      // Arrange
      object obj = null;

      // Act
      Action action = () => obj.ThrowIfNull("foo");

      // Assert
      action.ShouldThrow<ArgumentNullException>()
        .And.ParamName.Should().Be("foo");
    }

    [NukitoFact]
    public void ShouldNotThrowExceptionForNonNullReference()
    {
      // Arrange
      object obj = new object();

      // Act
      Action action = () => obj.ThrowIfNull("foo");

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldReturnSameReference()
    {
      // Arrange
      object obj = new object();

      // Act
      object result = obj.ThrowIfNull("foo");

      // Assert
      result.Should().BeSameAs(obj);
    }

    [NukitoFact]
    public void ArgumentNameShouldBeValueIfNotSupplied()
    {
      // Arrange
      object obj = null;

      // Act
      Action action = () => obj.ThrowIfNull();

      // Assert
      action.ShouldThrow<ArgumentNullException>()
        .And.ParamName.Should().Be("value");
    }
  }
}