namespace BuildingsIterator.Statistics.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// ��������� ������ �������
    /// </summary>
    public class MinCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// ��������� ����������� �������� �������
        /// </summary>
        /// <param name="values">�������</param>
        /// <returns>����������� ��������</returns>
        public double Calculate(List<double> values)
        {
            List<double>.Enumerator iterator = values.GetEnumerator();
            double min = double.MaxValue;
            while (iterator.MoveNext())
            {
                if (iterator.Current < min)
                {
                    min = iterator.Current;
                }
            }

            return min;
        }
    }
}