namespace Libiada.Core.Music;

using System;
using System.Collections.Generic;

using Libiada.Core.Core.SimpleTypes;

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
    public static short GetOctaveFromMidiNumber(int midiNumber)
    {
        return (short)((midiNumber / NotesInOctave) - 1);
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
        var notes = new HashSet<int> { 0, 2, 4, 5, 7, 9, 11 };
        int step = midiNumber % NotesInOctave;

        if (notes.Contains(step))
        {
            return (NoteSymbol)step;
        }

        step--;

        if (notes.Contains(step))
        {
            return (NoteSymbol)step;
        }

        throw new Exception($"Note value is invalid: {step}. MidiNumber was: ${midiNumber}.");
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
        NoteSymbol note = GetNoteSymbolFromMidiNumber(midiNumber);
        int rawNote = midiNumber % NotesInOctave;
        return (Accidental)(rawNote == (byte)note ? 0 : 1);
    }
}
