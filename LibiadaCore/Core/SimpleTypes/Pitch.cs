namespace LibiadaCore.Core.SimpleTypes
{
    using System;
    using System.Security.Cryptography;

    using LibiadaCore.Music;

    /// <summary>
    /// высота ноты
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
        public Pitch(byte octave, NoteSymbol step, Accidental alter, Instrument instrument = Instrument.AnyOrUnknown)
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
        public byte Octave { get; }

        /// <summary>
        /// Gets alteration.
        /// </summary>
        public Accidental Alter { get; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone() => new Pitch(Octave, Step, Alter, Instrument);

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj) => obj is Pitch pitch && MidiNumber == pitch.MidiNumber;

        /// <summary>
        /// Calculates MD5 hash code using midi number.
        /// </summary>
        /// <returns>
        /// The <see cref="T:byte[]"/>.
        /// </returns>
        public byte[] GetMD5HashCode()
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(BitConverter.GetBytes(MidiNumber));
        }

        /// <summary>
        /// Calculates hash code using <see cref="MidiNumber"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => MidiNumber.GetHashCode();

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
