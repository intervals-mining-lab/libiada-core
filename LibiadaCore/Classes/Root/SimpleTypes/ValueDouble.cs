namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Класс - вещественное значение
    ///</summary>
    public class ValueDouble:IBaseObject
    {
         ///<summary>
        ///</summary>
        ///<param name="i"></param>
        public ValueDouble(double i)
        {
            Value = i;
        }

        public double Value;

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            return new ValueDouble(Value);
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
            if (obj.GetType() != typeof(ValueDouble))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Value.Equals(((ValueDouble)obj).Value);
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator double(ValueDouble from)
        {
            return from.Value;
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
            return Value.ToString();
        }
    }
}