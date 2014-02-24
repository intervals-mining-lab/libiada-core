namespace LibiadaCore.Classes.Root.SimpleTypes
{
    using System.Globalization;

    /// <summary>
    /// Класс - вещественное значение
    /// </summary>
    public class ValueDouble : IBaseObject
    {
        /// <summary>
        /// The value.
        /// </summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueDouble"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public ValueDouble(double value)
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
        public static implicit operator double(ValueDouble from)
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
        public static implicit operator ValueDouble(double from)
        {
            return new ValueDouble(from);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new ValueDouble(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other as ValueDouble);
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
        public bool Equals(ValueDouble other)
        {
            if (other == null)
            {
                return false;
            }

            return value.Equals(other.value);
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