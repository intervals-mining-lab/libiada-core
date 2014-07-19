namespace LibiadaMusic.ScoreModel
{
    using LibiadaCore.Core;

    /// <summary>
    /// атрибуты такта
    /// </summary>
    public class Attributes : IBaseObject
    {
        /// <summary>
        /// beats,beatbase,ticksperbeat
        /// </summary>
        public Size Size { get; private set; }
        /// <summary>
        /// fifths, mode
        /// </summary>
        public Key Key { get; private set; }

        public Attributes(Size size, Key key)
        {
            if (size != null)
            {
                Size = (Size) size.Clone();
            }
            if (key != null)
            {
                Key = (Key) key.Clone();
            }
        }



        public IBaseObject Clone()
        { 
            return new Attributes(Size, Key);
        }

        public override bool Equals(object obj)
        {
            if (Key.Equals(((Attributes) obj).Key) && Size.Equals(((Attributes) obj).Size))
            {
                return true;
            }
            return false;
        }
    }
}