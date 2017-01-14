namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using NUnit.Framework;

    /// <summary>
    /// Pitch tests.
    /// </summary>
    [TestFixture]
    public class PitchTests
    {
        /// <summary>
        /// The pitch constructor test.
        /// </summary>
        [Test]
        public void PitchConstructorTest()
        {
            var initialPitch = new Pitch(1, NoteSymbol.A, Accidental.Bekar);
            var midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
            initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
            midiNumberPitch = new Pitch(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.MidiNumber, midiNumberPitch.MidiNumber);
        }
    }
}
