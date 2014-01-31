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
            Assert.AreEqual(-1, (int)Tie.None);
        }
        [TestMethod]
        public void TestTie2()
        {
            Assert.AreEqual(0, (int)Tie.Start);
        }
        [TestMethod]
        public void TestTie3()
        {
            Assert.AreEqual(1, (int)Tie.Stop);
        }
        [TestMethod]
        public void TestTie4()
        {
            Assert.AreEqual(2, (int)Tie.StartStop);
        }
    }
}
