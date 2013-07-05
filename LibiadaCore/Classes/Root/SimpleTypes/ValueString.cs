namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    ///  ласс представл€ющий элемент-строку
    ///</summary>
    public class ValueString : IBaseObject
    {
        public string Value = "";

        protected  ValueString()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="str"></param>
        public ValueString(string str)
        {
            Value = (string) str.Clone();
        }

        public IBaseObject Clone()
        {
            return new ValueString(Value);
        }

        ///<summary>
        ///</summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (ValueString))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Value.Equals(((ValueString) obj).Value);
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator string(ValueString @from)
        {
            return @from.Value;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueString(string from)
        {
            return new ValueString(from);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}