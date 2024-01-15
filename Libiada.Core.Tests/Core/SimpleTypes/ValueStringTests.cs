namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The value string test.
/// </summary>
[TestFixture]
public class ValueStringTests
{
    /// <summary>
    /// The null string value test.
    /// </summary>
    [Test]
    public void NullStringValueTest()
    {
        Assert.Throws<ArgumentNullException>(() => new ValueString(null));
    }

    /// <summary>
    /// The empty string value test.
    /// </summary>
    [Test]
    public void EmptyStringValueTest()
    {
        Assert.Throws<ArgumentException>(() => new ValueString(string.Empty));
    }

    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        Assert.AreEqual(new ValueString("1"), new ValueString("1"));
        Assert.AreEqual(new ValueString("abc"), new ValueString("abc"));
    }
}
