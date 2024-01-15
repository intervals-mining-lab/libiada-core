namespace Libiada.Core.Tests.Exceptions;

using Libiada.Core.Exceptions;

using NUnit.Framework;

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
        var exception = new TypeArgumentException("test message");
        Assert.AreEqual("test message", exception.Message);
    }

    /// <summary>
    /// The type argument exception actual type test.
    /// </summary>
    [Test]
    public void TypeArgumentExceptionActualTypeTest()
    {
        var exception = new TypeArgumentException("test message", typeof(object));
        Assert.IsNotNull(exception.ActualTypeArgument);
        Assert.AreEqual(typeof(object).Name, exception.ActualTypeArgument.Name);
    }
}