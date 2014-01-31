using LibiadaMusic.BorodaDivider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest.BorodaDivider
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
