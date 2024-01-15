namespace Libiada.PhantomChains.Tests;

using System.Collections.Generic;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

using MarkovChains.MarkovChain.Generators;

using NUnit.Framework;

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
        Assert.AreEqual(12, tree.Volume);
        TreeNode ch1 = tree.GetChild(0);
        Assert.AreEqual(4, ch1.Volume);
        TreeNode ch2 = tree.GetChild(1);
        Assert.AreEqual(4, ch2.Volume);
        TreeNode ch3 = tree.GetChild(2);
        Assert.AreEqual(4, ch3.Volume);
    }
}
