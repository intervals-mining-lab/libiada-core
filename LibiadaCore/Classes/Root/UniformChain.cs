using System.Collections.Generic;
using LibiadaCore.Classes.Misc;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///</summary>
    public class UniformChain : BaseChain, IBaseObject
    {
        protected List<int> intervals = new List<int>();

        ///<summary>
        /// ������ ���������� ������� ��� ��������� �������� � �������� �����.
        ///</summary>
        ///<param name="length">����� �������</param>
        ///<param name="message">������� �������</param>
        public UniformChain(int length, IBaseObject message) : base(length)
        {
            alphabet.Add(message);
        }

        ///<summary>
        ///</summary>
        public UniformChain()
        {
        }


        public IBaseObject Clone()
        {
            UniformChain temp = new UniformChain(Length, Message);
            FillClone(temp);
            return temp;
        }

        protected void FillClone(IBaseObject temp)
        {
            UniformChain TempunifromChain = temp as UniformChain;
            base.FillClone(TempunifromChain);
            if (TempunifromChain != null)
            {
                TempunifromChain.BuildIntervals();
            }
        }

        ///<summary>
        /// ������� �������
        ///</summary>
        public IBaseObject Message
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

        public void Add(IBaseObject item, int index)
        {
            if (Message.Equals(item))
            {
                base.Add(item, index);
                BuildIntervals();
            }
        }

        ///<summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������.
        /// � ������ ������ �� ������� ���� ���������� ����������.
        ///</summary>
        ///<param name="index">����� ��������</param>
        public override IBaseObject this[int index]
        {
            get { return building[index] == 1 ? Message.Clone() : NullValue.Instance(); }

            set { Add(value, index); }
        }

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