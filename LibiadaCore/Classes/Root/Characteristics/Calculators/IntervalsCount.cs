namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ���������� ���������� � ����������� �� ��������.
    /// </summary>
    public class IntervalsCount : ICalculator
    {
        /// <summary>
        /// � ������, � ������ � ����������� = ������� �� ������� ���������
        /// � ����� ������ = ���������� ��������� + 1
        /// ��� �������� = ���������� ��������� - 1
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
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
                    return intervals.Count - 2;
                default:
                    throw new ArgumentException("Unknown link.");
            }
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int sum = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += (int)Calculate(chain.CongenericChain(i), link);
            }

            return sum;
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.IntervalsCount;
        }
    }
}