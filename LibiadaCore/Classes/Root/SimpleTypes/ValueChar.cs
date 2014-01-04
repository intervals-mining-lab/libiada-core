namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// Класс элемент символ
    ///</summary>
    public class ValueChar : IBaseObject
    {
        private readonly char value;

        ///<summary>
        ///Конструктор
        ///</summary>
        ///<param name="value">Начальное значение элемента</param>
        public ValueChar(char value)
        {
            this.value = value;
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
            return Equals(obj as ValueChar);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator char(ValueChar from)
        {
            return from.value;
        }

        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<returns></returns>
        public static implicit operator ValueChar(char from)
        {
            return new ValueChar(from);
        }

        public bool Equals(ValueChar other)
        {
            if (other == null)
            {
                return false;
            }
            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}