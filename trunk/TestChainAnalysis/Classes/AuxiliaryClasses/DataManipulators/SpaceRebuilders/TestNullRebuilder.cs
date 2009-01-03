using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
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

            Chain ObjectParentClass = new Chain(12);
            BaseChain ObjectChildClass = new BaseChain(12);
            BaseChain Result = null;

            ObjectParentClass.Add((ValueString)"a", 0);
            ObjectParentClass.Add((ValueString)"d", 1);
            ObjectParentClass.Add((ValueString)"b", 2);
            ObjectParentClass.Add((ValueString)"a", 3);
            ObjectParentClass.Add((ValueString)"a", 4);
            ObjectParentClass.Add((ValueString)"c", 5);
            ObjectParentClass.Add((ValueString)"b", 6);
            ObjectParentClass.Add((ValueString)"b", 7);
            ObjectParentClass.Add((ValueString)"a", 8);
            ObjectParentClass.Add((ValueString)"a", 9);
            ObjectParentClass.Add((ValueString)"c", 10);
            ObjectParentClass.Add((ValueString)"a", 11);

            ObjectChildClass.Add((ValueString)"a", 0);
            ObjectChildClass.Add((ValueString)"d", 1);
            ObjectChildClass.Add((ValueString)"b", 2);
            ObjectChildClass.Add((ValueString)"a", 3);
            ObjectChildClass.Add((ValueString)"a", 4);
            ObjectChildClass.Add((ValueString)"c", 5);
            ObjectChildClass.Add((ValueString)"b", 6);
            ObjectChildClass.Add((ValueString)"b", 7);
            ObjectChildClass.Add((ValueString)"a", 8);
            ObjectChildClass.Add((ValueString)"a", 9);
            ObjectChildClass.Add((ValueString)"c", 10);
            ObjectChildClass.Add((ValueString)"a", 11);

            NullRebuilder<BaseChain, Chain> Rebulder = new NullRebuilder<BaseChain, Chain>();
            Result = Rebulder.Rebuild(ObjectParentClass);
            Assert.AreEqual(ObjectChildClass, Result);
        }

        ///<summary>
        /// We need to test that we can correct conver chain from 
        /// object child class to object parent class
        ///</summary>
        [Test]
        public void TestFromChildToParent()
        {

            Chain ObjectParentClass = new Chain(12);
            BaseChain ObjectChildClass = new BaseChain(12);
            Chain Result = null;

            ObjectParentClass.Add((ValueString)"a", 0);
            ObjectParentClass.Add((ValueString)"d", 1);
            ObjectParentClass.Add((ValueString)"b", 2);
            ObjectParentClass.Add((ValueString)"a", 3);
            ObjectParentClass.Add((ValueString)"a", 4);
            ObjectParentClass.Add((ValueString)"c", 5);
            ObjectParentClass.Add((ValueString)"b", 6);
            ObjectParentClass.Add((ValueString)"b", 7);
            ObjectParentClass.Add((ValueString)"a", 8);
            ObjectParentClass.Add((ValueString)"a", 9);
            ObjectParentClass.Add((ValueString)"c", 10);
            ObjectParentClass.Add((ValueString)"a", 11);

            ObjectChildClass.Add((ValueString)"a", 0);
            ObjectChildClass.Add((ValueString)"d", 1);
            ObjectChildClass.Add((ValueString)"b", 2);
            ObjectChildClass.Add((ValueString)"a", 3);
            ObjectChildClass.Add((ValueString)"a", 4);
            ObjectChildClass.Add((ValueString)"c", 5);
            ObjectChildClass.Add((ValueString)"b", 6);
            ObjectChildClass.Add((ValueString)"b", 7);
            ObjectChildClass.Add((ValueString)"a", 8);
            ObjectChildClass.Add((ValueString)"a", 9);
            ObjectChildClass.Add((ValueString)"c", 10);
            ObjectChildClass.Add((ValueString)"a", 11);

            NullRebuilder<Chain, BaseChain> Rebulder = new NullRebuilder<Chain, BaseChain>();
            Result = Rebulder.Rebuild(ObjectChildClass);
            Assert.AreEqual(ObjectParentClass, Result);
        }
    }
}