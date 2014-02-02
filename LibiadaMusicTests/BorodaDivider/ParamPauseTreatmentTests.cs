using LibiadaMusic.BorodaDivider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTests.BorodaDivider
{
    [TestClass]
    public class ParamPauseTreatmentTests
    {
        [TestMethod]
        public void ParamPauseTest()
        {
            Assert.AreEqual((int) ParamPauseTreatment.Ignore, 0);
            Assert.AreEqual((int) ParamPauseTreatment.NoteTrace, 1);
            Assert.AreEqual((int) ParamPauseTreatment.SilenceNote, 2);
        }
    }
}