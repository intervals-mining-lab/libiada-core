using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.TheoryOfGraphs
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestBranch
    {
        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(new Branch(1, 2), new Branch(1, 2));
            Assert.AreNotEqual(new Branch(1, 2), new Branch(1, 3));
            Assert.AreNotEqual(new Branch(1, 2), new Branch(3, 2));
            Branch Temp = new Branch(1, 2);
            Assert.IsTrue(Temp.Equals(1));
            Assert.IsTrue(Temp.Equals(2));
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestGetOtherPoint()
        {
            Branch Temp  = new Branch(1,2);
            Assert.AreEqual(2, Temp.GetOtherPoint(1));

            Temp = new Branch(1, 2);
            Assert.AreEqual(1, Temp.GetOtherPoint(2));
        }
    }
}