namespace LibiadaCore.Core.SimpleTypes
{
    using System.Globalization;

    /// <summary>
    /// Class that stores single char value.
    /// </summary>
    public class ValueChar : IBaseObject
    {
        /// <summary>
        /// The value.
        /// </summary>
        private readonly char value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChar"/> class.
        /// </summary>
        /// <param name="value">
        /// The <see cref="char"/> value of element.
        /// </param>
        public ValueChar(char value)
        {
            this.value = value;
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator char(ValueChar from)
        {
            return from.value;
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator ValueChar(char from)
        {
            return new ValueChar(from);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new ValueChar(value);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other as ValueChar);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(ValueChar other)
        {
            if (other == null)
            {
                return false;
            }

            return value == other.value;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}