namespace Libiada.Core.Tests.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.DataTransformers;
using Libiada.Core.Tests.Core;

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
        Chain result = DissimilarChainFactory.Create(ChainsStorage.Chains[chainIndex]);
        Chain expected = ChainsStorage.DissimilarChains[resultIndex];
        Assert.That(result, Is.EqualTo(expected));
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
        Chain result = DissimilarChainFactory.Create(ChainsStorage.Chains[chainIndex]);
        result = DissimilarChainFactory.Create(result);
        Chain expected = ChainsStorage.DissimilarChains[resultIndex];
        Assert.That(result, Is.EqualTo(expected));
    }
}
