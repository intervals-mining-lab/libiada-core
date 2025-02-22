namespace Libiada.Core.Tests.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.SpaceReorganizers;

/// <summary>
/// Test space reorganizer NullReorganizer.
/// </summary>
[TestFixture]
public class NullReorganizerTests
{
    /// <summary>
    /// The sequence.
    /// </summary>
    private ComposedSequence composedSequence;

    /// <summary>
    /// The sequence.
    /// </summary>
    private Sequence sequence;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        composedSequence = new ComposedSequence("adbaacbbaaca");
        sequence = new Sequence("adbaacbbaaca");
    }

    /// <summary>
    /// We need to test that we can correctly convert sequence from
    /// object parent class to object child class.
    /// </summary>
    [Test]
    public void FromParentToChildTest()
    {
        NullReorganizer reorganizer = new();
        AbstractSequence result = reorganizer.Reorganize(composedSequence);
        Assert.That(result, Is.EqualTo(sequence));
    }

    /// <summary>
    /// We need to test that we can correctly convert sequence from
    /// object child class to object parent class.
    /// </summary>
    [Test]
    public void FromChildToParentTest()
    {
        NullReorganizer reorganizer = new();
        AbstractSequence result = reorganizer.Reorganize(sequence);
        Assert.That(result, Is.EqualTo(composedSequence));
    }
}
