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
            Assert.AreEqual(ParamEqualFM.Sequent, 0);
            Assert.AreEqual(ParamEqualFM.NonSequent, 1);
        }
    }
}
