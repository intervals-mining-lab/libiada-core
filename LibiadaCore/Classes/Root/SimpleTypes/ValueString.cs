namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    ///  ласс представл€ющий элемент-строку
    /// </summary>
    public class ValueString : IBaseObject
    {
        public readonly string Value;

        protected ValueString()
        {
        }

        /// <summary>
        /// </summary>
        ///<param name="value"></param>
        public ValueString(string value)
        {
            this.Value = (string) value.Clone();
        }

        public IBaseObject Clone()
        {
            return new ValueString(Value);
        }

        /// <summary>
        /// </summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as ValueString);
        }

        /// <summary>
        /// </summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator string(ValueString @from)
        {
            return @from.Value;
        }

        /// <summary>
        /// </summary>
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

        public bool Equals(ValueString other)
        {
            if (other == null)
            {
                return false;
            }
            return string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}