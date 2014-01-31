using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.OIP.BorodaDivider;

namespace MDATest.OIPTest.TestBorodaDivider
{    
    [TestClass]    
    public class TestParamPauseTreatment
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
