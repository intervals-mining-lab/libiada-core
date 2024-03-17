namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The value integer test.
/// </summary>
[TestFixture]
public class ValueIntTests
{
    /// <summary>
    /// The sum test.
    /// </summary>
    [Test]
    public void SumTest()
    {
        int x = new ValueInt(1) + new ValueInt(3);
        Assert.That(x, Is.EqualTo(4));
        ValueInt y = new ValueInt(1) + new ValueInt(3);
        Assert.That((int)y, Is.EqualTo(4));
        Assert.That(4.Equals(y), Is.True);
    }
}
