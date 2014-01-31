using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibiadaMusic.OIP.BorodaDivider;

namespace LibiadaMusicTest.OIPTest.TestBorodaDivider
{
    [TestClass]
    public class ParamEqualFMTest
    {
        [TestMethod]
        public void TestParamEqual1()
        {
            Assert.AreEqual(ParamEqualFM.Sequent, 0);
            Assert.AreEqual(ParamEqualFM.NonSequent, 1);
        }
    }
}
