namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The value phantom test.
/// </summary>
[TestFixture]
public class ValuePhantomTests
{
    /// <summary>
    /// The equals test.
    /// </summary>
    [Test]
    public void EqualsTest()
    {
        var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };

        Assert.IsTrue(m1.Equals(new ValueString('3')));
    }

    /// <summary>
    /// The add message phantom test.
    /// </summary>
    [Test]
    public void AddMessagePhantomTest()
    {
        var m2 = new ValuePhantom { new ValueString('4'), new ValueString('2'), new ValueString('5') };
        var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3'), m2 };

        Assert.IsTrue(m1.Equals(new ValueString('1')));
        Assert.IsTrue(m1.Equals(new ValueString('2')));
        Assert.IsTrue(m1.Equals(new ValueString('3')));
        Assert.IsTrue(m1.Equals(new ValueString('4')));
        Assert.IsTrue(m1.Equals(new ValueString('5')));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };

        var itsClone = (ValuePhantom)m1.Clone();
        Assert.AreEqual(m1, itsClone);
    }
}
