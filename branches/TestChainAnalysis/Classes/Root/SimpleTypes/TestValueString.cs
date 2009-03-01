using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.Root.SimpleTypes
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestValueString
    {
        ///<summary>
        ///</summary>
        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(new ValueString("1"), new ValueString("1"));
        }
    }


}