﻿using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class Key : IBaseObject // знаки при ключе в такте (диез, бемоль)
    {
        private int fifths = 0; // bemoles(-), diez(+) (ex. -6 : 6 bemoles);
        private string mode = ""; // major/minor

        public Key(int fifths)
        {
            this.fifths = fifths;
        }
        public Key(int fifths, string mode)
        {
            this.fifths = fifths;
            this.mode = mode;
        }
        public int Fifths
        {
            get { return fifths; }
        }
        public string Mode
        {
            get { return mode; }
        }

        #region IBaseMethods

        public IBaseObject Clone()
        {
            Key Temp = new Key(fifths,mode);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if ((Fifths==((Key)obj).Fifths)&&(Mode==((Key)obj).Mode))
            {
                return true;
            }
            return false;
        }

        #endregion


    }
}
