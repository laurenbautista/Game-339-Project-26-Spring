using Game339.Shared.Services.Implementation;
using NUnit.Framework;

namespace Game339.Tests;

public class StringServiceTests
{
    private StringService _svc;

    [SetUp]
    public void SetUp()
    {
        _svc = new StringService(EmptyGameLog.Instance);
    }

    [TestCase("hello", "olleh")]
    [TestCase("", "")]
    [TestCase("a", "a")]
    [TestCase("racecar", "racecar")]
    public void Reverse_ReturnsExpectedString(string input, string expected)
    {
        // Act
        var result = _svc.Reverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReverseWords_NullString_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<System.ArgumentNullException>(() => _svc.Reverse(null));
    }
    
    [TestCase("", "")] // empty
    [TestCase(" ", " ")] // whitespace-only
    [TestCase("hello", "hello")] // single word
    [TestCase("Hello World", "World Hello")] // standard usecase
    [TestCase("The quick brown fox", "fox brown quick The")]
    [TestCase(" hello world ", "world hello")] // trims spaces
    [TestCase("a b c", "c b a")] // multiple spaces
    public void ReverseWords_CommonCases(string input, string expected)
    {
        var actual = _svc.ReverseWords(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
