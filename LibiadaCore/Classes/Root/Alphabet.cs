namespace LibiadaCore.Classes.Root
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// ������ ����� ��������� ������� ���������
    /// ������� ��� ������ �� ���������� ���������
    /// ������� �������� ������� �������������� � ����������� � ��������� "��������"
    /// </summary>
    public class Alphabet : IBaseObject, IEnumerable
    {
        /// <summary>
        /// The elements within alphabet.
        /// </summary>
        protected readonly List<IBaseObject> Elements = new List<IBaseObject>();

        /// <summary>
        /// �������� ���������� �������� ��������.
        /// ���-�� ��������� � ��������. 
        /// </summary>
        public int Cardinality
        {
            get
            {
                 return Elements.Count;
            }
        }

        /// <summary>
        /// ��������� �������� ������ � �������� �������� �� �������.
        /// ��������� ���������� � ��������� �������.
        /// ��� ������ ���������� �������� �� ���������� ������� ������� � ��������. 
        /// � ������ �������� ������ ������ �������� ������� ����������� � �������, 
        /// � ��������� ����� �� ����������, ��� ��� ����� �� ���������� �� ���� ������ �����. 
        /// ���� ������ ������ 0  ��� >= �������� �������� ���������� ����������.
        /// </summary>
        /// <param name="index">
        /// ������ �������� � ��������
        /// </param>
        /// <returns>
        /// The <see cref="IBaseObject"/>.
        /// </returns>
        public IBaseObject this[int index]
        {
            get
            {
                return Elements[index].Clone();
            }

            set
            {
                if (!Elements.Contains(value))
                {
                    Elements[index] = value.Clone();
                }
            }
        }

        /// <summary>
        ///  ���������� ���������� �������� � �������.
        /// </summary>
        /// <param name="baseObject">
        /// ����������� �������
        /// </param>
        /// <returns>
        /// ���������� ��� ����� � ��������
        /// </returns>
        /// <exception cref="Exception">
        /// � ������ ���� ����� ������� ��� ���������� ��������
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// � ������ ���� ����������� ������� null
        /// </exception>
        public virtual int Add(IBaseObject baseObject)
        {
            if (baseObject == null)
            {
                throw new NullReferenceException();
            }

            if (Elements.Contains(baseObject))
            {
                throw new Exception();
            }

            Elements.Add(baseObject.Clone());
            return Elements.IndexOf(baseObject);
        }

        /// <summary>
        /// �������� �������� �� �������� �� ���������� �������.
        /// ���� ������ ������ 0  ��� >= �������� �������� ���������� ����������
        /// </summary>
        /// <param name="index">������ ���������� �������� � ��������</param>
        public virtual void Remove(int index)
        {
            Elements.RemoveAt(index);
        }

        /// <summary>
        /// ������������ ��������
        /// </summary>
        /// <returns>����� ��������</returns>
        public IBaseObject Clone()
        {
            var clone = new Alphabet();
            for (int i = 0; i < Elements.Count; i++)
            {
                clone.Add(Elements[i]);
            }

            return clone;
        }

        /// <summary>
        /// ��������� �������� ��������� � ��������� � ���������
        /// ��� �������� ��������� �������������� ��� ������� ������������� ��������� � ��������������� �� ��������
        /// ���� � �������� ������� ������� ���������� ��������� ������ ��������� �� �������� ������������ 
        /// ������� ��������� �� ��������������
        /// </summary>
        /// <param name="other"> 
        /// ������� ������������ � ��������
        /// </param>
        /// <returns>
        /// true ���� �������� �����������, ����� false 
        /// </returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(other, this))
            {
                return true;
            }

            return EqualsAsAlphabet(other as Alphabet);
        }

        /// <summary>
        /// ���������� ������ ������� � ��������.
        /// � ������, ���� ������� ������� ��� � �������� ���������� -1.
        /// </summary>
        /// <param name="obj">
        /// ������ ������� ���� � ��������
        /// </param>
        /// <returns>
        /// ������ ������� � ��������
        /// </returns>
        public int IndexOf(IBaseObject obj)
        {
            return Elements.IndexOf(obj);
        }

        /// <summary>
        /// ���������� �������������� ������� � ��������
        /// </summary>
        /// <param name="element">
        /// ������
        /// </param>
        /// <returns>
        /// True ���� ������� �������� ������ ������, ����� false
        /// </returns>
        public bool Contains(IBaseObject element)
        {
            return Elements.Contains(element);
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        /// <summary>
        /// The to array.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IBaseObject[]"/>.
        /// </returns>
        public IBaseObject[] ToArray()
        {
            var result = new List<IBaseObject>();

            foreach (var vault in Elements)
            {
                result.Add(vault.Clone());
            }

            return result.ToArray();
        }

        /// <summary>
        /// The to list.
        /// </summary>
        /// <returns>
        /// The <see cref="List{IBaseObject}"/>.
        /// </returns>
        public List<IBaseObject> ToList()
        {
            var result = new List<IBaseObject>();

            foreach (var vault in Elements)
            {
                result.Add(vault.Clone());
            }

            return result;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int temp = 0;
            foreach (IBaseObject o in Elements)
            {
                temp += 29 * o.GetHashCode();
            }

            return temp;
        }

        /// <summary>
        /// ������������ ��������� ���������
        /// </summary>
        /// <param name="other">������� ������� ���������� � ��������</param>
        /// <returns>
        /// true, ���� �������� �����, ����� false
        /// </returns>
        private bool EqualsAsAlphabet(Alphabet other)
        {
            if (other == null || Cardinality != other.Cardinality)
            {
                return false;
            }

            for (int i = 0; i < Cardinality; i++)
            {
                if (!Elements.Contains(other.Elements[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}