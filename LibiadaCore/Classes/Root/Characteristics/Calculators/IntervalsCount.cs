using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ���������� ���������� � ����������� �� ��������.
    ///</summary>
    public class IntervalsCount : ICalculator
    {
        /// <summary>
        /// � ������, � ������ � ����������� = ������� �� ������� ���������
        /// � ����� ������ = ���������� ��������� + 1
        /// ��� �������� = ���������� ��������� - 1
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            List<int> intervals = chain.Intervals;
            switch (link)
            {
                case Link.Start:
                    return intervals.Count - 1;
                case Link.End:
                    return intervals.Count - 1;
                case Link.Both:
                    return intervals.Count;
                case Link.Cycle:
                    return intervals.Count - 1;
                case Link.None:
                    return intervals.Count-2;
                default:
                    throw new Exception("����������� ��������");
            }
        }

        public double Calculate(Chain chain, Link link)
        {
            int sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += (int)Calculate(chain.CongenericChain(i), link);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}