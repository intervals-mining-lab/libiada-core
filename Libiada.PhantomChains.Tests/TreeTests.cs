namespace Libiada.PhantomChains.Tests;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// The tree tests.
/// </summary>
[TestFixture]
public class TreeTests
{
    /// <summary>
    /// The tree volume test.
    /// </summary>
    [Test]
    public void TreeVolumeTest()
    {
        var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };
        var m2 = new ValuePhantom { new ValueString('4'), new ValueString('3') };
        var m3 = new ValuePhantom { new ValueString('a') };

        var test = new BaseChain(new List<IBaseObject>(){ m1, m2, m2, m3 });

        IGenerator generator = new SimpleGenerator();
        var tree = new TreeTop(test, generator);
        Assert.That(tree.Volume, Is.EqualTo(12));
        TreeNode ch1 = tree.GetChild(0);
        Assert.That(ch1.Volume, Is.EqualTo(4));
        TreeNode ch2 = tree.GetChild(1);
        Assert.That(ch2.Volume, Is.EqualTo(4));
        TreeNode ch3 = tree.GetChild(2);
        Assert.That(ch3.Volume, Is.EqualTo(4));
    }
}
