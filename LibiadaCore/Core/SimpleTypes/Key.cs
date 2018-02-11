namespace LibiadaCore.Core.SimpleTypes
{
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
        /// The object.
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

        /// <summary>
        /// calculates hash code using
        /// <see cref="Fifths"/> and <see cref="Mode"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1754147455;
                hashCode = (hashCode * -1521134295) + Fifths.GetHashCode();
                hashCode = (hashCode * 1521134295) + Mode.GetHashCode();
                return hashCode;
            }

        }
    }
}
