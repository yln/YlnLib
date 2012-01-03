using System;
using FluentAssertions;
using Nukito;

namespace YlnLib.Test
{
  public class EnsureTest
  {
    [NukitoFact]
    public void ShouldNotThrowForTrueCondition()
    {
      // Act
      Action action = () => En.Sure(true, null);

      // Assert
      action.ShouldNotThrow();
    }

    [NukitoFact]
    public void ShouldThrowForFalseCondition()
    {
      // Act
      Action action = () => En.Sure(false, "message");

      // Assert
      action.ShouldThrow<InvalidOperationException>();
    }

    [NukitoFact]
    public void ShouldThrowWithFormattedExceptionMessage()
    {
      // Act
      Action action = () => En.Sure(false, "invalid {0}. type {1}", 2, typeof (void));

      // Assert
      action.ShouldThrow<InvalidOperationException>()
        .And.Message.Should().Be("invalid 2. type System.Void");
    }
  }
}