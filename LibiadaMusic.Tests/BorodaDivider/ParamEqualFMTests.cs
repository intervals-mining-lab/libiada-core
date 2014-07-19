using LibiadaMusic.BorodaDivider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.BorodaDivider
{
    [TestClass]
    public class ParamEqualFMTests
    {
        [TestMethod]
        public void ParamEqualTest()
        {
            Assert.AreEqual((int) ParamEqualFM.Sequent, 0);
            Assert.AreEqual((int) ParamEqualFM.NonSequent, 1);
        }
    }
}