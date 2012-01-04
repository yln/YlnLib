using System;
using FluentAssertions;
using Nukito;
using YlnLib.Arguments;

namespace YlnLib.Test.Arguments
{
  public class NotNullTest
  {
    [NukitoFact]
    public void ShouldThrowArgumentNullExceptionForNullReference()
    {
      // Arrange
      object obj = null;

      // Act
      Action action = () => obj.NotNull("foo");

      // Assert
      action.ShouldThrow<ArgumentNullException>()
        .And.ParamName.Should().Be("foo");
    }

    [NukitoFact]
    public void ShouldNotThrowExceptionForNonNullReference()
    {
      // Arrange
      var obj = new object();

      // Act
      Action action = () => obj.NotNull("foo");

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldReturnSameReference()
    {
      // Arrange
      var obj = new object();

      // Act
      object result = obj.NotNull("foo");

      // Assert
      result.Should().BeSameAs(obj);
    }

    [NukitoFact]
    public void ArgumentNameShouldBeValueIfNotSupplied()
    {
      // Arrange
      object obj = null;

      // Act
      Action action = () => obj.NotNull();

      // Assert
      action.ShouldThrow<ArgumentNullException>()
        .And.ParamName.Should().Be("value");
    }
  }
}