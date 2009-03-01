using System;
using System.Collections;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.TheoryOfSet
{
    ///<summary>
    /// ������ ����� ��������� ������� ���������
    /// ������� ��� ������ �� ���������� ���������
    /// ������� �������� ������� �������������� � ����������� � ��������� "��������"
    ///</summary>
    [Serializable]
    public class Alphabet : IBaseObject, IEnumerable
    {
        protected ArrayList vault = new ArrayList();

        ///<summary>
        ///</summary>
        public Alphabet()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public Alphabet(AlphabetBin Bin)
        {
            foreach (IBin item in Bin.Items)
            {
                vault.Add(item.GetInstance());
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBin GetBin()
        {
            AlphabetBin Temp = new AlphabetBin();
            FillBin(Temp);
            return Temp;
        }

        protected virtual void FillBin(AlphabetBin temp)
        {
            foreach (IBaseObject baseObject in vault)
            {
                temp.Items.Add(baseObject.GetBin());
            }

        }

        ///<summary>
        /// �������� ���������� �������� ��������.
        /// ���-�� ��������� � ��������. 
        ///</summary>
        public int power
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
            if (vault.Contains((o)))
            {
                throw new Exception();
            }
            if (o == null)
            {
                throw new NullReferenceException();
            }
            return vault.Add(o.Clone());
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
            get { return ((IBaseObject) (vault[index])).Clone(); }
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
            AlNew.vault = (ArrayList) vault.Clone();
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
            if (a_obj == null || power != a_obj.power)
            {
                return false;
            }

            for (int i = 0; i < power; i++)
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

    ///<summary>
    ///</summary>
    public class AlphabetBin:IBin
    {
        public ArrayList Items = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new Alphabet(this);
        }
    }
}