namespace BuildingsIterator.Statistics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ��������� ��������� i-� ������ ������
    /// </summary>
    public class StartingPointCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// ������� �������
        /// </summary>
        private readonly int s = 1;

        /// <summary>
        /// ����������� ������������ ������������ ��������� ������ �������
        /// </summary>
        /// <param name="i">������� �������</param>
        public StartingPointCalculator(int i)
        {
            s = i;
        }

        /// <summary>
        /// ����� ���������� ���������� ������� �������
        /// </summary>
        /// <param name="values">�������</param>
        /// <returns>��������� ������</returns>
        public double Calculate(List<double> values)
        {
            double sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += Math.Pow(values[i], s);
            }

            sum /= values.Count;
            return sum;
        }
    }
}