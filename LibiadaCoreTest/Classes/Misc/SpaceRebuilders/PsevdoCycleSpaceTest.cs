using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.SpaceRebuilders
{
    [TestFixture]
    public class PsevdoCycleSpaceTest
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
            Chain cycleTestChainLevel1 = new Chain("adbaacbbaacaa");

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebulder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(1);
            Chain result = rebulder.Rebuild(testChain);
            Assert.AreEqual(cycleTestChainLevel1, result);
        }

        [Test]
        public void LevelFiveTest()
        {
            Chain cycleTestChainLevel5 = new Chain("adbaacbbaacaadbaa");

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebulder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(5);
            Chain result = rebulder.Rebuild(testChain);
            Assert.AreEqual(cycleTestChainLevel5, result);
        }

    }
}