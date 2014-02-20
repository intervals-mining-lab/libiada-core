namespace LibiadaCoreTest.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    [TestFixture]
    public class NullCycleSpaceReorganizerTest
    {
        private Chain testChain;
     
        [SetUp]
        public void Init()
        {
            this.testChain = new Chain("adbaacbbaaca");
        }

        [Test]
        public void LevelOneTest()
        {
            var cycleTestChainLevel1 = new Chain("adbaacbbaacaa");

            var rebulder = new NullCycleSpaceReorganizer<Chain, Chain>(1);
            Chain result = rebulder.Reorganize(this.testChain);
            Assert.AreEqual(cycleTestChainLevel1, result);
        }

        [Test]
        public void LevelFiveTest()
        {
            var cycleTestChainLevel5 = new Chain("adbaacbbaacaadbaa");

            var rebulder = new NullCycleSpaceReorganizer<Chain, Chain>(5);
            Chain result = rebulder.Reorganize(this.testChain);
            Assert.AreEqual(cycleTestChainLevel5, result);
        }

    }
}