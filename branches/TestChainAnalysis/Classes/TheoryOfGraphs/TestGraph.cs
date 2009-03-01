using System.Collections;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestGraph
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
        public void TestInputOutput()
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


            int i = 0;
            foreach (Branch branch in Branches)
            {
                Assert.IsTrue(TestGraph.Branches.Contains(branch));
                i++;
            }

            i = 0;
            foreach (Branch branch in Branches)
            {
                Assert.AreEqual(i+1, TestGraph[branch]);
                i++;
            }

            Assert.AreEqual(5, TestGraph.Count);
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestClone()
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

            Assert.AreEqual(TestGraph, TestGraph.Clone());
            Assert.AreNotSame(TestGraph, TestGraph.Clone());
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestGetBranches()
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

            ArrayList Result = TestGraph.BranchesContains(3);
            
            Assert.IsTrue(Result.Contains(new Branch(1,3)));
            Assert.IsTrue(Result.Contains(new Branch(3, 1)));

            Assert.IsTrue(Result.Contains(new Branch(3, 2)));
            Assert.IsTrue(Result.Contains(new Branch(2, 3)));

            Assert.IsTrue(Result.Contains(new Branch(3, 4)));
            Assert.IsTrue(Result.Contains(new Branch(4, 3)));

        }



        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestGetPoints()
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

            ArrayList Result = TestGraph.PointsConnectedWith(3);

            Assert.IsTrue(Result.Contains(1));
            Assert.IsTrue(Result.Contains(2));
            Assert.IsTrue(Result.Contains(4));

        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestDelete()
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


            int i = 0;
            foreach (Branch branch in TestGraph.Branches)
            {
                Assert.AreEqual(Branches[i], branch);
                i++;
            }

            i = 0;
            foreach (Branch branch in Branches)
            {
                Assert.AreEqual(i + 1, TestGraph[branch]);
                i++;
            }

            Assert.AreEqual(5, TestGraph.Count);

            Assert.IsTrue(TestGraph.Contains(Branches[2]));
            TestGraph.Remove(Branches[2]);
            Assert.IsFalse(TestGraph.Contains(Branches[2]));
            Assert.AreEqual(4, TestGraph.Count);
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestGetMatrix()
        {
            Graph TestGraph = new Graph();
            Branch[] Branches = new Branch[5];
            Branches[0] = new Branch(0, 2);
            TestGraph.Add(Branches[0], 1);

            Branches[1] = new Branch(2, 1);
            TestGraph.Add(Branches[1], 2);

            Branches[2] = new Branch(3, 2);
            TestGraph.Add(Branches[2], 3);

            Branches[3] = new Branch(3, 4);
            TestGraph.Add(Branches[3], 4);

            Branches[4] = new Branch(4, 5);
            TestGraph.Add(Branches[4], 5);

            Matrix Result = TestGraph.AsMatrix();

            Assert.AreEqual(1, Result.Get(0, 2));
            Assert.AreEqual(2, Result.Get(2, 1));
            Assert.AreEqual(3, Result.Get(3, 2));
            Assert.AreEqual(4, Result.Get(3, 4));
            Assert.AreEqual(5, Result.Get(4, 5));
        }
    }
}