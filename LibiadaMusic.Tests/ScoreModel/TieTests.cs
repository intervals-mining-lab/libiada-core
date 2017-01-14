namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// The tie tests.
    /// </summary>
    [TestFixture]
    public class TieTests
    {
        /// <summary>
        /// The tie first test.
        /// </summary>
        [Test]
        public void TieFirstTest()
        {
            Assert.AreEqual(0, (int)Tie.None);
        }

        /// <summary>
        /// The tie second test.
        /// </summary>
        [Test]
        public void TieSecondTest()
        {
            Assert.AreEqual(1, (int)Tie.Start);
        }

        /// <summary>
        /// The tie third test.
        /// </summary>
        [Test]
        public void TieThirdTest()
        {
            Assert.AreEqual(2, (int)Tie.End);
        }

        /// <summary>
        /// The tie fourth test.
        /// </summary>
        [Test]
        public void TieFourthTest()
        {
            Assert.AreEqual(3, (int)Tie.Continue);
        }
    }
}
