namespace LibiadaCore.Tests.Music
{
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The param pause treatment tests.
    /// </summary>
    [TestFixture]
    public class PauseTreatmentTests
    {
        /// <summary>
        /// The param pause test.
        /// </summary>
        [Test]
        public void ParamPauseTest()
        {
            Assert.AreEqual((int)PauseTreatment.Ignore, 1);
            Assert.AreEqual((int)PauseTreatment.NoteTrace, 2);
            Assert.AreEqual((int)PauseTreatment.SilenceNote, 3);
        }
    }
}
