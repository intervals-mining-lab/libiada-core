namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The param equal fm tests.
    /// </summary>
    [TestClass]
    public class ParamEqualFMTests
    {
        /// <summary>
        /// The param equal test.
        /// </summary>
        [TestMethod]
        public void ParamEqualTest()
        {
            Assert.AreEqual((int)ParamEqualFM.Sequent, 0);
            Assert.AreEqual((int)ParamEqualFM.NonSequent, 1);
        }
    }
}
