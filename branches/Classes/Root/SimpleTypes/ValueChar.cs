using System;

namespace ChainAnalises.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Класс элемент символ
    ///</summary>
    [Serializable]
    public class ValueChar : IBaseObject
    {
        public char value = default(char);

        ///<summary>
        ///</summary>
        public ValueChar()
        {}

        ///<summary>
        ///Конструктор
        ///</summary>
        ///<param name="value">Начальное значение элемента</param>
        public ValueChar(char value)
        {
            this.value = value;
        }

        ///<summary>
        ///</summary>
        ///<param name="data"></param>
        public ValueChar(ValueCharBin data)
        {
            value = data.value;
        }

        public IBaseObject Clone()
        {
            return new ValueChar(value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsChar(obj as ValueChar);
        }


        public IBin GetBin()
        {
            ValueCharBin temp = new ValueCharBin();
            temp.value = value;
            return temp;
        }

        private bool EqualsAsChar(ValueChar c)
        {
            if (c == null)
            {
                return false;
            }
            return c.value == value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        ///<summary>
        ///</summary>
        ///<param name="From"></param>
        ///<returns></returns>
        public static implicit operator char(ValueChar From)
        {
            return From.value;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueChar(char from)
        {
            return new ValueChar(from);
        }
    }

    ///<summary>
    ///</summary>
    public class ValueCharBin:IBin
    {
        public char value = default(char);

        public IBaseObject GetInstance()
        {
            return new ValueChar(this);
        }
    }
}