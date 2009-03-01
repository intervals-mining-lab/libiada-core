using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestPsevdoCycleSpace
    {
        private Chain TestChain = null;
        private Chain CycleTestChainBuilding = null;
     
        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            TestChain = new Chain(12);
            TestChain.Add((ValueString)"a", 0);
            TestChain.Add((ValueString)"d", 1);
            TestChain.Add((ValueString)"b", 2);
            TestChain.Add((ValueString)"a", 3);
            TestChain.Add((ValueString)"a", 4);
            TestChain.Add((ValueString)"c", 5);
            TestChain.Add((ValueString)"b", 6);
            TestChain.Add((ValueString)"b", 7);
            TestChain.Add((ValueString)"a", 8);
            TestChain.Add((ValueString)"a", 9);
            TestChain.Add((ValueString)"c", 10);
            TestChain.Add((ValueString)"a", 11);

            CycleTestChainBuilding = new Chain(18);
            CycleTestChainBuilding.Add((ValueString)"a", 0);
            CycleTestChainBuilding.Add((ValueString)"d", 1);
            CycleTestChainBuilding.Add((ValueString)"b", 2);
            CycleTestChainBuilding.Add((ValueString)"a", 3);
            CycleTestChainBuilding.Add((ValueString)"a", 4);
            CycleTestChainBuilding.Add((ValueString)"c", 5);
            CycleTestChainBuilding.Add((ValueString)"b", 6);
            CycleTestChainBuilding.Add((ValueString)"b", 7);
            CycleTestChainBuilding.Add((ValueString)"a", 8);
            CycleTestChainBuilding.Add((ValueString)"a", 9);
            CycleTestChainBuilding.Add((ValueString)"c", 10);
            CycleTestChainBuilding.Add((ValueString)"a", 11);
            CycleTestChainBuilding.Add((ValueString)"a", 12);
            CycleTestChainBuilding.Add((ValueString)"d", 13);
            CycleTestChainBuilding.Add((ValueString)"b", 14);
            CycleTestChainBuilding.Add((ValueString)"a", 15);
            CycleTestChainBuilding.Add((ValueString)"a", 16);
            CycleTestChainBuilding.Add((ValueString)"c", 17);
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestLevel1()
        {
            Chain CycleTestChainLevel1 = new Chain(13);
            CycleTestChainLevel1.Add((ValueString)"a", 0);
            CycleTestChainLevel1.Add((ValueString)"d", 1);
            CycleTestChainLevel1.Add((ValueString)"b", 2);
            CycleTestChainLevel1.Add((ValueString)"a", 3);
            CycleTestChainLevel1.Add((ValueString)"a", 4);
            CycleTestChainLevel1.Add((ValueString)"c", 5);
            CycleTestChainLevel1.Add((ValueString)"b", 6);
            CycleTestChainLevel1.Add((ValueString)"b", 7);
            CycleTestChainLevel1.Add((ValueString)"a", 8);
            CycleTestChainLevel1.Add((ValueString)"a", 9);
            CycleTestChainLevel1.Add((ValueString)"c", 10);
            CycleTestChainLevel1.Add((ValueString)"a", 11);
            CycleTestChainLevel1.Add((ValueString)"a", 12);

            PsevdoCycleSpace<Chain, Chain> Rebulder = new PsevdoCycleSpace<Chain, Chain>(1);
            Chain Result = Rebulder.Rebuild(TestChain);
            Assert.AreEqual(CycleTestChainLevel1, Result);
        }


        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestLevel5()
        {
            Chain CycleTestChainLevel5 = new Chain(17);
            CycleTestChainLevel5.Add((ValueString)"a", 0);
            CycleTestChainLevel5.Add((ValueString)"d", 1);
            CycleTestChainLevel5.Add((ValueString)"b", 2);
            CycleTestChainLevel5.Add((ValueString)"a", 3);
            CycleTestChainLevel5.Add((ValueString)"a", 4);
            CycleTestChainLevel5.Add((ValueString)"c", 5);
            CycleTestChainLevel5.Add((ValueString)"b", 6);
            CycleTestChainLevel5.Add((ValueString)"b", 7);
            CycleTestChainLevel5.Add((ValueString)"a", 8);
            CycleTestChainLevel5.Add((ValueString)"a", 9);
            CycleTestChainLevel5.Add((ValueString)"c", 10);
            CycleTestChainLevel5.Add((ValueString)"a", 11);
            CycleTestChainLevel5.Add((ValueString)"a", 12);
            CycleTestChainLevel5.Add((ValueString)"d", 13);
            CycleTestChainLevel5.Add((ValueString)"b", 14);
            CycleTestChainLevel5.Add((ValueString)"a", 15);
            CycleTestChainLevel5.Add((ValueString)"a", 16);

            PsevdoCycleSpace<Chain, Chain> Rebulder = new PsevdoCycleSpace<Chain, Chain>(5);
            Chain Result = Rebulder.Rebuild(TestChain);
            Assert.AreEqual(CycleTestChainLevel5, Result);
        }


    }
}