namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    ///  ласс представл€ющий элемент - целочисленное значение
    /// </summary>
    public class ValueInt : IBaseObject
    {
        private readonly int value;
        

        /// <summary>
        /// </summary>
        ///<param name="i"></param>
        public ValueInt(int i)
        {
            value = i;
        }

        /// <summary>
        /// </summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            return new ValueInt(value);
        }

        /// <summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        /// </summary>
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals((ValueInt) obj);
        }

        /// <summary>
        /// </summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator int(ValueInt from)
        {
            return from.value;
        }

        /// <summary>
        /// </summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueInt(int from)
        {
            return new ValueInt(from);
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
            return value.ToString();
        }

        public bool Equals(ValueInt other)
        {
            if (other == null)
            {
                return false;
            }
            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}