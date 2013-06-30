using System;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class BinaryGeometricMean : BinaryCalculator
    {
        /// <summary>
        /// �������������������� �������� 
        /// ����� ����� ������������ �������-���������� ����
        /// </summary>
        /// <param name="chain">�������</param>
        /// <param name="firstElement">������ �������</param>
        /// <param name="secondElement">������ �������</param>
        /// <param name="linkUp">��������</param>
        /// <returns>�������������������� ��������</returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            //����������� ���������� �� ������ ���� ����� ����
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            Count count = new Count();
            //����� ��������� ������� ����������
            int firstElementCount = (int)count.Calculate(chain.UniformChain(firstElement), linkUp);
            //��������� ������� ������������ ���������� ����� ����������
            double intervals = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = chain.GetBinaryInterval(firstElement, secondElement, i);
                if (binaryInterval > 0)
                {
                    intervals += Math.Log(binaryInterval, 2);
                }
            }
            //�������� ���������� ���
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            
            return Math.Pow(2, pairs == 0 ? 0 : intervals / pairs);
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.BinaryGeometricMean;
        }
    }
}