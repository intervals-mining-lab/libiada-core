using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
   public class Attributes : IBaseObject // атрибуты такта
    {
        private Size size; // beats,beatbase,ticksperbeat
        private Key key; // fifths, mode

        public Attributes(Size size, Key key)
        {
            this.size = (Size) size.Clone();
            this.key = (Key) key.Clone();
        }
        public Size Size
        {
            get
            {
                return size;
            }
        }
        public Key Key
        {
            get
            {
                return key;
            }
        }

        #region IBaseMethods

        private Attributes()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            Attributes Temp = new Attributes(this.size, this.key);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.Key.Equals(((Attributes)obj).Key) && this.Size.Equals(((Attributes)obj).Size))
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            AttributesBin Temp = new AttributesBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class AttributesBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new Attributes();
            }
        }

        #endregion

    }
}
