namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    ///  ласс реализующий объект псевдо-величина
    /// –еализованн на основе паттерна Singletone
    /// </summary>
    public class NullValue : IBaseObject
    {
        protected bool Equals(NullValue other)
        {
            return ReferenceEquals(this, other);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        private static readonly NullValue SingleTone = new NullValue();

        /// <summary>
        /// ћетод позвол€ющий получить указатель на объект
        /// </summary>
        ///<returns>”казатель на объект</returns>
        public static NullValue Instance()
        {
            return SingleTone;
        }

        private NullValue()
        {
        }

        public IBaseObject Clone()
        {
            return Instance();
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }

        public override string ToString()
        {
            return "-";
        }
    }
}