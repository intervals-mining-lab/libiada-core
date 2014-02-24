namespace LibiadaCore.Classes.Root.SimpleTypes
{
    using System.Globalization;

    /// <summary>
    ///  ласс представл€ющий элемент - целочисленное значение
    /// </summary>
    public class ValueInt : IBaseObject
    {
        /// <summary>
        /// The value.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueInt"/> class.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        public ValueInt(int i)
        {
            value = i;
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator int(ValueInt from)
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
        public static implicit operator ValueInt(int from)
        {
            return new ValueInt(from);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new ValueInt(value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="other">
        /// The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.
        /// </param>
        /// <filterpriority>
        /// 2
        /// </filterpriority>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals((ValueInt)other);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
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
        public bool Equals(ValueInt other)
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