using System.Collections.Generic;

namespace MarkovCompare
{
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
            List<double>.Enumerator iter = values.GetEnumerator();
            double max = double.MinValue;
            while (iter.MoveNext())
            {
                if (iter.Current > max)
                    max = iter.Current;
            }
            return max;
        }
    }
}