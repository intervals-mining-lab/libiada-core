using LibiadaCore.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    /// <summary>
    /// атрибуты такта
    /// </summary>
    public class Attributes : IBaseObject
    {
        /// <summary>
        /// beats,beatbase,ticksperbeat
        /// </summary>
        private Size size;

        /// <summary>
        /// fifths, mode
        /// </summary>
        private Key key;

        public Attributes(Size size, Key key)
        {
            if (size != null)
            {
                this.size = (Size) size.Clone();
            }
            if (key != null)
            {
                this.key = (Key) key.Clone();
            }
        }

        public Size Size
        {
            get { return size; }
        }

        public Key Key
        {
            get { return key; }
        }

        #region IBaseMethods

        private Attributes()
        {
            
        }

        public IBaseObject Clone()
        {
            Attributes Temp = new Attributes(this.size, this.key);
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (this.Key.Equals(((Attributes) obj).Key) && this.Size.Equals(((Attributes) obj).Size))
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
