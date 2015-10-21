using LibiadaCore.Core;
using LibiadaCore.Tests.Core;

namespace LibiadaCore.Tests.Misc
{
    using LibiadaCore.Misc;

    using NUnit.Framework;
    [TestFixture]
    public class HighOrderFactoryTests
    {
        [TestCase(0, 0, Link.Start)]
        [TestCase(1, 1, Link.End)]
        [TestCase(1, 2, Link.Start)]
        [TestCase(0, 3, Link.End)]
        [TestCase(0, 4, Link.CycleStart)]
        [TestCase(0, 5, Link.CycleEnd)]
        public void ChainTest(int chainIndex, int resultIndex, Link link)
        {
            var result = HighOrderFactory.Create(ChainsStorage.Chains[chainIndex], link);
            var expected = ChainsStorage.HighOrderChains[resultIndex];
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ThirdOrderTest()
        {
            var result = HighOrderFactory.Create(ChainsStorage.Chains[0], Link.End);
            result = HighOrderFactory.Create(result, Link.End);
            var expected = ChainsStorage.HighOrderChains[6];
            Assert.AreEqual(expected, result); 
        }
    }
}
