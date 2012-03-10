using System;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// ����� ����������� ������ ������-��������
    /// ����������� �� ������ �������� Singletone
    ///</summary>
    [Serializable]
    public class PsevdoValue : IBaseObject
    {
        private static readonly PsevdoValue SingleTone = new PsevdoValue();

        ///<summary>
        /// ����� ����������� �������� ��������� �� ������
        ///</summary>
        ///<returns>��������� �� ������</returns>
        public static PsevdoValue Instance()
        {
            return SingleTone;
        }

        protected PsevdoValue()
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

        public IBin GetBin()
        {
            PsevdoValueBin Temp = new PsevdoValueBin();
            return Temp;
        }

        public override string ToString()
        {
            return "-";
        }
    }

    ///<summary>
    ///</summary>
    public class PsevdoValueBin:IBin
    {
        public IBaseObject GetInstance()
        {
            return PsevdoValue.Instance();
        }
    }
}