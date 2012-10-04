using System;
using System.Collections;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    /// 
    ///</summary>
    [Serializable]
    public class BaseChain : IBaseObject
    {
        protected int[] building;
        protected Alphabet alphabet = new Alphabet();
        protected int length;

        ///<summary>
        ///</summary>
        ///<param name="length">������ ����������� �������</param>
        ///<exception cref="Exception"></exception>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
            alphabet.Add(NullValue.Instance());
        }

        ///<summary>
        ///</summary>
        public BaseChain()
        {
            alphabet.Add(NullValue.Instance());
        }

        public BaseChain(List<IBaseObject> chain)
        {
            ClearAndSetNewLength(chain.Count);
            alphabet.Add(NullValue.Instance());
            for (int i = 0; i < this.length; i++)
            {
                this.Add(chain[i], i);
            }
        }

        ///<summary>
        /// ������� ���� �� ������ ��������
        ///</summary>
        ///<param name="s"></param>
        ///<exception cref="NotImplementedException"></exception>
        public BaseChain(string s)
        {
            ClearAndSetNewLength(s.Length);
            alphabet.Add(NullValue.Instance());
            for (int i = 0; i < s.Length; i++)
            {
                Add((ValueChar)s[i], i);
            }
        }

        public BaseChain(String building, Alphabet alphabet)
        {
            string[] stringBuilding = building.Split('|');
            ClearAndSetNewLength(stringBuilding.Length);
            for (int i = 0; i < stringBuilding.Length; i++)
            {
                this[i] = alphabet[Convert.ToInt32(stringBuilding[i]) - 1];
            }
        }

        public BaseChain(int[] building, Alphabet alphabet)
        {
            ClearAndSetNewLength(building.Length);
            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        ///<summary>
        /// �����.
        ///</summary>
        public int[] Building
        {
            get
            {
                return (int[])building.Clone();
            }
        }

        ///<summary>
        /// ���������� ������� �� ������ ��������� ��� �������� ������������.
        /// ������� �������� ������ � ��� ����������� ��������� �� ��� �� �������� �� ���������
        /// ������������. ������� �� �������� ���������������.
        ///</summary>
        public Alphabet Alphabet
        {
            get
            {
                Alphabet Temp = (Alphabet)alphabet.Clone();
                Temp.Remove(0);
                return Temp;
            }
        }

        ///<summary>
        /// ������ ����.
        /// ������ ��� ������
        ///</summary>
        public int Length
        {
            get { return length; }
        }

        ///<summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">����� ��������</param>
        public virtual IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        ///<summary>
        /// ����� ����������� �������� ������� �� �������
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">������ ��������</param>
        ///<returns>���������� �������</returns>
        public virtual IBaseObject Get(int index)
        {
            return alphabet[building[index]];
        }

        ///<summary>
        /// ����� ����������� ���������� ������� �� �������
        ///</summary>
        ///<param name="item">��������������� ������� </param>
        ///<param name="index">����� ������� � ���� ���� ��������������� �������</param>
        public virtual void Add(IBaseObject item, int index)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            RemoveAt(index);
            int pos = alphabet.IndexOf(item);
            if (-1 == pos)
            {
                alphabet.Add(item);
                pos = alphabet.Power - 1;
            }

            building[index] = pos;
        }

        ///<summary>
        /// ���������� �������� �� ���������� �����
        ///</summary>
        ///<param name="index">����� �� �������� ����� ������� ��������, ������������� �����������</param>
        ///<returns>���������� ������ ���� I ���� ����� ����� �� ����� ����������, � ��������� ������ null</returns>
        ///<exception cref="Exception">� ������ ���� ����� ������� �� ������� ������������ ���������� ����������</exception>
        public IBaseObject GetItem(int index)
        {
            return this[index];
        }

        ///<summary>
        /// ����� ��������� ������� � ������� ���� 
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">����� �������</param>
        public void RemoveAt(int index)
        {
            building[index] = 0;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Length; i++)
            {
                result += this[i].ToString();
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        ///<exception cref="Exception"></exception>
        public void ClearAndSetNewLength(int length)
        {
            if (length <= 0)
            {
                throw new Exception("������ ���� <= 0");
            }
            this.length = length;
            building = new int[length];
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            BaseChain temp = new BaseChain(Length);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(BaseChain temp)
        {
            if (temp != null)
            {
                temp.building = (int[])building.Clone();
                temp.alphabet = (Alphabet)alphabet.Clone();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.Equals(NullValue.Instance()))
            {
                for (int i = 0; i < Length; i++)
                {
                    if (!Get(i).Equals(NullValue.Instance()))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            BaseChain chainObject = (BaseChain)obj;
            if (!alphabet.Equals((chainObject).alphabet))
            {
                return false;
            }
            for (int i = 0; (i < chainObject.length) && (i < length); i++)
            {
                if (!this[i].Equals(chainObject[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}