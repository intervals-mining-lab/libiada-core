using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIP.BorodaDivider
{    
    [TestClass]
    public class TestPauseTreatment
    {
        [TestMethod]
        public void TestParamPause1()
        {
            Assert.AreEqual(0, (int)PauseTreatment.Ignore);
            Assert.AreEqual(1, (int)PauseTreatment.NoteTrace);
            Assert.AreEqual(2, (int)PauseTreatment.SilenceNote);
        }
    }
}
