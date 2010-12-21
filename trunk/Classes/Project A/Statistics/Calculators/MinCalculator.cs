using System.Collections.Generic;

namespace MarkovCompare
{
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
            List<double>.Enumerator iter = values.GetEnumerator();
            double min = double.MaxValue;
            while (iter.MoveNext())
            {
                if (iter.Current < min)
                    min = iter.Current;
            }
            return min;
        }
    }
}