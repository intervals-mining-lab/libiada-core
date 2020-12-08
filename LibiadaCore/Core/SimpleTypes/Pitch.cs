namespace LibiadaCore.Core.SimpleTypes
{
    using System;

    using LibiadaCore.Music;

    /// <summary>
    /// Pitch of a note.
    /// </summary>
    public class Pitch : IBaseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pitch"/> class.
        /// </summary>
        /// <param name="octave">
        /// The octave.
        /// </param>
        /// <param name="step">
        /// The step.
        /// </param>
        /// <param name="alter">
        /// The alter.
        /// </param>
        /// <param name="instrument">
        /// The instrument.
        /// </param>
        public Pitch(short octave, NoteSymbol step, Accidental alter, Instrument instrument = Instrument.AnyOrUnknown)
        {
            Alter = alter;
            Step = step;
            Octave = octave;
            MidiNumber = GetMidiNumber();
            Instrument = instrument;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pitch"/> class.
        /// </summary>
        /// <param name="midiNumber">
        /// The midi number.
        /// </param>
        /// <param name="instrument">
        /// The instrument.
        /// </param>
        /// <exception cref="Exception">
        /// Thrown if note is not recognized.
        /// </exception>
        public Pitch(int midiNumber, Instrument instrument = Instrument.AnyOrUnknown)
        {
            Alter = MidiNumberManager.GetAlterFromMidiNumber(midiNumber);
            Step = MidiNumberManager.GetNoteSymbolFromMidiNumber(midiNumber);
            Octave = MidiNumberManager.GetOctaveFromMidiNumber(midiNumber);
            MidiNumber = GetMidiNumber();
            Instrument = instrument;
        }

        /// <summary>
        /// Gets note number.
        /// Unique note number in midi standard.
        /// </summary>
        public int MidiNumber { get; }

        /// <summary>
        /// Gets step.
        /// </summary>
        public NoteSymbol Step { get; }

        /// <summary>
        /// Gets the instrument.
        /// </summary>
        public Instrument Instrument { get; }

        /// <summary>
        /// Gets the octave number.
        /// </summary>
        public short Octave { get; }

        /// <summary>
        /// Gets alteration.
        /// </summary>
        public Accidental Alter { get; }

        /// <summary>
        /// Creates a copy of pitch.
        /// </summary>
        /// <returns>
        /// The new pitch as <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone() => new Pitch(Octave, Step, Alter, Instrument);

        /// <summary>
        /// Compares midiNumbers of pitches.
        /// </summary>
        /// <param name="obj">
        /// Another pitch.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj) => obj is Pitch pitch && MidiNumber == pitch.MidiNumber;

        /// <summary>
        /// Calculates hash code using <see cref="MidiNumber"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => MidiNumber.GetHashCode();


        /// <summary>
        /// Represents pitch as its midiNumber converted to string.
        /// </summary>
        /// <returns>
        /// MidiNumber as <see cref="string"/>.
        /// </returns>
        public override string ToString() => MidiNumber.ToString();

        /// <summary>
        /// Calculates midi number from pitch params.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if step is unknown.
        /// </exception>
        private int GetMidiNumber() => (12 * (Octave + 1)) + (byte)Step + (short)Alter;
    }
}
