namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Pitch tests.
    /// </summary>
    [TestClass]
    public class PitchTests
    {
        /// <summary>
        /// The pitch constructor test.
        /// </summary>
        [TestMethod]
        public void PitchConstructorTest()
        {
            var initialPitch = new Pitch(1, 'A', Accidental.Bekar);
            var midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
            initialPitch = new Pitch(5, 'C', Accidental.Sharp);
            midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
        }
    }
}
