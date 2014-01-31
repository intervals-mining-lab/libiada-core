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
            Assert.AreEqual((int)ParamPauseTreatment.Ignore, 0);
            Assert.AreEqual((int)ParamPauseTreatment.NoteTrace, 1);
            Assert.AreEqual((int)ParamPauseTreatment.SilenceNote, 2);
        }
    }
}
