using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.Root.SimpleTypes
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestValueInt
    {
        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestSum()
        {
            int x = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4,x);
            ValueInt y = new ValueInt(1) + new ValueInt(3);
            Assert.AreEqual(4,y);
        }
    }
}