using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.BorodaDivider
{
    [TestClass]
    public class TestFMSequentEquality
    {
        [TestMethod]
        public void TestParamEqual1()
        {
            Assert.AreEqual(0, (int)FMSequentEquality.Sequent);
            Assert.AreEqual(1, (int)FMSequentEquality.NonSequent);
        }
    }
}
