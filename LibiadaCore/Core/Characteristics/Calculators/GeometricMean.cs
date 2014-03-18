namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// �������������������� ��������.
    /// </summary>
    public class GeometricMean : ICalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly ICalculator depthCalc = new Depth();

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
            double depth = this.depthCalc.Calculate(chain, link);
            double nj = this.intervalsCount.Calculate(chain, link);

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
            double depth = this.depthCalc.Calculate(chain, link);
            double nj = this.intervalsCount.Calculate(chain, link);

            // ������������ �������� ���������������
            return Math.Pow(2, depth / nj);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.GeometricMean;
        }
    }
}