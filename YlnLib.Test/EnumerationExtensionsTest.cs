using System.Linq;
using FluentAssertions;
using Nukito;

namespace YlnLib.Test
{
  public class EnumerationExtensionsTest
  {
    [NukitoFact]
    public void AppendToEmpty()
    {
      // Arrange
      var source = Enumerable.Empty<char>();

      // Act
      var enumarable = source.Append('x');

      // Assert
      enumarable.Should().Equal(new[] {'x'});
    }

    [NukitoFact]
    public void AppendToNonEmpty()
    {
      // Arrange
      var source = Enumerable.Repeat('a', 2);

      // Act
      var enumarable = source.Append('x');

      // Assert
      enumarable.Should().Equal(new[] {'a', 'a', 'x'});
    }

    [NukitoFact]
    public void PrependToEmpty()
    {
      // Arrange
      var source = Enumerable.Empty<char>();

      // Act
      var enumarable = source.Prepend('x');

      // Assert
      enumarable.Should().Equal(new[] {'x'});
    }

    [NukitoFact]
    public void PrependToNonEmpty()
    {
      // Arrange
      var source = Enumerable.Repeat('b', 2);

      // Act
      var enumarable = source.Prepend('x');

      // Assert
      enumarable.Should().Equal(new[] {'x', 'b', 'b'});
    }

    // TODO: Include SingleOrDefaultForAny?!
  }
}