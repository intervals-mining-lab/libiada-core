namespace LibiadaMusic.ScoreModel
{
    using System;

    using LibiadaCore.Core;

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
        public Pitch(int octave, char step, int alter, int instrument = 0)
        {
            Alter = alter;
            Step = step;
            Octave = octave;
            MidiNumber = GetMidiNumberByParam(Octave, Step, Alter);
            Instrument = instrument;
        }

        /// <summary>
        /// Gets note number.
        /// Unique note number in midi standart.
        /// уникальный номер ноты по миди стандарту
        /// </summary>
        public int MidiNumber { get; private set; }

        /// <summary>
        /// ЗАГЛАВНАЯ (!) буква обозначающая "относительную" высоту ноты "A", "B" и т.д.
        /// </summary>
        public char Step { get; private set; }

        /// <summary>
        /// Gets or sets the instrument.
        /// </summary>
        public int Instrument { private get; set; }

        /// <summary>
        /// Gets or sets the octave number.
        /// </summary>
        public int Octave { get; private set; }

        /// <summary>
        /// Gets or sets alteration.
        /// диез/бемоль +1 диез; -1 бемоль
        /// </summary>
        public int Alter { get; private set; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new Pitch(Octave, Step, Alter, Instrument);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (MidiNumber == ((Pitch)obj).MidiNumber)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get midi number by param.
        /// вычисление глобального номера ноты через параметры
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
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if step is unknown.
        /// </exception>
        private int GetMidiNumberByParam(int octave, char step, int alter)
        {
            int offset; // сдвиг от начала октавы, в зависимости от буквы ноты
            switch (step)
            {
                case 'C':
                    offset = 0;
                    break;
                case 'D':
                    offset = 2;
                    break;
                case 'E':
                    offset = 4;
                    break;
                case 'F':
                    offset = 5;
                    break;
                case 'G':
                    offset = 7;
                    break;
                case 'A':
                    offset = 9;
                    break;
                case 'B':
                    offset = 11;
                    break;
                default:
                    throw new Exception("Error Pitch contains non-recognized STEP letters!");
            }

            return (12 * (octave + 1)) + offset + alter;
        }

        /// <summary>
        /// The get params by midi number.
        /// </summary>
        /// <param name="midiNumber">
        /// The midi number.
        /// </param>
        private void GetParamsByMidiNumber(int midiNumber)
        {
            // TODO: сделать вычисление параметров по глобальному номеру ноты, обратная операция получению номера из параметров
        }
    }
}
