namespace LibiadaMusic.ScoreModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        /// The get step from midi number.
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
        public static int GetStepFromMidiNumber(int midiNumber)
        {
            var notes = new[] { 0, 2, 4, 5, 7, 9, 11 };
            var step = midiNumber % NotesInOctave;
            if (notes.Any(n => n == step))
            {
                return step;
            }
            else
            {
                step -= 1;
                if (notes.Any(n => n == step))
                {
                    return step;
                }
                else
                {
                    throw new Exception("Note value is invalid: " + step);
                }
            }
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
        public static int GetAlterFromMidiNumber(int midiNumber)
        {
            var note = GetStepFromMidiNumber(midiNumber);
            var rawNote = midiNumber % NotesInOctave;
            return rawNote == note ? 0 : 1;
        }

        /// <summary>
        /// The step to note symbol.
        /// </summary>
        /// <param name="step">
        /// The step.
        /// </param>
        /// <returns>
        /// The <see cref="char"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if step is invalid.
        /// </exception>
        public static char StepToNoteSymbol(int step)
        {
            switch (step)
            {
                case 0:
                    return 'C';
                case 2:
                    return 'D';
                case 4:
                    return 'E';
                case 5:
                    return 'F';
                case 7:
                    return 'G';
                case 9:
                    return 'A';
                case 11:
                    return 'B';
                default:
                    throw new ArgumentException("Pitch contains non-recognized STEP.");
            } 
        }

        /// <summary>
        /// The extract midi number modified with measure attributes.
        /// </summary>
        /// <param name="pitch">
        /// The pitch.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int ExtractMidiNumberModifiedWithMeasureAttributes(Pitch pitch, Key key)
        {
            // #
            var sharpOrder = new List<int> { 5, 0, 7, 2, 9, 4, 11 };

            // b
            var flatOrder = new List<int> { 11, 4, 9, 2, 7, 0, 5 };  
            List<int> modifiers;
            int shift;

            if (key.Fifths > 0)
            {
                modifiers = sharpOrder;
                shift = 1;
            }
            else
            {
                modifiers = flatOrder;
                shift = -1;
            }

            var fifths = Math.Abs(key.Fifths);

            for (int i = 0; i < fifths; i++)
            {
                if (pitch.Step == StepToNoteSymbol(modifiers[i]))
                {
                    return pitch.MidiNumber + shift;
                }
            }

            return pitch.MidiNumber;
        }
    }
}
