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
    /// The chain.
    /// </summary>
    private Chain chain;

    /// <summary>
    /// The base chain.
    /// </summary>
    private BaseChain baseChain;

    /// <summary>
    /// Tests initialization method.
    /// </summary>
    [SetUp]
    public void Initialization()
    {
        chain = new Chain("adbaacbbaaca");
        baseChain = new BaseChain("adbaacbbaaca");
    }

    /// <summary>
    /// We need to test that we can correctly convert chain from
    /// object parent class to object child class.
    /// </summary>
    [Test]
    public void FromParentToChildTest()
    {
        NullReorganizer reorganizer = new();
        AbstractChain result = reorganizer.Reorganize(chain);
        Assert.That(result, Is.EqualTo(baseChain));
    }

    /// <summary>
    /// We need to test that we can correctly convert chain from
    /// object child class to object parent class.
    /// </summary>
    [Test]
    public void FromChildToParentTest()
    {
        NullReorganizer reorganizer = new();
        AbstractChain result = reorganizer.Reorganize(baseChain);
        Assert.That(result, Is.EqualTo(chain));
    }
}
