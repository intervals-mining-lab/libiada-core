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
            BaseChain Result;
            
            NullRebuilder<BaseChain, Chain> rebulder = new NullRebuilder<BaseChain, Chain>();
            Result = rebulder.Rebuild(chain);
            Assert.AreEqual(baseChain, Result);
        }

        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        ///</summary>
        [Test]
        public void FromChildToParentTest()
        {
            Chain Result;

            NullRebuilder<Chain, BaseChain> rebulder = new NullRebuilder<Chain, BaseChain>();
            Result = rebulder.Rebuild(baseChain);
            Assert.AreEqual(chain, Result);
        }
    }
}