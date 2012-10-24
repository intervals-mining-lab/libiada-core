using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// знаки при ключе в такте (диез, бемоль)
    /// </summary>
    public class Key : IBaseObject 
    {
        /// <summary>
        /// bemoles(-), diez(+) (ex. -6 : 6 bemoles)
        /// </summary>
        private int fifths = 0;
        /// <summary>
        /// major/minor
        /// </summary>
        private string mode = "";

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

        ///<summary>
        /// Stub for GetBin
        ///</summary>
        private Key()
        {
              
        }

        public IBaseObject Clone()
        {
            Key Temp = new Key(this.fifths,this.mode);
            return Temp;
        }

        public bool Equals(object obj)
        {
            if ((this.Fifths==((Key)obj).Fifths)&&(this.Mode==((Key)obj).Mode))
            {
                return true;
            }
            return false;
        }

        ///<summary>
        /// Stub
        ///</summary>
        public IBin GetBin()
        {
            KeyBin Temp = new KeyBin();
            
            return Temp;
        }

        public class KeyBin : IBin
        {
            ///<summary>
            /// Stub
            ///</summary>
            public IBaseObject GetInstance()
            {
                return new Key();
            }
        }

        #endregion


    }
}
