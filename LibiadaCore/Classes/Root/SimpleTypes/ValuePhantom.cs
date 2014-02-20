namespace LibiadaCore.Classes.Root.SimpleTypes
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// ��������� ���������, �������� � ���� ��������� ��������� �������� ����� �������.
    /// </summary>
    public class ValuePhantom : Alphabet, IBaseObject
    {
        /// <summary>
        /// ��������� ���������� ��������� ��������� � ��������� � ���������
        /// </summary>
        /// <param name="obj"> ��������� ��������� ������������ � ��������</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return EqualsAsPhantom(obj as ValuePhantom) || Equals(obj as NullValue) ||
                   EqualsAsElement(obj as IBaseObject);
        }

        private bool Equals(NullValue nullValue)
        {
            if (nullValue == null)
            {
                return false;
            }
            return Power == 0;
        }

        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < Power; i++)
            {
                if (IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool EqualsAsPhantom(ValuePhantom messagePhantom)
        {
            return base.Equals(messagePhantom);
        }

        /// <summary>
        /// ����� ��������� ��������� ��������� � �������, ����� �����������.
        /// ��� �������� ������� ������������� ���������, �� ������������ � ������ ��������� ���������,
        /// ����������� � �������. �� ����, ���������� ����������� ��������� ���������, ��� 
        /// ������������ �������� ��������� ������������ � ������ ���������.
        /// </summary>
        ///<param name="messagePhantom">������ ���������</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.Power; i++)
                {
                    if (!Contains(messagePhantom[i]))
                    {
                        Add(messagePhantom[i]);
                    }
                }
            }
        }

        /// <summary>
        /// ��������� ������ � ��������� ���������.
        /// </summary>
        /// <param name="baseObject">����� ������</param>
        /// <returns>������ ������ ������� ��� -1 ���� ��� �� ������� ��������</returns>
        public override int Add(IBaseObject baseObject)
        {
            if (baseObject != null && !baseObject.Equals(NullValue.Instance()))
            {
                return base.Add(baseObject);
            }
            return -1;
        }

        public override string ToString()
        {
            return Vault[0].ToString();
        }


        /// <summary>
        /// ����� ����������� ���������� ���������
        /// </summary>
        /// <returns>����� �������</returns>
        public new IBaseObject Clone()
        {
            var clone = new ValuePhantom {Vault = new List<IBaseObject>(Vault)};
            return clone;
        }
    }
}