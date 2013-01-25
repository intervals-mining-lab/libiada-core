using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    /// Test space rebuilder NullRebuilder
    ///</summary>
    [TestFixture]
    public class NullRebuilderTest
    {
  
        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object parent class to object child class
        ///</summary>
        ///
        [Test]
        public void FromParentToChildTest()
        {

            Chain chain = new Chain(12);
            BaseChain baseChain = new BaseChain(12);
            BaseChain Result = null;

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

            NullRebuilder<BaseChain, Chain> Rebulder = new NullRebuilder<BaseChain, Chain>();
            Result = Rebulder.Rebuild(chain);
            Assert.AreEqual(baseChain, Result);
        }

        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        ///</summary>
        [Test]
        public void FromChildToParentTest()
        {

            Chain chain = new Chain(12);
            BaseChain baseChain = new BaseChain(12);
            Chain Result = null;

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

            NullRebuilder<Chain, BaseChain> Rebulder = new NullRebuilder<Chain, BaseChain>();
            Result = Rebulder.Rebuild(baseChain);
            Assert.AreEqual(chain, Result);
        }
    }

    class NullRebuilderTestImpl : NullRebuilderTest
    {
    }
}