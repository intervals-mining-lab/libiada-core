using System;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    /// <summary>
    /// высота ноты
    /// </summary>
    public class Pitch : IBaseObject
    {
        public int MidiNumber { get; private set; }

        public char Step { get; private set; }

        private int Octave { get; set; }

        private int Alter { get; set; }

        public int Instrument { private get; set; }

        public Pitch(int octave, char step, int alter, int instrument = 0)
        {
            Alter = alter;
            Step = step;
            Octave = octave;
            MidiNumber = GetMidiNumberByParam(Octave, Step, Alter);
            Instrument = instrument;
        }



        private int GetMidiNumberByParam(int octave, char step, int alter)
            // вычисление глобального номера ноты через параметры
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
            return (12*(octave + 1)) + offset + alter;
        }

        private void GetParamsByMidiNumber(int midiNumber)
        {
            // TODO: сделать вычисление параметров по глобальному номеру ноты, обратная операция получению номера из параметров
        }

        public IBaseObject Clone()
        {
            return new Pitch(Octave, Step, Alter, Instrument);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (MidiNumber == ((Pitch) obj).MidiNumber)
            {
                return true;
            }
            return false;
        }
    }
}