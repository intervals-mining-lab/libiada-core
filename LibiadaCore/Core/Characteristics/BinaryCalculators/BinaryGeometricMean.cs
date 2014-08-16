namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;

    /// <summary>
    /// Geometric mean of one element relative to another.
    /// </summary>
    public class BinaryGeometricMean : BinaryCalculator
    {
        /// <summary>
        /// �������������������� �������� 
        /// ����� ����� ������������ �������-���������� ����
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="firstElement">
        /// ������ �������
        /// </param>
        /// <param name="secondElement">
        /// ������ �������
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// �������������������� ��������
        /// </returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            // ����������� ���������� �� ������ ���� ����� ����
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

             int[] intervals = chain.GetRelationIntervalsManager(firstElement, secondElement).GetIntervals();

            // ��������� ������� ������������ ���������� ����� ����������
            double result = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i] > 0)
                {
                    result += Math.Log(intervals[i], 2);
                }
            }

            return Math.Pow(2, intervals.Length == 0 ? 0 : result / intervals.Length);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.BinaryGeometricMean;
        }
    }
}