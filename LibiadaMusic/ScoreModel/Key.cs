namespace LibiadaMusic.ScoreModel
{
    using LibiadaCore.Core;

    /// <summary>
    /// знаки при ключе в такте (диез, бемоль)
    /// </summary>
    public class Key : IBaseObject 
    {
        /// <summary>
        /// bemoles(-), diez(+) (ex. -6 : 6 bemoles);
        /// </summary>
        private int fifths;
        /// <summary>
        /// major/minor
        /// </summary>
        private string mode;

        public Key(int fifths, string mode = "")
        {
            this.fifths = fifths;
            this.mode = mode;
        }

        public IBaseObject Clone()
        {
            var temp = new Key(fifths, mode);
            return temp;
        }

        public override bool Equals(object obj)
        {
            if ((fifths == ((Key) obj).fifths) && (mode == ((Key) obj).mode))
            {
                return true;
            }
            return false;
        }
    }
}
