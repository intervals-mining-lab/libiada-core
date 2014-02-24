namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    ///  ласс реализующий объект псевдо-величина
    /// –еализованн на основе паттерна Singletone
    /// </summary>
    public class NullValue : IBaseObject
    {
        /// <summary>
        /// The single tone.
        /// </summary>
        private static readonly NullValue SingleTone = new NullValue();

        /// <summary>
        /// Prevents a default instance of the <see cref="NullValue"/> class from being created.
        /// </summary>
        private NullValue()
        {
        }

        /// <summary>
        /// ћетод позвол€ющий получить указатель на объект
        /// </summary>
        /// <returns>
        /// ”казатель на объект
        /// </returns>
        public static NullValue Instance()
        {
            return SingleTone;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return 0;
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
        public bool Equals(NullValue other)
        {
            return ReferenceEquals(this, other);
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject Clone()
        {
            return Instance();
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
            return ReferenceEquals(this, other);
        }

        /// <summary>
        /// Converts NullValue to "-" string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "-";
        }
    }
}