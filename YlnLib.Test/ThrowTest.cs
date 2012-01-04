using System;
using FluentAssertions;
using Nukito;

namespace YlnLib.Test
{
  public class ThrowTest
  {
    [NukitoFact]
    public void ShouldNotThrowForFalseCondition()
    {
      // Act
      Action action = () => Throw.If(false, null);

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldThrowForTrueCondition()
    {
      // Act
      Action action = () => Throw.If(true, "message");

      // Assert
      action.ShouldThrow<InvalidOperationException>();
    }

    [NukitoFact]
    public void ShouldThrowWithFormattedExceptionMessage()
    {
      // Act
      Action action = () => Throw.If(true, "invalid {0}. type {1}", 2, typeof (void));

      // Assert
      action.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("invalid 2. type System.Void");
    }
  }
}