namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    /// Класс элемент символ
    /// </summary>
    public class ValueChar : IBaseObject
    {
        /// <summary>
        /// The value.
        /// </summary>
        private readonly char value;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">
        /// Начальное значение элемента
        /// </param>
        public ValueChar(char value)
        {
            this.value = value;
        }

        /// <summary>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static implicit operator char(ValueChar from)
        {
            return from.value;
        }

        /// <summary>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
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
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as ValueChar);
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return value.ToString();
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