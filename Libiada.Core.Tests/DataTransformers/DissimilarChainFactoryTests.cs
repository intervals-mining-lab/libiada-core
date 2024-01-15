namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

using NUnit.Framework;

/// <summary>
/// The dissimilar chain factory tests.
/// </summary>
[TestFixture(TestOf = typeof(DissimilarChainFactory))]
public class DissimilarChainFactoryTests
{
    /// <summary>
    /// The dissimilar order computation tests.
    /// </summary>
    /// <param name="chainIndex">
    /// The chain index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    public void DissimilarOrderTest(int chainIndex, int resultIndex)
    {
        var result = DissimilarChainFactory.Create(ChainsStorage.Chains[chainIndex]);
        var expected = ChainsStorage.DissimilarChains[resultIndex];
        Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// The dissimilar of dissimilar order computation tests.
    /// </summary>
    /// <param name="chainIndex">
    /// The chain index.
    /// </param>
    /// <param name="resultIndex">
    /// The result index.
    /// </param>
    [TestCase(0, 3)]
    [TestCase(1, 4)]
    [TestCase(2, 5)]
    public void DissimilarSecondOrderTest(int chainIndex, int resultIndex)
    {
        var result = DissimilarChainFactory.Create(ChainsStorage.Chains[chainIndex]);
        result = DissimilarChainFactory.Create(result);
        var expected = ChainsStorage.DissimilarChains[resultIndex];
        Assert.AreEqual(expected, result);
    }
}
