namespace LibiadaCore.Core.SimpleTypes
{
    /// <summary>
    /// Null value class.
    /// Used to fill empty space in chains.
    /// Implements singleton pattern.
    /// </summary>
    public class NullValue : IBaseObject
    {
        /// <summary>
        /// The singletone value.
        /// </summary>
        private static readonly NullValue Value = new NullValue();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullValue"/> class from being created.
        /// </summary>
        private NullValue()
        {
        }

        /// <summary>
        /// Replacement for constructor.
        /// </summary>
        /// <returns>
        /// Reference on this object.
        /// </returns>
        public static NullValue Instance() => Value;

        /// <summary>
        /// Always returns -1 as hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => -1;

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="IBaseObject"/>.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(IBaseObject other) => ReferenceEquals(this, other);

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone() => Instance();

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object other) => ReferenceEquals(this, other);

        /// <summary>
        /// Converts NullValue to "-" string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString() => "-";
    }
}
