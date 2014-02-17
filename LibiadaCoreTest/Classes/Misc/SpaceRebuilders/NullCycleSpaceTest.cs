using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.SpaceRebuilders
{
    [TestFixture]
    public class NullCycleSpaceTest
    {
        private Chain testChain;
     
        [SetUp]
        public void Init()
        {
            testChain = new Chain("adbaacbbaaca");
        }

        [Test]
        public void LevelOneTest()
        {
            var cycleTestChainLevel1 = new Chain("adbaacbbaacaa");

            var rebulder = new NullCycleSpaceRebuilder<Chain, Chain>(1);
            Chain result = rebulder.Rebuild(testChain);
            Assert.AreEqual(cycleTestChainLevel1, result);
        }

        [Test]
        public void LevelFiveTest()
        {
            var cycleTestChainLevel5 = new Chain("adbaacbbaacaadbaa");

            var rebulder = new NullCycleSpaceRebuilder<Chain, Chain>(5);
            Chain result = rebulder.Rebuild(testChain);
            Assert.AreEqual(cycleTestChainLevel5, result);
        }

    }
}