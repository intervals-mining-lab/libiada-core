using System;

namespace ChainAnalises.Classes.Root.SimpleTypes
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class ValueString : IBaseObject
    {
        public string value = "";

        protected  ValueString()
        {
            
        }

        public ValueString(ValueStringBin bin)
        {
            value = (string)bin.value.Clone();
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
            return value == ((ValueString) obj).value;
        }

        public IBin GetBin()
        {
            ValueStringBin temp = new ValueStringBin();
            temp.value = value;
            return temp;
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

    public class ValueStringBin:IBin
    {
        public string value;

        public IBaseObject GetInstance()
        {
            return new ValueString(this);
        }
    }
}