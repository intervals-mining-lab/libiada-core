using LibiadaCore.Misc;
using LibiadaCore.Tests.Core;
using NUnit.Framework;

namespace LibiadaCore.Tests.Misc
{
    class DissimilarChainFactoryTests
    {
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
