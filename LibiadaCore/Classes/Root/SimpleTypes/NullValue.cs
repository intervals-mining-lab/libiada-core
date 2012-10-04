using System;

namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// ����� ����������� ������ ������-��������
    /// ����������� �� ������ �������� Singletone
    ///</summary>
    [Serializable]
    public class NullValue : IBaseObject
    {
        private static readonly NullValue SingleTone = new NullValue();

        ///<summary>
        /// ����� ����������� �������� ��������� �� ������
        ///</summary>
        ///<returns>��������� �� ������</returns>
        public static NullValue Instance()
        {
            return SingleTone;
        }

        protected NullValue()
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