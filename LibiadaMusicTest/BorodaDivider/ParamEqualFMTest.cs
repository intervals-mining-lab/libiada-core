using LibiadaMusic.BorodaDivider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.BorodaDivider
{
    [TestClass]
    public class ParamEqualFMTest
    {
        [TestMethod]
        public void TestParamEqual1()
        {
            Assert.AreEqual((int) ParamEqualFM.Sequent, 0);
            Assert.AreEqual((int) ParamEqualFM.NonSequent, 1);
        }
    }
}