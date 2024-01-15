namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

using NUnit.Framework;

/// <summary>
/// The high order factory tests.
/// </summary>
[TestFixture(TestOf = typeof(HighOrderFactory))]
public class HighOrderFactoryTests
{
    /// <summary>
    /// The second order test.
    /// </summary>
    /// <param name="chainIndex">
    /// The chain index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    [TestCase(0, 0, Link.Start)]
    [TestCase(1, 1, Link.End)]
    [TestCase(1, 2, Link.Start)]
    [TestCase(0, 3, Link.End)]
    [TestCase(0, 4, Link.CycleStart)]
    [TestCase(0, 5, Link.CycleEnd)]
    public void SecondOrderTest(int chainIndex, int resultIndex, Link link)
    {
        var result = HighOrderFactory.Create(ChainsStorage.Chains[chainIndex], link);
        var expected = ChainsStorage.HighOrderChains[resultIndex];
        Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// The third order test.
    /// </summary>
    [Test]
    public void ThirdOrderTest()
    {
        var result = HighOrderFactory.Create(ChainsStorage.Chains[0], Link.End);
        result = HighOrderFactory.Create(result, Link.End);
        var expected = ChainsStorage.HighOrderChains[6];
        Assert.AreEqual(expected, result);
    }
}
