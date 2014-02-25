namespace LibiadaCoreTest.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    /// <summary>
    /// The null cycle space reorganizer test.
    /// </summary>
    [TestFixture]
    public class NullCycleSpaceReorganizerTest
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.testChain = new Chain("adbaacbbaaca");
        }

        /// <summary>
        /// The level one test.
        /// </summary>
        [Test]
        public void LevelOneTest()
        {
            var cycleTestChainLevel1 = new Chain("adbaacbbaacaa");

            var rebulder = new NullCycleSpaceReorganizer<Chain, Chain>(1);
            Chain result = rebulder.Reorganize(this.testChain);
            Assert.AreEqual(cycleTestChainLevel1, result);
        }

        /// <summary>
        /// The level five test.
        /// </summary>
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