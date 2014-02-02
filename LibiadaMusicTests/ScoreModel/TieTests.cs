using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTests.ScoreModel
{
    [TestClass]
    public class TieTests
    {
        [TestMethod]
        public void TieFirstTest()
        {
            Assert.AreEqual(0, (int)Tie.None);
        }

        [TestMethod]
        public void TieSecondTest()
        {
            Assert.AreEqual(1, (int)Tie.Start);
        }

        [TestMethod]
        public void TieThirdTest()
        {
            Assert.AreEqual(2, (int)Tie.Stop);
        }

        [TestMethod]
        public void TieFourthTest()
        {
            Assert.AreEqual(3, (int)Tie.StartStop);
        }
    }
}
