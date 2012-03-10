using System;
using System.Collections;

namespace LibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// ����� ����������� ������� ������
    ///</summary>
    [Serializable]
    public class ReadRule
    {
        protected Place pPattern = null;
        protected ArrayList vault = new ArrayList();

        ///<summary>
        ///����� ��������� �������� �� �������� ����� � �������.
        ///</summary>
        ///<param name="ToRule">����������� �����</param>
        ///<returns>��������� true � ������ �������� ������� ����� � �������, ����� false</returns>
        public bool Contains(Place ToRule)
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
        /// �������� ������������ ���-�� ���� � �������� ��������� ������
        ///</summary>
        public int Count
        {
            get { return vault.Count; }
        }

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="Place">������� ����� ��� �������� ������������ ������ �������</param>
        ///<exception cref="NullReferenceException">� ������ ���� ������� ����� null �������� ����������.</exception>
        public ReadRule(Place Place)
        {
            if (Place == null)
            {
                throw new NullReferenceException();
            }
            pPattern = Place;
        }

        ///<summary>
        /// ����� ����������� ��������� "������" ����� ������� � ������������ ������ 
        ///</summary>
        ///<param name="Place">������������ �����</param>
        ///<exception cref="Exception">� ������ ���� ������������ ����� ��� ������� � ������, �� �������� �������� ��� �������� ��� �������� null ���������� ����������</exception>
        public void Add(Place Place)
        {
            if (!pPattern.CompatibleTo(Place) || !pPattern.Neighbour(Place) || Contains(Place))
            {
                throw new Exception();
            }
            vault.Add(Place.Clone());
        }

        ///<summary>
        /// �������� ����������� �������� �������(�����) � ������� ������� ����� �������� ���������� "������"
        ///</summary>
        ///<param name="index">����� ��������</param>
        public Place this[int index]
        {
            get { return (Place) ((Place) vault[index]).Clone(); }
            set
            {
                if (!pPattern.CompatibleTo(value) || Contains(value) || !pPattern.Neighbour(value))
                {
                    throw new Exception();
                }
                vault[index] = value.Clone();
            }
        }

        ///<summary>
        /// ����� ������� ����� �� �������
        ///</summary>
        ///<exception cref="NotImplementedException">� ������ ���� ����� ����� ������ ���������� ��������� ��� ������ 0 ����������� ����������</exception>
        public void Remove(int index)
        {
            vault.RemoveAt(index);
        }

        ///<summary>
        /// ����� ��������� ��������� ����������������
        ///</summary>
        ///<param name="B">������� � ������� ����������</param>
        ///<returns>True ���� ����� ��������� ����� false</returns>
        public bool EqualAsRule(ReadRule B)
        {
            if (vault.Count != B.Count)
            {
                return false;
            }
            for (int i = 0; i < Count; i++)
            {
                if (!vault.Contains((B[i])))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        /// ����� ������������ ���������
        ///</summary>
        ///<returns>����������� ����� �������</returns>
        public ReadRule Clone()
        {
            ReadRule temp = new ReadRule(pPattern);
            temp.vault = (ArrayList) vault.Clone();
            return temp;
        }

        ///<summary>
        /// ����� ������������ ���������� ���� ������
        /// ������� ������ ������������ ������ �����.
        ///</summary>
        ///<param name="rr2">������ �������</param>
        ///<returns>������ �� ������ ����</returns>
        ///<exception cref="NotImplementedException">���������� ���������� ���� ������� ����������� ������ ������ ��� ������ �������� null</exception>
        public ReadRule Add(ReadRule rr2)
        {
            if (rr2 == null)
            {
                throw new NullReferenceException();
            }
            if (!pPattern.EqualsAsPlace(rr2.pPattern))
            {
                throw new Exception();
            }

            for (int i = 0; i < rr2.Count; i++)
            {
                if (!Contains(rr2[i]))
                {
                    Add(rr2[i]);
                }
            }
            return this;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return EqualAsRule(obj as ReadRule);
        }
    }
}