namespace LibiadaCore.Classes.Root
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc;
    using LibiadaCore.Classes.Root.Characteristics.Calculators;
    using LibiadaCore.Classes.Root.SimpleTypes;
    using LibiadaCore.Classes.TheoryOfSet;

    /// <summary>
    /// ����� ����
    /// </summary>
    public class Chain : BaseChain, IBaseObject
    {
        protected CongenericChain[] CongenericChains = new CongenericChain[0];
        protected Chain[] DissimilarChains;

        /// <summary>
        /// ����������� 
        /// ��� �������� ������ ������� �������� ��� ���� ���������� � 0 ��������.
        /// </summary>
        ///<param name="length">������ ����</param>
        public Chain(int length) : base(length)
        {
        }

        /// <summary>
        /// </summary>
        public Chain()
        {
        }

        /// <summary>
        /// �����������, ������� ���� �� ������ ��������.
        /// ������ ������ ���������� ���������.
        /// </summary>
        ///<param name="s">������</param>
        public Chain(string s)
            : base(s)
        {
        }

        /// <summary>
        /// ������ ������� � �������� ������ � ���������.
        /// �������� ������������ �� ������������!
        /// </summary>
        /// <param name="building">�����</param>
        /// <param name="alphabet">�������</param>
        public Chain(int[] building, Alphabet alphabet)
            : base(building, alphabet)
        {
            CreateCongenericChains();
        }

        /// <summary>
        /// C����� ������� �� ������ ���������.
        /// </summary>
        /// <param name="chain">��������� ���������</param>
        public Chain(List<IBaseObject> chain):base(chain)
        {
            CreateCongenericChains();
        }

        /// <summary>
        /// �������� �� ������ ������������ ���� ��� ���������� ����
        /// � ��������� �� ��������� ������ <see cref="CongenericChains"/>.
        /// </summary>
        private void CreateCongenericChains()
        {
            CongenericChains = new CongenericChain[alphabet.Power - 1];
            for (int i = 0; i < alphabet.Power - 1; i++)
            {
                CongenericChains[i] = new CongenericChain(building.Length, alphabet[i + 1]);
            }
            for (int j = 0; j < building.Length; j++)
            {
                CongenericChains[building[j] - 1][j] = alphabet[building[j]];
            }
        }

        public override void ClearAndSetNewLength(int length)
        {
            base.ClearAndSetNewLength(length);
            CongenericChains = new CongenericChain[0];
        }

        public new IBaseObject Clone()
        {
            var clone = new Chain(Length);
            FillClone(clone);
            return clone;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clone"></param>
        protected void FillClone(IBaseObject clone)
        {
            var tempChain = clone as Chain;
            base.FillClone(tempChain);
            if (tempChain != null)
            {
                tempChain.CongenericChains = (CongenericChain[]) CongenericChains.Clone();
            }
        }

        /// <summary>
        /// ���������� ����� ���������� ������� � ��������� ���������.
        /// ���� ������ �������� ���, �� ����������� null.
        /// </summary>
        ///<param name="baseObject">������� ���������� �������</param>
        ///<returns></returns>
        public CongenericChain CongenericChain(IBaseObject baseObject)
        {
            CongenericChain result = null;
            int pos = Alphabet.IndexOf(baseObject);
            if (pos != -1)
            {
                result = (CongenericChain) (CongenericChains[pos]).Clone();
            }
            return result;
        }

        /// <summary>
        /// ���������� ����� ���������� ������� 
        /// � ��������� �������� � �������� ������ ����.
        /// </summary>
        ///<param name="i">������ �������� ���������� ������� � �������� ������ ����</param>
        ///<returns></returns>
        public CongenericChain CongenericChain(int i)
        {
            return (CongenericChain)CongenericChains[i].Clone();
        }

        /// <summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������
        /// � ������ ������ �� ������� ���� ���������� ����������
        /// </summary>
        ///<param name="index">����� ��������</param>
        public override IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        public override void Add(IBaseObject item, int index)
        {
            base.Add(item, index);

            if (CongenericChains.Length != (alphabet.Power - 1))
            {
                var temp = new CongenericChain[alphabet.Power - 1];
                for (int i = 0; i < CongenericChains.Length; i++)
                {
                    temp[i] = CongenericChains[i];
                }
                CongenericChains = temp;
                CongenericChains[CongenericChains.Length - 1] = new CongenericChain(Length, item);
            }

            foreach (CongenericChain chain in CongenericChains)
            {
                chain.Add(item, index);
            }
        }

        public void FillDissimilarChains()
        {
            if(DissimilarChains.Length > 0)
                return;
            var counters = new List<int>();
            for (int j = 0; j < Alphabet.Power; j++)
            {
                counters.Add(0);
            }

            for (int i = 0; i < building.Length; i++)
            {
                int element = ++counters[building[i]];
                if(DissimilarChains.Length < element) 
                {
                    var temp = new Chain[element];
                    for (int j = 0; j < DissimilarChains.Length; j++)
                    {
                        temp[j] = DissimilarChains[j];
                    }
                    DissimilarChains = temp;
                    DissimilarChains[DissimilarChains.Length - 1] = new Chain();
                }
                DissimilarChains[element].Add(new ValueInt(building[i]), i);
            }
        }

        /// <summary>
        /// ���������� i-�� �������� 
        /// ����� ���������� ���������� 
        /// � �������-��������� ����
        /// </summary>
        /// <param name="j">������ �������� ����</param>
        /// <param name="L">������ ������� ����</param>
        /// <param name="entry">����� ��������� ������� � 1</param>
        /// <returns>����� ���������</returns>
        public int GetBinaryInterval(IBaseObject j, IBaseObject L, int entry)
        {
            int jEntry = Get(j, entry);
            if (jEntry == -1)
            {
                return -1;
            }
            for (int i = jEntry + 1; i < Length; i++)
            {
                if (j.Equals(this[i]))
                {
                    return - 1;
                }
                if (L.Equals(this[i]))
                {
                    return i - jEntry;
                }
            }
            return -1;
        }

        /// <summary>
        /// ���������� ������� ���������� �� ����� ��������� ���������� ��������.
        /// </summary>
        /// <param name="element">�������</param>
        /// <param name="entry">����� ��������� �������� � ������ ����</param>
        /// <returns></returns>
        public int Get(IBaseObject element, int entry)
        {
            int entranceCount = 0;
            for (int i = 0; i < building.Length; i++)
            {
                if (this[i].Equals(element))
                {
                    entranceCount++;
                    if (entranceCount == entry)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// ���������� ������� ������� ��������� ���������� �������� 
        /// ����� ��������� �������.
        /// </summary>
        /// <param name="element">�������</param>
        /// <param name="from">��������� ������� ��� �������</param>
        /// <returns>����� ������� ��� -1, ���� ������� ����� ��������� ������� �� �����������</returns>
        public int GetAfter(IBaseObject element, int from)
        {
            for (int i = from; i < Length; i++)
            {
                if (this[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetPairsCount(IBaseObject j, IBaseObject L)
        {
            int jElementCount = (int)new Count().Calculate(CongenericChain(j), Link.Start);
            int pairs = 0;
            for (int i = 1; i <= jElementCount; i++)
            {
                int binaryInterval = GetBinaryInterval(j, L, i);
                if (binaryInterval > 0)
                {
                    pairs++;
                }
            }
            return pairs;
        }

        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            ICalculator calc = new Count();
            CongenericChain tempCongenericChain = CongenericChain(element);
            if ((int)calc.Calculate(tempCongenericChain, Link.End) == 1)
            {
                var temp = CongenericChains;
                CongenericChains = new CongenericChain[temp.Length - 1];
                int j = 0;
                foreach (CongenericChain congenericChain in temp)
                {
                    if (!congenericChain.Element.Equals(element))
                    {
                        CongenericChains[j] = congenericChain;
                        j++;
                    }
                }
                alphabet.Remove(building[index]);
                for (int k = 0; k < building.Length; k++)
                {
                    if (building[index] < building[k])
                    {
                        building[k] = building[k] - 1;
                    }
                }
            }
            foreach (CongenericChain congenericChain in CongenericChains)
            {
                congenericChain.DeleteAt(index);
            }
            building = ArrayManipulator.DeleteAt(building, index);
            return element;
        }
    }
}