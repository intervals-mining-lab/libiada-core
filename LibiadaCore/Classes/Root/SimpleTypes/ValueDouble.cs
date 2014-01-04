namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Класс - вещественное значение
    ///</summary>
    public class ValueDouble:IBaseObject
    {
        private readonly double value;

         ///<summary>
        ///</summary>
        ///<param name="value"></param>
        public ValueDouble(double value)
        {
            this.value = value;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            return new ValueDouble(value);
        }

        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as ValueDouble);
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator double(ValueDouble from)
        {
            return from.value;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueDouble(double from)
        {
            return new ValueDouble(from);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public bool Equals(ValueDouble other)
        {
            if (other == null)
            {
                return false;
            }
            return value.Equals(other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}