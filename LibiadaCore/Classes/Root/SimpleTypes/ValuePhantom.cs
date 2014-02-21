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

        /// <summary>
        /// ����� ��������� ��������� ��������� � �������, ����� �����������.
        /// ��� �������� ������� ������������� ���������, �� ������������ � ������ ��������� ���������,
        /// ����������� � �������. �� ����, ���������� ����������� ��������� ���������, ��� 
        /// ������������ �������� ��������� ������������ � ������ ���������.
        /// </summary>
        /// <param name="messagePhantom">������ ���������</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.Cardinality; i++)
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

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
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
            var clone = new ValuePhantom { Vault = new List<IBaseObject>(Vault) };
            return clone;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="nullValue">
        /// The null value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Equals(NullValue nullValue)
        {
            if (nullValue == null)
            {
                return false;
            }
            return this.Cardinality == 0;
        }

        /// <summary>
        /// The equals as element.
        /// </summary>
        /// <param name="baseObject">
        /// The base object.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < this.Cardinality; i++)
            {
                if (IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The equals as phantom.
        /// </summary>
        /// <param name="messagePhantom">
        /// The message phantom.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool EqualsAsPhantom(ValuePhantom messagePhantom)
        {
            return base.Equals(messagePhantom);
        }
    }
}