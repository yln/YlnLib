using System;
using FluentAssertions;
using Nukito;

namespace YlnLib.Test
{
  public class ArgsTest
  {
    [NukitoFact]
    public void ShouldThrowArgumentNullExceptionForNullReference()
    {
      // Arrange
      object obj = null;

      // Act
      Action action = () => Args.NotNull(obj, "foo");

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
      Action action = () => Args.NotNull(obj, "foo");

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldReturnSameReference()
    {
      // Arrange
      object obj = new object();

      // Act
      object result = Args.NotNull(obj, "foo");

      // Assert
      result.Should().BeSameAs(obj);
    }
  }
}