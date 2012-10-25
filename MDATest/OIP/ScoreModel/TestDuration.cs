using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.ScoreModel;

namespace MDATest.OIP.ScoreModel
{
    [TestClass]
    public class TestDuration
    {
        [TestMethod]
        public void TestAddDuration()
        {
            Duration duration1 = new Duration(1, 2, false, 480);
            Duration duration2 = new Duration(1, 4, false, 240);
            Duration duration3 = duration1.AddDuration(duration2);

            //duration1
            Assert.AreEqual(1, duration1.Numerator);
            Assert.AreEqual(2, duration1.Denominator);
            //duration2
            Assert.AreEqual(1, duration2.Numerator);
            Assert.AreEqual(4, duration2.Denominator);
            //duration3
            Assert.AreEqual(3, duration3.Numerator);
            Assert.AreEqual(4, duration3.Denominator);

            duration3 = duration3.AddDuration(duration1);

            //duration3'
            Assert.AreEqual(5, duration3.Numerator);
            Assert.AreEqual(4, duration3.Denominator);
        }
    }
}
