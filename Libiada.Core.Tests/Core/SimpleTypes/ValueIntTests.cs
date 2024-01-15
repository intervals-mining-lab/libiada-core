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
        Assert.AreEqual(4, x);
        ValueInt y = new ValueInt(1) + new ValueInt(3);
        Assert.AreEqual(4, (int)y);
        Assert.IsTrue(4.Equals(y));
    }
}
