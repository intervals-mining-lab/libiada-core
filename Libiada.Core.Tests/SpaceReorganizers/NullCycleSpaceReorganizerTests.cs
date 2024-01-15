namespace Libiada.Core.Tests.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.SpaceReorganizers;

/// <summary>
/// The null cycle space reorganizer test.
/// </summary>
[TestFixture]
public class NullCycleSpaceReorganizerTests
{
    /// <summary>
    /// The test chain.
    /// </summary>
    private Chain testChain;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        testChain = new Chain("adbaacbbaaca");
    }

    /// <summary>
    /// The level one test.
    /// </summary>
    [Test]
    public void LevelOneTest()
    {
        var cycleTestChainLevel1 = new Chain("adbaacbbaacaa");

        var rebulder = new NullCycleSpaceReorganizer(1);
        var result = rebulder.Reorganize(testChain);
        Assert.AreEqual(cycleTestChainLevel1, result);
    }

    /// <summary>
    /// The level five test.
    /// </summary>
    [Test]
    public void LevelFiveTest()
    {
        var cycleTestChainLevel5 = new Chain("adbaacbbaacaadbaa");

        var reorganizer = new NullCycleSpaceReorganizer(5);
        var result = reorganizer.Reorganize(testChain);
        Assert.AreEqual(cycleTestChainLevel5, result);
    }
}
