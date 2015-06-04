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
        public readonly int Fifths;

        /// <summary>
        /// Major or minor.
        /// </summary>
        public readonly string Mode;

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
            Fifths = fifths;
            Mode = mode;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            var temp = new Key(Fifths, Mode);
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
            if ((Fifths == ((Key)obj).Fifths) && (Mode == ((Key)obj).Mode))
            {
                return true;
            }

            return false;
        }
    }
}
