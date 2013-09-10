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
    public class Alphabet : IBaseObject, IEnumerable
    {
        protected List<IBaseObject> Vault = new List<IBaseObject>();

        ///<summary>
        /// �������� ���������� �������� ��������.
        /// ���-�� ��������� � ��������. 
        ///</summary>
        public int Power
        {
            get
            {
                 return Vault.Count;
            }
        }

        ///<summary>
        ///  ���������� ���������� �������� � �������.
        ///</summary>
        ///<param name="baseObject">����������� �������</param>
        ///<returns>���������� ��� ����� � ��������</returns>
        ///<exception cref="Exception">� ������ ���� ����� ������� ��� ���������� ��������</exception>
        ///<exception cref="NullReferenceException">� ������ ���� ����������� ������� null</exception>
        public virtual int Add(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                throw new NullReferenceException();
            }
            if (Vault.Contains((baseObject)))
            {
                throw new Exception();
            }
            Vault.Add(baseObject.Clone());
            return Vault.IndexOf(baseObject);
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
            get { return Vault[index].Clone(); }
            set
            {
                if (!Vault.Contains(value))
                {
                    Vault[index] = value.Clone();
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
            Vault.RemoveAt(index);
        }

        /// <summary>
        /// ������������ ��������
        /// </summary>
        /// <returns>����� ��������</returns>
        public IBaseObject Clone()
        {
            Alphabet result = new Alphabet {Vault = new List<IBaseObject>(Vault)};
            return result;
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
        /// <param name="aObj">������� ������� ���������� � ��������</param>
        /// <returns>true, ���� �������� �����, ����� false</returns>
        private bool EqualsAsAlphabet(Alphabet aObj)
        {
            if (aObj == null || Power != aObj.Power)
            {
                return false;
            }

            for (int i = 0; i < Power; i++)
            {
                if (!Vault.Contains(aObj.Vault[i]))
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
            return Vault.IndexOf(obj);
        }

        ///<summary>
        ///���������� �������������� ������� � ��������
        ///</summary>
        ///<param name="obj">������</param>
        ///<returns>True ���� ������� �������� ������ ������, ����� false</returns>
        public bool Contains(IBaseObject obj)
        {
            return Vault.Contains(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return Vault.GetEnumerator();
        }

        public IBaseObject[] ToArray()
        {
            return new List<IBaseObject>(Vault).ToArray();
        }

        public List<IBaseObject> ToList()
        {
            return new List<IBaseObject>(Vault);
        }

        public override int GetHashCode()
        {
            int temp = 0;
            foreach (IBaseObject o in Vault)
            {
                temp += 29*o.GetHashCode();
            }
            return temp;
        }
    }
}