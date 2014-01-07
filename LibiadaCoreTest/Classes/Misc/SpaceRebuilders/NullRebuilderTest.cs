using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    /// Test space rebuilder NullRebuilder
    ///</summary>
    [TestFixture]
    public class NullRebuilderTest
    {
        private Chain chain;
        private BaseChain baseChain;

        [SetUp]
        public void Init()
        {
            chain = new Chain("adbaacbbaaca");
            baseChain = new BaseChain("adbaacbbaaca");
        }
        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object parent class to object child class
        ///</summary>
        ///
        [Test]
        public void FromParentToChildTest()
        {
            var rebulder = new NullRebuilder<BaseChain, Chain>();
            BaseChain result = rebulder.Rebuild(chain);
            Assert.AreEqual(baseChain, result);
        }

        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        ///</summary>
        [Test]
        public void FromChildToParentTest()
        {
            var rebulder = new NullRebuilder<Chain, BaseChain>();
            Chain result = rebulder.Rebuild(baseChain);
            Assert.AreEqual(chain, result);
        }
    }
}