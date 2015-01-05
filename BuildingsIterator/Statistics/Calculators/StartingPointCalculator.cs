namespace BuildingsIterator.Statistics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ��������� ��������� i-� ������ ������.
    /// </summary>
    public class StartingPointCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// ������� �������.
        /// </summary>
        private readonly int s = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartingPointCalculator" /> class.
        /// </summary>
        /// <param name="i">
        /// ������� �������.
        /// </param>
        public StartingPointCalculator(int i)
        {
            s = i;
        }

        /// <summary>
        /// ����� ���������� ���������� ������� �������.
        /// </summary>
        /// <param name="sample">
        /// �������.
        /// </param>
        /// <returns>
        /// ��������� ������.
        /// </returns>
        public double Calculate(List<double> sample)
        {
            double sum = 0;
            for (int i = 0; i < sample.Count; i++)
            {
                sum += Math.Pow(sample[i], s);
            }

            sum /= sample.Count;
            return sum;
        }
    }
}
