namespace BuildingsIterator.Statistics.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// ��������� �������� �������
    /// </summary>
    public class MaxCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// ���������� ������������ �������� �������
        /// </summary>
        /// <param name="values">�������</param>
        /// <returns>��������</returns>
        public double Calculate(List<double> values)
        {
            List<double>.Enumerator iterator = values.GetEnumerator();
            double max = double.MinValue;
            while (iterator.MoveNext())
            {
                if (iterator.Current > max)
                {
                    max = iterator.Current;
                }
            }

            return max;
        }
    }
}