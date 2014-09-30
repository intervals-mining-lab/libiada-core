namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// �������������������� ��������.
    /// </summary>
    public class GeometricMean : BinaryCalculator, ICalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly ICalculator depthCalculator = new Depth();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly ICalculator intervalsCount = new IntervalsCount();

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
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            // ������� � ��������������� ��������, ����� �������� ������������
            double depth = depthCalculator.Calculate(chain, link);
            double nj = intervalsCount.Calculate(chain, link);

            // ������������ �������� ���������������
            return Math.Pow(2, depth / nj);
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
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            // ������� � ��������������� ��������, ����� �������� ������������
            double depth = depthCalculator.Calculate(chain, link);
            double nj = intervalsCount.Calculate(chain, link);

            // ������������ �������� ���������������
            return Math.Pow(2, depth / nj);
        }

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
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            // ����������� ���������� �� ������ ���� ����� ����
            if (manager.FirstElement.Equals(manager.SecondElement))
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