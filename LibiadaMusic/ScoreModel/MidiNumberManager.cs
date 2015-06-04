using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibiadaMusic.ScoreModel
{
    public static class MidiNumberManager
    {
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
            return (midiNumber / 12) - 1;
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
            var step = midiNumber % 12;
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
            var rawNote = midiNumber % 12;
            return rawNote == note ? 0 : 1;
        }

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
                    throw new Exception("Pitch contains non-recognized STEP.");
            } 
        }
    }
}
