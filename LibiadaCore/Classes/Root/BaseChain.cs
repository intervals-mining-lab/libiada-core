namespace LibiadaCore.Classes.Root
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LibiadaCore.Classes.Root.SimpleTypes;
    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// 
    /// </summary>
    public class BaseChain : IBaseObject
    {
        protected int[] building;
        protected Alphabet alphabet = new Alphabet();

        /// <summary>
        /// ������ ������ ������� �������� �����.
        /// </summary>
        ///<param name="length">������ ����������� �������</param>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
        }

        /// <summary>
        /// </summary>
        public BaseChain()
        {
        }

        /// <summary>
        /// C����� ������� �� ������ ���������.
        /// </summary>
        /// <param name="chain">��������� ���������</param>
        public BaseChain(List<IBaseObject> chain) : this(chain.Count)
        {
            for (int i = 0; i < Length; i++)
            {
                Add(chain[i], i);
            }
        }

        /// <summary>
        /// ������� ���� �� ������ ��������.
        /// ������ ������ ���������� ���������.
        /// </summary>
        ///<param name="s">������</param>
        public BaseChain(string s) : this(s.Length)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Add((ValueChar)s[i], i);
            }
        }

        /// <summary>
        /// ������ ������� � �������� ������ � ���������.
        /// �������� ������������ �� ������������!
        /// </summary>
        /// <param name="building">�����</param>
        /// <param name="alphabet">�������</param>
        public BaseChain(int[] building, Alphabet alphabet) : this(building.Length)
        {
            this.building = (int[])building.Clone();
            this.alphabet = (Alphabet)alphabet.Clone();
        }

        /// <summary>
        /// ���������� ����� �����.
        /// ��� ����������� ��������� �� ��� �� �������� �� ��������� �������.
        /// </summary>
        public int[] Building
        {
            get { return (int[]) building.Clone(); }
        }

        /// <summary>
        /// ���������� �������.
        /// ������� �������� ������ � ��� ����������� ��������� �� ��� �� �������� �� ��������� �������.
        /// ������� �� �������� ��������������� (NullValue).
        /// </summary>
        public Alphabet Alphabet
        {
            get
            {
                var result = (Alphabet)alphabet.Clone();
                //������� NullValue
                result.Remove(0);
                return result;
            }
        }

        /// <summary>
        /// ������ ����.
        /// ������ ��� ������.
        /// </summary>
        public int Length
        {
            get { return building.Length; }
        }

        /// <summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        /// </summary>
        ///<param name="index">����� ��������</param>
        public virtual IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        /// <summary>
        /// ����� ����������� �������� ������� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        /// </summary>
        ///<param name="index">������ ��������</param>
        ///<returns>���������� �������</returns>
        public virtual IBaseObject Get(int index)
        {
            return alphabet[building[index]];
        }

        /// <summary>
        /// ����� ����������� ���������� ������� �� �������.
        /// </summary>
        ///<param name="item">��������������� ������� </param>
        ///<param name="index">����� ������� � ���� ���� ��������������� �������</param>
        public virtual void Add(IBaseObject item, int index)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            RemoveAt(index);
            int position = alphabet.IndexOf(item);
            if (position == -1)
            {
                alphabet.Add(item);
                position = alphabet.Cardinality - 1;
            }

            building[index] = position;
        }

        /// <summary>
        /// ����� ��������� ������� � ������� ���� 
        /// � ������ ������ �� ������� ���� ���������� ����������
        /// </summary>
        ///<param name="index">����� �������</param>
        public void RemoveAt(int index)
        {
            building[index] = 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                builder.Append(this[i]);
            }

            return builder.ToString();
        }

        /// <summary>
        /// �� ���� ���������� �������, ������ ����� � �������,
        /// ������������ ����� �����.
        /// � ������� ����������� <see cref="NullValue"/>.
        /// </summary>
        ///<param name="length">����� ����� �������</param>
        ///<exception cref="Exception">������������� ���� ����� &lt; 0</exception>
        public virtual void ClearAndSetNewLength(int length)
        {
            if (length < 0)
            {
                throw new Exception("������ ���� < 0");
            }

            building = new int[length];
            alphabet = new Alphabet {NullValue.Instance()};
        }

        /// <summary>
        /// </summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            var clone = new BaseChain(Length);
            FillClone(clone);
            return clone;
        }

        protected void FillClone(BaseChain clone)
        {
            if (clone != null)
            {
                clone.building = (int[])building.Clone();
                clone.alphabet = (Alphabet)alphabet.Clone();
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
            if (obj as BaseChain == null)
            {
                return false;
            }
            var chainObject = (BaseChain)obj;
            if (!alphabet.Equals((chainObject).alphabet))
            {
                return false;
            }
            for (int i = 0; (i < chainObject.Length) && (i < Length); i++)
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