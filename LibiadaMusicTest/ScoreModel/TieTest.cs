using LibiadaMusic.ScoreModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.ScoreModel
{
    [TestClass]
    public class TieTest
    {
        [TestMethod]
        public void TestTie1()
        {
            Assert.AreEqual(-1, Tie.None);
        }
        [TestMethod]
        public void TestTie2()
        {
            Assert.AreEqual(0, Tie.Start);
        }
        [TestMethod]
        public void TestTie3()
        {
            Assert.AreEqual(1, Tie.Stop);
        }
        [TestMethod]
        public void TestTie4()
        {
            Assert.AreEqual(2, Tie.StartStop);
        }
    }
}
