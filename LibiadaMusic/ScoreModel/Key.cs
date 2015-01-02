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
        /// Major or minor.
        /// </summary>
        private string mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="fifths">
        /// The fifths.
        /// </param>
        /// <param name="mode">
        /// The mode.
        /// </param>
        public Key(int fifths, string mode = "")
        {
            this.fifths = fifths;
            this.mode = mode;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var temp = new Key(fifths, mode);
            return temp;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if ((fifths == ((Key)obj).fifths) && (mode == ((Key)obj).mode))
            {
                return true;
            }

            return false;
        }
    }
}
