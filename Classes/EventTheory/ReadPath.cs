using System;
using System.Collections;

namespace ChainAnalises.Classes.EventTheory
{
    ///<summary>
    ///����� ����������� ������ �������
    ///</summary>
    [Serializable]
    public class ReadPath : ICloneable
    {
        protected ArrayList vault = new ArrayList();

        protected bool Contains(Place ToRule)
        {
            for (int i = 0; i < vault.Count; i++)
            {
                if (((Place) vault[i]).EqualsAsPlace(ToRule))
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="First">������ ������� ����</param>
        public ReadPath(Place First)
        {
            if (First == null)
            {
                throw new NullReferenceException("������ ������� ���� null");
            }
            vault.Add(First.Clone());
        }

        ///<summary>
        /// ����� ��������� ����� � ���� ������.
        ///</summary>
        ///<param name="ToRule">����� ����������� � ���� ������. ������ ���� ����������� � ������������� �������� ����������� ������ ����</param>
        ///<exception cref="Exception">� ������ ���� ����� �� ���������� � �������������� ��� ��� ������� � ������ ���� ���������� ����������</exception>
        public void Add(Place ToRule)
        {
            if (!ToRule.CompatibleTo((Place) vault[0]))
            {
                throw new Exception("����� ����������� ������������� �������������");
            }

            if (vault.Contains(ToRule) /*|| Contains(ToRule)*/)
            {
                throw new Exception("���� �� ������ ������������");
            }

            if (!((Place) vault[vault.Count - 1]).Neighbour(ToRule))
            {
                throw new Exception("���� ������ ���� �����������");
            }

            vault.Add(ToRule.Clone());
        }

        ///<summary>
        /// �������� ����������� �������� ������ � ������ �������� ����
        ///</summary>
        ///<param name="index">����� ��������</param>
        ///<returns>������ �����</returns>
        ///<exception cref="Exception">� ������ ���� ����� �������� ������� �� ������� ������� ������� ���������� ����������</exception>
        public Place this[int index]
        {
            get { return (Place) ((Place) vault[index]).Clone(); }
        }

        ///<summary>
        ///�������� ����������� �������� ������� ������������
        ///</summary>
        public Place Pattern
        {
            get { return (Place) ((Place) vault[0]).Clone(); }
        }

        ///<summary>
        /// ������� ��������� ������� ����
        ///</summary>
        public void Remove()
        {
            vault.RemoveAt(vault.Count - 1);
        }

        ///<summary>
        /// ����� ����
        /// ������ >= 1
        ///</summary>
        public int Length
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// ����� ������������� ���� ������
        ///</summary>
        ///<param name="b">���� ������ � ������� ����������</param>
        ///<returns>true ���� ���� ������� �� ���������� ���������</returns>
        ///<exception cref="NullReferenceException">� ������ ��������� � null ��� ����� ������������� �������������� ������������ ���������� ����������</exception>
        public bool EqualAsReadPath(ReadPath b)
        {
            if (b == null)
            {
                throw  new NullReferenceException("���� ������ null");
            }

            if (!Pattern.CompatibleTo(b.Pattern))
            {
                throw new Exception("���� ������������ ������������� �������������");
            }

            for (int i = 0; i < vault.Count; i++)
            {
                if (!((Place) vault[i]).EqualsAsPlace(b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///Creates a new object that is a copy of the current instance.
        ///</summary>
        ///
        ///<returns>
        ///A new object that is a copy of this instance.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public object Clone()
        {
            ReadPath Temp = new ReadPath((Place) ((Place) vault[0]).Clone());
            Temp.vault = (ArrayList) vault.Clone();
            return Temp;
        }
    }
}