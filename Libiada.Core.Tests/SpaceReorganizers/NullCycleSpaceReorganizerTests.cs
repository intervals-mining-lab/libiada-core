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
        Chain cycleTestChainLevel1 = new("adbaacbbaacaa");

        NullCycleSpaceReorganizer rebulder = new(1);
        AbstractChain result = rebulder.Reorganize(testChain);
        Assert.That(result, Is.EqualTo(cycleTestChainLevel1));
    }

    /// <summary>
    /// The level five test.
    /// </summary>
    [Test]
    public void LevelFiveTest()
    {
        Chain cycleTestChainLevel5 = new("adbaacbbaacaadbaa");

        NullCycleSpaceReorganizer reorganizer = new(5);
        AbstractChain result = reorganizer.Reorganize(testChain);
        Assert.That(result, Is.EqualTo(cycleTestChainLevel5));
    }
}
