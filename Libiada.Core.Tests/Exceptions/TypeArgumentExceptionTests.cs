namespace Libiada.Core.Tests.Exceptions;

using Libiada.Core.Exceptions;

/// <summary>
/// The type argument exception tests.
/// </summary>
[TestFixture]
public class TypeArgumentExceptionTests
{
    /// <summary>
    /// The type argument exception message test.
    /// </summary>
    [Test]
    public void TypeArgumentExceptionMessageTest()
    {
        TypeArgumentException exception = new("test message");
        Assert.That(exception.Message, Is.EqualTo("test message"));
    }

    /// <summary>
    /// The type argument exception actual type test.
    /// </summary>
    [Test]
    public void TypeArgumentExceptionActualTypeTest()
    {
        TypeArgumentException exception = new("test message", typeof(object));
        Assert.That(exception.ActualTypeArgument, Is.Not.Null);
        Assert.That(exception.ActualTypeArgument.Name, Is.EqualTo(typeof(object).Name));
    }
}
