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
    /// The test sequence.
    /// </summary>
    private ComposedSequence testSequence;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        testSequence = new ComposedSequence("adbaacbbaaca");
    }

    /// <summary>
    /// The level one test.
    /// </summary>
    [Test]
    public void LevelOneTest()
    {
        ComposedSequence cycleTestSequenceLevel1 = new("adbaacbbaacaa");

        NullCycleSpaceReorganizer rebulder = new(1);
        AbstractSequence result = rebulder.Reorganize(testSequence);
        Assert.That(result, Is.EqualTo(cycleTestSequenceLevel1));
    }

    /// <summary>
    /// The level five test.
    /// </summary>
    [Test]
    public void LevelFiveTest()
    {
        ComposedSequence cycleTestSequenceLevel5 = new("adbaacbbaacaadbaa");

        NullCycleSpaceReorganizer reorganizer = new(5);
        AbstractSequence result = reorganizer.Reorganize(testSequence);
        Assert.That(result, Is.EqualTo(cycleTestSequenceLevel5));
    }
}
