namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    ///  ласс представл€ющий элемент-строку
    /// </summary>
    public class ValueString : IBaseObject
    {
        /// <summary>
        /// The value.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueString"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public ValueString(string value)
        {
            this.Value = (string)value.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueString"/> class.
        /// </summary>
        protected ValueString()
        {
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator string(ValueString @from)
        {
            return @from.Value;
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator ValueString(string from)
        {
            return new ValueString(from);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return new ValueString(this.Value);
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

            return this.Equals(other as ValueString);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Value;
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
        public bool Equals(ValueString other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(this.Value, other.Value);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Value != null ? this.Value.GetHashCode() : 0;
        }
    }
}