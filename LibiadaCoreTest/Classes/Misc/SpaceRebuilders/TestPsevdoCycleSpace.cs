using LibiadaCore.Classes.Misc.SpaceRebuilders;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Misc.SpaceRebuilders
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestPsevdoCycleSpace
    {
        private Chain TestChain;
        private Chain CycleTestChainBuilding;
     
        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
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
            Chain cycleTestChainLevel1 = new Chain(13);
            cycleTestChainLevel1.Add((ValueString)"a", 0);
            cycleTestChainLevel1.Add((ValueString)"d", 1);
            cycleTestChainLevel1.Add((ValueString)"b", 2);
            cycleTestChainLevel1.Add((ValueString)"a", 3);
            cycleTestChainLevel1.Add((ValueString)"a", 4);
            cycleTestChainLevel1.Add((ValueString)"c", 5);
            cycleTestChainLevel1.Add((ValueString)"b", 6);
            cycleTestChainLevel1.Add((ValueString)"b", 7);
            cycleTestChainLevel1.Add((ValueString)"a", 8);
            cycleTestChainLevel1.Add((ValueString)"a", 9);
            cycleTestChainLevel1.Add((ValueString)"c", 10);
            cycleTestChainLevel1.Add((ValueString)"a", 11);
            cycleTestChainLevel1.Add((ValueString)"a", 12);

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebulder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(1);
            Chain result = rebulder.Rebuild(TestChain);
            Assert.AreEqual(cycleTestChainLevel1, result);
        }


        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestLevel5()
        {
            Chain cycleTestChainLevel5 = new Chain(17);
            cycleTestChainLevel5.Add((ValueString)"a", 0);
            cycleTestChainLevel5.Add((ValueString)"d", 1);
            cycleTestChainLevel5.Add((ValueString)"b", 2);
            cycleTestChainLevel5.Add((ValueString)"a", 3);
            cycleTestChainLevel5.Add((ValueString)"a", 4);
            cycleTestChainLevel5.Add((ValueString)"c", 5);
            cycleTestChainLevel5.Add((ValueString)"b", 6);
            cycleTestChainLevel5.Add((ValueString)"b", 7);
            cycleTestChainLevel5.Add((ValueString)"a", 8);
            cycleTestChainLevel5.Add((ValueString)"a", 9);
            cycleTestChainLevel5.Add((ValueString)"c", 10);
            cycleTestChainLevel5.Add((ValueString)"a", 11);
            cycleTestChainLevel5.Add((ValueString)"a", 12);
            cycleTestChainLevel5.Add((ValueString)"d", 13);
            cycleTestChainLevel5.Add((ValueString)"b", 14);
            cycleTestChainLevel5.Add((ValueString)"a", 15);
            cycleTestChainLevel5.Add((ValueString)"a", 16);

            PsevdoCycleSpaceRebuilder<Chain, Chain> rebulder = new PsevdoCycleSpaceRebuilder<Chain, Chain>(5);
            Chain result = rebulder.Rebuild(TestChain);
            Assert.AreEqual(cycleTestChainLevel5, result);
        }


    }
}