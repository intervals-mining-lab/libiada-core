using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestWavePathFinder
    {
        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestPathExists()
        {
            Graph TestGraph = new Graph();
            Branch[] Branches = new Branch[5];
            Branches[0] = new Branch(1, 3);
            TestGraph.Add(Branches[0], 1);

            Branches[1] = new Branch(3, 2);
            TestGraph.Add(Branches[1], 2);

            Branches[2] = new Branch(4, 3);
            TestGraph.Add(Branches[2], 3);

            Branches[3] = new Branch(4, 5);
            TestGraph.Add(Branches[3], 4);

            Branches[4] = new Branch(5, 6);
            TestGraph.Add(Branches[4], 5);

            WavePathFinder Finder = new WavePathFinder(TestGraph);
            Assert.IsTrue(Finder.PathExist(1, 6));
        }
    }
}