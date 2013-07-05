namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Класс элемент символ
    ///</summary>
    public class ValueChar : IBaseObject
    {
        public char Value = default(char);

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
            this.Value = value;
        }

        public IBaseObject Clone()
        {
            return new ValueChar(Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsChar(obj as ValueChar);
        }

        private bool EqualsAsChar(ValueChar c)
        {
            if (c == null)
            {
                return false;
            }
            return c.Value == Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator char(ValueChar from)
        {
            return from.Value;
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
}