namespace LibiadaMusic.Tests.ScoreModel
{
    using LibiadaMusic.ScoreModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The midi number manager tests.
    /// </summary>
    [TestClass]
    public class MidiNumberManagerTests
    {
        /// <summary>
        /// The get octave from midi number test.
        /// </summary>
        [TestMethod]
        public void GetOctaveFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, 'A', 0);
            var octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Octave, octave);

            initialPitch = new Pitch(5, 'C', 1);
            octave = MidiNumberManager.GetOctaveFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Octave, octave);
        }

        /// <summary>
        /// The get step from midi number test.
        /// </summary>
        [TestMethod]
        public void GetStepFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, 'A', 0);
            var step = MidiNumberManager.StepToNoteSymbol(MidiNumberManager.GetStepFromMidiNumber(initialPitch.MidiNumber));
            Assert.AreEqual(initialPitch.Step, step);

            initialPitch = new Pitch(5, 'C', 1);
            step = MidiNumberManager.StepToNoteSymbol(MidiNumberManager.GetStepFromMidiNumber(initialPitch.MidiNumber));
            Assert.AreEqual(initialPitch.Step, step);
        }

        /// <summary>
        /// The get alter from midi number test.
        /// </summary>
        [TestMethod]
        public void GetAlterFromMidiNumberTest()
        {
            var initialPitch = new Pitch(1, 'A', 0);
            var alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Alter, alter);

            initialPitch = new Pitch(5, 'C', 1);
            alter = MidiNumberManager.GetAlterFromMidiNumber(initialPitch.MidiNumber);
            Assert.AreEqual(initialPitch.Alter, alter);
        }

        /// <summary>
        /// The extract midi number modified with measure attributes test.
        /// </summary>
        [TestMethod]
        public void ExtractMidiNumberModifiedWithMeasureAttributesTest()
        {
            var initialPitch = new Pitch(1, 'A', 0);
            var key = new Key(0);
            var modifiedMidiNumber = MidiNumberManager.ExtractMidiNumberModifiedWithMeasureAttributes(initialPitch, key);
            Assert.AreEqual(initialPitch.MidiNumber, modifiedMidiNumber);

            initialPitch = new Pitch(5, 'C', 1);
            key = new Key(0);
            modifiedMidiNumber = MidiNumberManager.ExtractMidiNumberModifiedWithMeasureAttributes(initialPitch, key);
            Assert.AreEqual(initialPitch.MidiNumber, modifiedMidiNumber);

            initialPitch = new Pitch(5, 'B', 1);
            key = new Key(-2);
            modifiedMidiNumber = MidiNumberManager.ExtractMidiNumberModifiedWithMeasureAttributes(initialPitch, key);
            Assert.AreEqual(initialPitch.MidiNumber - 1, modifiedMidiNumber);
        }
    }
}
