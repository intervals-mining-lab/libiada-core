using System;

namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    ///  ласс представл€ющий элемент-строку
    ///</summary>
    [Serializable]
    public class ValueString : IBaseObject
    {
        public string value = "";

        protected  ValueString()
        {
            
        }

        ///<summary>
        ///</summary>
        ///<param name="str"></param>
        public ValueString(string str)
        {
            value = (string) str.Clone();
        }

        public IBaseObject Clone()
        {
            return new ValueString(value);
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
            return value.Equals(((ValueString) obj).value);
        }

        ///<summary>
        ///</summary>
        ///<param name="From"></param>
        ///<returns></returns>
        public static implicit operator string(ValueString From)
        {
            return From.value;
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
            return value;
        }
    }
}