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
            value = i;
        }

        ///<summary>
        ///</summary>
        ///<param name="i"></param>
        public ValueDouble(ValueDoubleBin i)
        {
            value = i.Value;
        }


        public double value = 0;

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
        ///
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///
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
            return value.Equals(((ValueDouble)obj).value);
        }

        public IBin GetBin()
        {
            return new ValueDoubleBin(value);
        }

        ///<summary>
        ///</summary>
        ///<param name="From"></param>
        ///<returns></returns>
        public static implicit operator double(ValueDouble From)
        {
            return From.value;
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
    }

    ///<summary>
    ///</summary>
    public class ValueDoubleBin : IBin
    {
        public double Value = 0;
        ///<summary>
        ///</summary>
        ///<param name="value"></param>
        public ValueDoubleBin(double value)
        {
            Value = value;
        }

        public IBaseObject GetInstance()
        {
            return new ValueDouble(this);
        }
    }
}