namespace LibiadaCore.Classes.Root.SimpleTypes
{
    /// <summary>
    /// ����� ����������� ������ ������-��������
    /// ����������� �� ������ �������� Singletone
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
        /// ����� ����������� �������� ��������� �� ������
        /// </summary>
        ///<returns>��������� �� ������</returns>
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