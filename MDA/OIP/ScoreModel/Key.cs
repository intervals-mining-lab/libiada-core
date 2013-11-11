using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
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

        private Key()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Key Temp = new Key(this.fifths,this.mode);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if ((this.Fifths==((Key)obj).Fifths)&&(this.Mode==((Key)obj).Mode))
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            KeyBin Temp = new KeyBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class KeyBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Key();
            }
        }

        #endregion


    }
}
