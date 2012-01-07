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
      object abc = null;

      // Act
      Action action = () => Args.Check(() => abc).NotNull();

      // Assert
      action.ShouldThrow<ArgumentNullException>()
        .And.ParamName.Should().Be("abc");
    }

    [NukitoFact]
    public void ShouldNotThrowExceptionForNonNullReference()
    {
      // Arrange
      var obj = new object();

      // Act
      Action action = () => Args.Check(() => obj).NotNull();

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldReturnSameReference()
    {
      // Arrange
      var obj = new object();

      // Act
      var result = Args.Check(() => obj).NotNull().Value;

      // Assert
      result.Should().BeSameAs(obj);
    }
  }
}