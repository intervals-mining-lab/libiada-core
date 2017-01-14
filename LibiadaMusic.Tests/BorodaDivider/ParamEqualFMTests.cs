namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;

    using NUnit.Framework;

    /// <summary>
    /// The param equal fm tests.
    /// </summary>
    [TestFixture]
    public class ParamEqualFMTests
    {
        /// <summary>
        /// The param equal test.
        /// </summary>
        [Test]
        public void ParamEqualTest()
        {
            Assert.AreEqual((int)ParamEqualFM.Sequent, 0);
            Assert.AreEqual((int)ParamEqualFM.NonSequent, 1);
        }
    }
}
