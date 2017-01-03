namespace LibiadaCore.Tests.Misc
{
    using LibiadaCore.Misc;
    using LibiadaCore.Tests.Core;

    using NUnit.Framework;

    /// <summary>
    /// The dissimilar chain factory tests.
    /// </summary>
    [TestFixture(TestOf = typeof(DissimilarChainFactory))]
    public class DissimilarChainFactoryTests
    {
        /// <summary>
        /// The chain test.
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
        public void ChainTest(int chainIndex, int resultIndex)
        {
            var result = DissimilarChainFactory.Create(ChainsStorage.Chains[chainIndex]);
            var expected = ChainsStorage.DissimilarChains[resultIndex];
            Assert.AreEqual(expected, result);
        }
    }
}
