using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ���������� ���������� � ����������� �� ��������.
    ///</summary>
    public class IntervalsCount : ICharacteristicCalculator
    {
        /// <summary>
        /// � ������, � ������ � ����������� = ������� �� ������� ���������
        /// � ����� ������ = ���������� ��������� + 1
        /// ��� �������� = ���������� ��������� - 1
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            List<int> intervals = chain.Intervals;
            switch (linkUp)
            {
                case LinkUp.Start:
                    return intervals.Count - 1;
                case LinkUp.End:
                    return intervals.Count - 1;
                case LinkUp.Both:
                    return intervals.Count;
                default:
                    throw new Exception("����������� ��������");
            }
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            int sum = 0;
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                sum += (int)Calculate(chain.UniformChain(i), linkUp);
            }
            return sum;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}