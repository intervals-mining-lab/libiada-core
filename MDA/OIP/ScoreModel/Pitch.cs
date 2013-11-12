using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class Pitch : IBaseObject // высота ноты
    {
        private int alter; // диез/бемоль +1 диез; -1 бемоль
        private char step; // ЗАГЛАВНАЯ (!) буква обозначающая "относительную" высоту ноты "A", "B" и т.д.
        private int octave; // номер октавы 
        private int midinumber; // уникальный номер ноты по миди стандарту
        private int instrument; //@инструмент
        private int p;
        private int p_2;
        private int p_3;

        public Pitch(int octave, char step, int alter)
        {
            this.alter = alter;
            this.step = step;
            this.octave = octave;
            this.midinumber = getmidinumberbyparam(this.octave,this.step,this.alter);
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
        private int getmidinumberbyparam(int octave, char step , int alter) // вычисление глобального номера ноты через параметры
        {
            int offset; // сдвиг от начала октавы, в зависимости от буквы ноты
            switch (step)
        {
            case 'C': offset = 0;
            break;
            case 'D': offset = 2;
            break;
            case 'E': offset = 4;
            break;
            case 'F': offset = 5;
            break;
            case 'G': offset = 7;
            break;
            case 'A': offset = 9;
            break;
            case 'B': offset = 11;
            break;
    default:
        throw new Exception("Error Pitch contains non-recognized STEP letters!");
        }
            int numer = (12 * (octave + 1)) + offset + alter;
            return numer;
        }
        private void getparamsbymidinumber(int midinumber) 
        {
            // TODO: сделать вычисление параметров по глобальному номеру ноты, обратная операция получению номера из параметров
        }
        #endregion

        #region IBaseMethods

        private Pitch()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public Pitch(int p, int p_2, int p_3)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
        }

        public IBaseObject Clone()
        {
            Pitch Temp = new Pitch(this.octave,this.step,this.alter);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (this.Midinumber == ((Pitch)obj).Midinumber)
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            PitchBin Temp = new PitchBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class PitchBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Pitch();
            }
        }

        #endregion



    }
}
