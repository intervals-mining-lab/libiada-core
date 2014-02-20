namespace LibiadaCoreTest.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    /// <summary>
    /// Test space rebuilder NullReorganizer
    /// </summary>
    [TestFixture]
    public class NullReorganizerTest
    {
        private Chain chain;
        private BaseChain baseChain;

        [SetUp]
        public void Init()
        {
            this.chain = new Chain("adbaacbbaaca");
            this.baseChain = new BaseChain("adbaacbbaaca");
        }
        /// <summary>
        /// We need to test that we can correct conver chain from 
        /// object parent class to object child class
        /// </summary>
        ///
        [Test]
        public void FromParentToChildTest()
        {
            var rebulder = new NullReorganizer<BaseChain, Chain>();
            BaseChain result = rebulder.Reorganize(this.chain);
            Assert.AreEqual(this.baseChain, result);
        }

        /// <summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        /// </summary>
        [Test]
        public void FromChildToParentTest()
        {
            var rebulder = new NullReorganizer<Chain, BaseChain>();
            Chain result = rebulder.Reorganize(this.baseChain);
            Assert.AreEqual(this.chain, result);
        }
    }
}