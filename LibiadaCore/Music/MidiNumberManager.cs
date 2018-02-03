namespace LibiadaCore.Music
{
    using System;
    using System.Linq;

    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The midi number manager.
    /// </summary>
    public static class MidiNumberManager
    {
        /// <summary>
        /// The notes in octave.
        /// </summary>
        private const byte NotesInOctave = 12;

        /// <summary>
        /// The get octave from midi number.
        /// </summary>
        /// <param name="midiNumber">
        /// The midi number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetOctaveFromMidiNumber(int midiNumber)
        {
            return (midiNumber / NotesInOctave) - 1;
        }

        /// <summary>
        /// Extracts note symbol (and number) from midi number.
        /// </summary>
        /// <param name="midiNumber">
        /// The midi number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if step is invalid.
        /// </exception>
        public static NoteSymbol GetNoteSymbolFromMidiNumber(int midiNumber)
        {
            var notes = new[] { 0, 2, 4, 5, 7, 9, 11 };
            var step = midiNumber % NotesInOctave;

            if (notes.Any(n => n == step))
            {
                return (NoteSymbol)step;
            }

            step--;

            if (notes.Any(n => n == step))
            {
                return (NoteSymbol)step;
            }

            throw new Exception("Note value is invalid: " + step);
        }

        /// <summary>
        /// The get alter from midi number.
        /// </summary>
        /// <param name="midiNumber">
        /// The midi number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static Accidental GetAlterFromMidiNumber(int midiNumber)
        {
            var note = GetNoteSymbolFromMidiNumber(midiNumber);
            var rawNote = midiNumber % NotesInOctave;
            return (Accidental)(rawNote == (byte)note ? 0 : 1);
        }
    }
}
