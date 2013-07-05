namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    ///  ласс представл€ющий элемент - целочисленное значение
    ///</summary>
    public class ValueInt : IBaseObject
    {

        public int Value;

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        public ValueInt(int i)
        {
            Value = i;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            return new ValueInt(Value);
        }

        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (ValueInt))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Value.Equals(((ValueInt) obj).Value);
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator int(ValueInt from)
        {
            return from.Value;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueInt(int from)
        {
            return new ValueInt(from);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}