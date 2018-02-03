namespace LibiadaCore.Tests.Music
{
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Music;

    using NUnit.Framework;

    /// <summary>
    /// The midi number manager tests.
    /// </summary>
    [TestFixture]
    public class MidiNumberManagerTests
    {
        /// <summary>
        /// The get octave from midi number test.
        /// </summary>
        [Test]
        public void GetOctaveFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, NoteSymbol.A, 0);
            var octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Octave, octave);

            initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
            octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Octave, octave);
        }

        /// <summary>
        /// Test for GetNoteSymbolFromMidiNumber method.
        /// </summary>
        [Test]
        public void GetNoteSymbolFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, NoteSymbol.A, Accidental.Bekar);
            var step = MidiNumberManager.GetNoteSymbolFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Step, step);

            initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
            step = MidiNumberManager.GetNoteSymbolFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Step, step);
        }

        /// <summary>
        /// The get alter from midi number test.
        /// </summary>
        [Test]
        public void GetAlterFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, NoteSymbol.A, Accidental.Bekar);
            var alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Alter, alter);

            initialPitch = new Pitch(5, NoteSymbol.C, Accidental.Sharp);
            alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Alter, alter);
        }
    }
}
