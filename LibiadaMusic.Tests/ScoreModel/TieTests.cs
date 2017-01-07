namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The tie tests.
    /// </summary>
    [TestClass]
    public class TieTests
    {
        /// <summary>
        /// The tie first test.
        /// </summary>
        [TestMethod]
        public void TieFirstTest()
        {
            Assert.AreEqual(0, (int)Tie.None);
        }

        /// <summary>
        /// The tie second test.
        /// </summary>
        [TestMethod]
        public void TieSecondTest()
        {
            Assert.AreEqual(1, (int)Tie.Start);
        }

        /// <summary>
        /// The tie third test.
        /// </summary>
        [TestMethod]
        public void TieThirdTest()
        {
            Assert.AreEqual(2, (int)Tie.End);
        }

        /// <summary>
        /// The tie fourth test.
        /// </summary>
        [TestMethod]
        public void TieFourthTest()
        {
            Assert.AreEqual(3, (int)Tie.Continue);
        }
    }
}
