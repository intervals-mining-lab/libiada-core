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
    public class TestNullRebuilder
    {
  
        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object parent class to object child class
        ///</summary>
        ///
        [Test]
        public void TestFromParentToChild()
        {

            Chain chain = new Chain(12);
            BaseChain baseChain = new BaseChain(12);
            BaseChain Result;

            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"d", 1);
            chain.Add((ValueString)"b", 2);
            chain.Add((ValueString)"a", 3);
            chain.Add((ValueString)"a", 4);
            chain.Add((ValueString)"c", 5);
            chain.Add((ValueString)"b", 6);
            chain.Add((ValueString)"b", 7);
            chain.Add((ValueString)"a", 8);
            chain.Add((ValueString)"a", 9);
            chain.Add((ValueString)"c", 10);
            chain.Add((ValueString)"a", 11);

            baseChain.Add((ValueString)"a", 0);
            baseChain.Add((ValueString)"d", 1);
            baseChain.Add((ValueString)"b", 2);
            baseChain.Add((ValueString)"a", 3);
            baseChain.Add((ValueString)"a", 4);
            baseChain.Add((ValueString)"c", 5);
            baseChain.Add((ValueString)"b", 6);
            baseChain.Add((ValueString)"b", 7);
            baseChain.Add((ValueString)"a", 8);
            baseChain.Add((ValueString)"a", 9);
            baseChain.Add((ValueString)"c", 10);
            baseChain.Add((ValueString)"a", 11);

            NullRebuilder<BaseChain, Chain> rebulder = new NullRebuilder<BaseChain, Chain>();
            Result = rebulder.Rebuild(chain);
            Assert.AreEqual(baseChain, Result);
        }

        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        ///</summary>
        [Test]
        public void TestFromChildToParent()
        {

            Chain chain = new Chain(12);
            BaseChain baseChain = new BaseChain(12);
            Chain Result;

            chain.Add((ValueString)"a", 0);
            chain.Add((ValueString)"d", 1);
            chain.Add((ValueString)"b", 2);
            chain.Add((ValueString)"a", 3);
            chain.Add((ValueString)"a", 4);
            chain.Add((ValueString)"c", 5);
            chain.Add((ValueString)"b", 6);
            chain.Add((ValueString)"b", 7);
            chain.Add((ValueString)"a", 8);
            chain.Add((ValueString)"a", 9);
            chain.Add((ValueString)"c", 10);
            chain.Add((ValueString)"a", 11);

            baseChain.Add((ValueString)"a", 0);
            baseChain.Add((ValueString)"d", 1);
            baseChain.Add((ValueString)"b", 2);
            baseChain.Add((ValueString)"a", 3);
            baseChain.Add((ValueString)"a", 4);
            baseChain.Add((ValueString)"c", 5);
            baseChain.Add((ValueString)"b", 6);
            baseChain.Add((ValueString)"b", 7);
            baseChain.Add((ValueString)"a", 8);
            baseChain.Add((ValueString)"a", 9);
            baseChain.Add((ValueString)"c", 10);
            baseChain.Add((ValueString)"a", 11);

            NullRebuilder<Chain, BaseChain> rebulder = new NullRebuilder<Chain, BaseChain>();
            Result = rebulder.Rebuild(baseChain);
            Assert.AreEqual(chain, Result);
        }
    }
}