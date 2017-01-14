namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;

    using NUnit.Framework;

    /// <summary>
    /// The param pause treatment tests.
    /// </summary>
    [TestFixture]
    public class ParamPauseTreatmentTests
    {
        /// <summary>
        /// The param pause test.
        /// </summary>
        [Test]
        public void ParamPauseTest()
        {
            Assert.AreEqual((int)ParamPauseTreatment.Ignore, 0);
            Assert.AreEqual((int)ParamPauseTreatment.NoteTrace, 1);
            Assert.AreEqual((int)ParamPauseTreatment.SilenceNote, 2);
        }
    }
}
