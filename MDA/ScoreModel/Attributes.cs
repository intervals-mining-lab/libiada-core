using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
   public class Attributes : IBaseObject // атрибуты такта
    {
        private Size size; // beats,beatbase,ticksperbeat
        private Key key; // fifths, mode

        public Attributes(Size size, Key key)
        {
            if (size != null) { this.size = (Size)size.Clone(); }
            if (key != null)  { this.key = (Key)key.Clone(); }
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

        #endregion

    }
}
