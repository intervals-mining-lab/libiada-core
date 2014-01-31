using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibiadaMusic.OIP.BorodaDivider;

namespace LibiadaMusicTest.OIPTest.TestBorodaDivider
{    
    [TestClass]
    public class ParamPauseTreatmentTest
    {
        [TestMethod]
        public void TestParamPause1()
        {
            Assert.AreEqual(ParamPauseTreatment.Ignore, 0);
            Assert.AreEqual(ParamPauseTreatment.NoteTrace, 1);
            Assert.AreEqual(ParamPauseTreatment.SilenceNote, 2);
        }
    }
}
