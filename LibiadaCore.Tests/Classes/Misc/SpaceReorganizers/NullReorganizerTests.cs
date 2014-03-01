namespace LibiadaCore.Tests.Classes.Misc.SpaceReorganizers
{
    using LibiadaCore.Classes.Misc.SpaceReorganizers;
    using LibiadaCore.Classes.Root;

    using NUnit.Framework;

    /// <summary>
    /// Test space reorganizer NullReorganizer.
    /// </summary>
    [TestFixture]
    public class NullReorganizerTests
    {
        /// <summary>
        /// The chain.
        /// </summary>
        private Chain chain;

        /// <summary>
        /// The base chain.
        /// </summary>
        private BaseChain baseChain;

        /// <summary>
        /// Tests initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            this.chain = new Chain("adbaacbbaaca");
            this.baseChain = new BaseChain("adbaacbbaaca");
        }

        /// <summary>
        /// We need to test that we can correctly convert chain from 
        /// object parent class to object child class.
        /// </summary>
        [Test]
        public void FromParentToChildTest()
        {
            var reorganizer = new NullReorganizer<BaseChain, Chain>();
            BaseChain result = reorganizer.Reorganize(this.chain);
            Assert.AreEqual(this.baseChain, result);
        }

        /// <summary>
        /// We need to test that we can correctly convert chain from 
        /// object child class to object parent class.
        /// </summary>
        [Test]
        public void FromChildToParentTest()
        {
            var reorganizer = new NullReorganizer<Chain, BaseChain>();
            Chain result = reorganizer.Reorganize(this.baseChain);
            Assert.AreEqual(this.chain, result);
        }
    }
}