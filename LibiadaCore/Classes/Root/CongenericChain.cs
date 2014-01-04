using System.Collections.Generic;
using LibiadaCore.Classes.Misc;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    public class CongenericChain : BaseChain, IBaseObject
    {
        protected List<int> intervals = new List<int>();
        protected int MaxFilledPosition;

        ///<summary>
        /// ������ ���������� ������� ��� ��������� �������� � �������� �����.
        ///</summary>
        ///<param name="length">����� �������</param>
        ///<param name="element">������� �������</param>
        public CongenericChain(int length, IBaseObject element) : base(length)
        {
            alphabet.Add(element);
        }

        ///<summary>
        ///</summary>
        public CongenericChain()
        {
        }


        public new IBaseObject Clone()
        {
            var temp = new CongenericChain(Length, Element);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(IBaseObject temp)
        {
            var tempCongenericChain = temp as CongenericChain;
            base.FillClone(tempCongenericChain);
            if (tempCongenericChain != null)
            {
                tempCongenericChain.BuildIntervals();
            }
        }

        ///<summary>
        /// ������� �������
        ///</summary>
        public IBaseObject Element
        {
            get { return alphabet[1]; }
        }

        /// <summary>
        /// ���������� ����� ������� ����������, 
        /// ������� �������� � ������ � � �����
        /// </summary>
        public List<int> Intervals
        {
            get
            {
                return new List<int>(intervals);
            }
        }

        /// <summary>
        /// ������� ������� ���������� ����� �� ��������� ������� 
        /// ��������� �������� � ���������� �������.
        /// </summary>
        /// <param name="current">������� ��� ������</param>
        /// <returns>������� ��������� ����� �������� � ���������� ����, ��� -1 ���� ����� ��� ���������</returns>
        protected int Left(int current)
        {
            for (int i = current - 1; i >= 0; i--)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// ������� ������� ���������� ������ �� ��������� ������� 
        /// ��������� �������� � ���������� �������.
        /// </summary>
        /// <param name="current">������� ��� ������</param>
        /// <returns>������� ��������� ������ �������� � ���������� ����, ��� -����� ������� ���� ����� ��� ���������</returns>
        protected int Right(int current)
        {
            for (int i = current + 1; i < Length; i++)
            {
                if (building[i] == 1)
                {
                    return i;
                }
            }
            return Length;
        }

        public override void Add(IBaseObject item, int index)
        {
            if (Element.Equals(item))
            {
                base.Add(item, index);
                BuildIntervals(index);
            }
        }

        ///<summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        ///</summary>
        ///<param name="index">����� ��������</param>
        public override IBaseObject this[int index]
        {
            get { return building[index] == 1 ? Element.Clone() : NullValue.Instance(); }

            set { Add(value, index); }
        }

        /// <summary>
        /// ������������� ������ ��������� ��������
        /// ���� ��� �������� ������� �� ��������� �� ��� ���������
        /// ����� �������� ����� ������ ����������� ����������.
        /// </summary>
        /// <param name="addedPosition">������� ������������ ��������</param>
        private void BuildIntervals(int addedPosition)
        {
            if ((intervals.Count > 0) && (addedPosition > MaxFilledPosition))
            {
                intervals[intervals.Count - 1] = addedPosition - Left(addedPosition);
                intervals.Add(Length - addedPosition);
                MaxFilledPosition = addedPosition;
            }
            else
            {
                BuildIntervals();
            }
            
        }

        /// <summary>
        /// ������������� ������ ����������.
        /// </summary>
        protected void BuildIntervals()
        {
            intervals = new List<int>();
            int next = -1;
            do
            {
                int current = next;
                next = Right(current);

                intervals.Add(next - current);
            } while (next != Length);
        }

        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            building = ArrayManipulator.DeleteAt(building, index);
            BuildIntervals();
            return element;
        }
    }
}