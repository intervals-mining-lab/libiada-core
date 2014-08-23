namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Geometric mean of one element relative to another.
    /// </summary>
    public class BinaryGeometricMean : BinaryCalculator
    {
        /// <summary>
        /// �������������������� �������� 
        /// ����� ����� ������������ �������-���������� ����
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// �������������������� ��������
        /// </returns>
        public override double Calculate(RelationIntervalsManager manager, Link link)
        {
            // ����������� ���������� �� ������ ���� ����� ����
            if (manager.firstElement.Equals(manager.secondElement))
            {
                return 0;
            }

             int[] intervals = manager.GetIntervals();

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
    }
}