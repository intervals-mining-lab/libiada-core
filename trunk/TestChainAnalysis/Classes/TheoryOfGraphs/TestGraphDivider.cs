using System.Collections;
using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestGraphDivider
    {
        ///<summary>
        ///</summary>
        [Test]
        public void init()
        {
            
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestDivide()
        {
            Graph TestGraph = new Graph();
            TestGraph.Add(new Branch(0, 2), 1);
            TestGraph.Add(new Branch(2, 1), 2);
            TestGraph.Add(new Branch(3, 0), 3);
            TestGraph.Add(new Branch(3, 4), 4);
            TestGraph.Add(new Branch(4, 5), 5);

            Divider Div = new Divider(TestGraph);

            ArrayList Result = Div.Divide(new Branch(0, 3));

            Assert.IsTrue(((Graph)Result[0]).Contains(new Branch(0, 2)));
            Assert.IsTrue(((Graph)Result[0]).Contains(new Branch(2, 1)));

            Assert.IsTrue(((Graph)Result[1]).Contains(new Branch(3, 4)));
            Assert.IsTrue(((Graph)Result[1]).Contains(new Branch(4, 5)));

            Assert.IsTrue(((Graph)Result[0]).Points.Contains(0));
            Assert.IsTrue(((Graph)Result[0]).Points.Contains(2));
            Assert.IsTrue(((Graph)Result[0]).Points.Contains(1));

            Assert.IsTrue(((Graph)Result[1]).Points.Contains(4));
            Assert.IsTrue(((Graph)Result[1]).Points.Contains(3));
            Assert.IsTrue(((Graph)Result[1]).Points.Contains(5));
        }

    }
}