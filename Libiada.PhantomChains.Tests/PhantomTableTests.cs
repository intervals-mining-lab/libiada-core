namespace Libiada.PhantomChains.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The phantom table tests.
/// </summary>
[TestFixture]
public class PhantomTableTests
{
    /// <summary>
    /// The volume test.
    /// </summary>
    [Test]
    public void VolumeTest()
    {
        ValuePhantom m3 = [new ValueString('a')];
        ValuePhantom m1 = [new ValueString('1'), new ValueString('2'), new ValueString('3')];
        ValuePhantom m2 = [new ValueString('4'), new ValueString('3')];

        BaseChain test = new(new List<IBaseObject>() { m1, m2, m2, m3 });

        PhantomTable table = new(test);
        Assert.Multiple(() =>
        {
            Assert.That(table[0].Volume, Is.EqualTo(12));
            Assert.That(table[1].Volume, Is.EqualTo(4));
            Assert.That(table[2].Volume, Is.EqualTo(2));
            Assert.That(table[3].Volume, Is.EqualTo(1));
            Assert.That(table[4].Volume, Is.EqualTo(1));
        });
    }

    /// <summary>
    /// The content test.
    /// </summary>
    [Test]
    public void ContentTest()
    {
        ValuePhantom m1 = [new ValueString('1'), new ValueString('2'), new ValueString('3')];
        ValuePhantom m2 = [new ValueString('4'), new ValueString('3')];

        BaseChain test = new(new List<IBaseObject>() { m1, m2, m2 });

        PhantomTable table = new(test);
        Assert.Multiple(() =>
        {
            Assert.That(table[1].Content, Is.EqualTo(m1));
            Assert.That(table[2].Content, Is.EqualTo(m2));
            Assert.That(table[3].Content, Is.EqualTo(m2));
        });
    }
}
