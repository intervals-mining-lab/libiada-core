using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.TheoryOfSet
{
    ///<summary>
    /// ������ ����� ��������� ������� ���������
    /// ������� ��� ������ �� ���������� ���������
    /// ������� �������� ������� �������������� � ����������� � ��������� "��������"
    ///</summary>
    [Serializable]
    public class Alphabet : IBaseObject, IEnumerable
    {
        protected List<IBaseObject> vault = new List<IBaseObject>();

        ///<summary>
        ///</summary>
        public Alphabet()
        {
        }

        ///<summary>
        /// �������� ���������� �������� ��������.
        /// ���-�� ��������� � ��������. 
        ///</summary>
        public int Power
        {
            get
            {
                 return vault.Count;
            }
        }

        ///<summary>
        ///  ���������� ���������� �������� � �������.
        ///</summary>
        ///<param name="o">����������� �������</param>
        ///<returns>���������� ��� ����� � ��������</returns>
        ///<exception cref="Exception">� ������ ���� ����� ������� ��� ���������� ��������</exception>
        ///<exception cref="NullReferenceException">� ������ ���� ����������� ������� null</exception>
        public virtual int Add(IBaseObject o)
        {
            if (o == null)
            {
                throw new NullReferenceException();
            }
            if (vault.Contains((o)))
            {
                throw new Exception();
            }
            vault.Add(o.Clone());
            return vault.IndexOf(o);
        }

        ///<summary>
        /// ��������� �������� ������ � �������� �������� �� �������.
        /// ��������� ���������� � ��������� �������.
        /// ��� ������ ���������� �������� �� ���������� ������� ������� � ��������. 
        /// � ������ �������� ������ ������ �������� ������� ����������� � �������, 
        /// � ��������� ����� �� ����������, ��� ��� ����� �� ���������� �� ���� ������ �����. 
        /// ���� ������ ������ 0  ��� >= �������� �������� ���������� ����������.
        ///</summary>
        ///<param name="index">������ �������� � ��������</param>
        public IBaseObject this[int index]
        {
            get { return vault[index].Clone(); }
            set
            {
                if (!vault.Contains(value))
                {
                    vault[index] = value.Clone();
                }
            }
        }

        /// <summary>
        /// �������� �������� �� �������� �� ���������� �������.
        /// ���� ������ ������ 0  ��� >= �������� �������� ���������� ����������
        /// </summary>
        /// <param name="index">������ ���������� �������� � ��������</param>
        public virtual void Remove(int index)
        {
            vault.RemoveAt(index);
        }

        /// <summary>
        /// ������������ ��������
        /// </summary>
        /// <returns>����� ��������</returns>
        public IBaseObject Clone()
        {
            Alphabet AlNew = new Alphabet();
            AlNew.vault = new List<IBaseObject>((IBaseObject[])vault.ToArray().Clone());
            return AlNew;
        }

        /// <summary>
        /// ��������� �������� ��������� � ��������� � ���������
        /// ��� �������� ��������� �������������� ��� ������� ������������� ��������� � ��������������� �� ��������
        /// ���� � �������� ������� ������� ���������� ��������� ������ ��������� �� �������� ������������ 
        /// ������� ��������� �� ��������������
        /// </summary>
        /// <param name="obj"> ������� ������������ � ��������</param>
        /// <returns>true ���� �������� �����������, ����� false </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            return EqualsAsAlphabet(obj as Alphabet);
        }

        /// <summary>
        /// ������������ ��������� ���������
        /// </summary>
        /// <param name="a_obj">������� ������� ���������� � ��������</param>
        /// <returns>true, ���� �������� �����, ����� false</returns>
        private bool EqualsAsAlphabet(Alphabet a_obj)
        {
            if (a_obj == null || Power != a_obj.Power)
            {
                return false;
            }

            for (int i = 0; i < Power; i++)
            {
                if (!vault.Contains(a_obj.vault[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        /// ���������� ������ ������� � ��������.
        /// � ������, ���� ������� ������� ��� � �������� ���������� -1.
        ///</summary>
        ///<param name="obj">������ ������� ���� � ��������</param>
        ///<returns>������ ������� � ��������</returns>
        public int IndexOf(IBaseObject obj)
        {
            return vault.IndexOf(obj);
        }

        ///<summary>
        ///���������� �������������� ������� � ��������
        ///</summary>
        ///<param name="obj">������</param>
        ///<returns>True ���� ������� �������� ������ ������, ����� false</returns>
        public bool Contains(IBaseObject obj)
        {
            return vault.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return vault.GetEnumerator();
        }

        public override int GetHashCode()
        {
            int temp = 0;
            foreach (object o in vault)
            {
                temp += 29*o.GetHashCode();
            }
            return temp;
        }
    }
}