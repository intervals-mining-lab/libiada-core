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

            var count = new ElementsCount();

            // ����� ��������� ������� ����������
            var firstElementCount = (int)count.Calculate(chain.CongenericChain(firstElement), link);

            // ��������� ������� ������������ ���������� ����� ����������
            double intervals = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = chain.GetRelationIntervalsManager(firstElement, secondElement).GetBinaryInterval(i);
                if (binaryInterval > 0)
                {
                    intervals += Math.Log(binaryInterval, 2);
                }
            }

            // �������� ���������� ���
            int pairs = chain.GetRelationIntervalsManager(firstElement, secondElement).GetPairsCount();
            
            return Math.Pow(2, pairs == 0 ? 0 : intervals / pairs);
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