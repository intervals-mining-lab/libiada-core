﻿namespace LibiadaMusic.Tests.BorodaDivider
{
    using LibiadaMusic.BorodaDivider;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The param pause treatment tests.
    /// </summary>
    [TestClass]
    public class ParamPauseTreatmentTests
    {
        /// <summary>
        /// The param pause test.
        /// </summary>
        [TestMethod]
        public void ParamPauseTest()
        {
            Assert.AreEqual((int)ParamPauseTreatment.Ignore, 0);
            Assert.AreEqual((int)ParamPauseTreatment.NoteTrace, 1);
            Assert.AreEqual((int)ParamPauseTreatment.SilenceNote, 2);
        }
    }
}
