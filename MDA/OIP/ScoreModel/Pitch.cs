using System;
using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// высота ноты
    /// </summary>
    public class Pitch : IBaseObject
    {
        /// <summary>
        /// диез/бемоль +1 диез; -1 бемоль
        /// </summary>
        private int alter;

        /// <summary>
        /// ЗАГЛАВНАЯ (!) буква обозначающая "относительную" высоту ноты "A", "B" и т.д.
        /// </summary>
        private char step;

        /// <summary>
        /// номер октавы
        /// </summary>
        private int octave;

        /// <summary>
        /// уникальный номер ноты по миди стандарту
        /// </summary>
        private int midinumber;
        
        /// <summary>
        /// номер инструмента в партитуре
        /// </summary>
        private int instrument;

        public Pitch(int octave, char step, int alter)
        {
            this.alter = alter;
            this.step = step;
            this.octave = octave;
            this.midinumber = getmidinumberbyparam(this.octave, this.step, this.alter);
            this.instrument = 0;
        }
        
        public Pitch(int octave, char step, int alter, int instrument)
            : this(octave, step, alter)
        {
            this.instrument = instrument;
        }

        public int Midinumber
        {
            get { return midinumber; }
        }

        public char Step
        {
            get { return step; }
        }

        public int Octave
        {
            get { return octave; }
        }

        public int Alter
        {
            get { return alter; }
        }
        
        public int Instrument
        {
			get { return instrument; }
			set { this.instrument = value; }
        }

        #region privateMethods

        /// <summary>
        /// вычисление глобального номера ноты через параметры
        /// </summary>
        /// <param name="octave"></param>
        /// <param name="step"></param>
        /// <param name="alter"></param>
        /// <returns></returns>
        private int getmidinumberbyparam(int octave, char step, int alter)
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
            int numer = (12*(octave + 1)) + offset + alter;
            return numer;
        }

        private void getparamsbymidinumber(int midinumber)
        {
            // TODO: сделать вычисление параметров по глобальному номеру ноты, обратная операция получению номера из параметров
        }

        #endregion

        #region IBaseMethods

        ///<summary>
        /// Stub for GetBin
        ///</summary> 
        private Pitch()
        {
             
        }

        public IBaseObject Clone()
        {
            Pitch Temp = new Pitch(this.octave, this.step, this.alter);
            return Temp;
        }

        public bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if ((this.Midinumber == ((Pitch) obj).Midinumber) && (this.Instrument == ((Pitch) obj).Instrument))
            {
                return true;
            }
            return false;
        }

        #endregion



    }
}
