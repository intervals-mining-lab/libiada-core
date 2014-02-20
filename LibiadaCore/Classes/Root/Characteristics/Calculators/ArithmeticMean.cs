namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// ������� �������������� �������� ���� ����������.
    /// </summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// ��� ���������� ���� ������ �������������� 
        /// ����������� ��� ����� ���� ���� ���������� ������ �� ���������� ����������.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var adder = new IntervalsSum();
            double sum = adder.Calculate(chain, link);
            var counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain,link);
            return sum/intervalsCount;
        }

        /// <summary>
        /// ����������� ��� ������� �������� �� �������� ��������� ���������� �����
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            var adder = new IntervalsSum();
            double sum = adder.Calculate(chain, link);
            var counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain, link);
            return sum / intervalsCount;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}