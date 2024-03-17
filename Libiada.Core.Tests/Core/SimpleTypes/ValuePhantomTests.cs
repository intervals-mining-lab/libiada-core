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
        ValuePhantom m1 = [new ValueString('1'), new ValueString('2'), new ValueString('3')];

        Assert.That(m1.Equals(new ValueString('3')));
    }

    /// <summary>
    /// The add message phantom test.
    /// </summary>
    [Test]
    public void AddMessagePhantomTest()
    {
        ValuePhantom m2 = [new ValueString('4'), new ValueString('2'), new ValueString('5')];
        ValuePhantom m1 = [new ValueString('1'), new ValueString('2'), new ValueString('3'), m2];

        Assert.That(m1.Equals(new ValueString('1')));
        Assert.That(m1.Equals(new ValueString('2')));
        Assert.That(m1.Equals(new ValueString('3')));
        Assert.That(m1.Equals(new ValueString('4')));
        Assert.That(m1.Equals(new ValueString('5')));
    }

    /// <summary>
    /// The clone test.
    /// </summary>
    [Test]
    public void CloneTest()
    {
        ValuePhantom m1 = [new ValueString('1'), new ValueString('2'), new ValueString('3')];
        var clone = (ValuePhantom)m1.Clone();

        Assert.That(clone, Is.EqualTo(m1));
    }
}
