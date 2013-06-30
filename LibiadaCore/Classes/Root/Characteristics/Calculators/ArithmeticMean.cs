namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ������� �������������� �������� ���� ����������.
    ///</summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// ��� ���������� ���� ������ �������������� 
        /// ����������� ��� ����� ���� ���� ���������� ������ �� ���������� ����������.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="linkUp"></param>
        /// <returns></returns>
        public double Calculate(CongenericChain chain, LinkUp linkUp)
        {
            IntervalsSum sumator = new IntervalsSum();
            double sum = sumator.Calculate(chain, linkUp);
            IntervalsCount counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain,linkUp);
            return sum/intervalsCount;
        }

        ///<summary>
        /// ����������� ��� ������� �������� �� �������� ��������� ���������� �����
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            IntervalsSum sumator = new IntervalsSum();
            double sum = sumator.Calculate(chain, linkUp);
            IntervalsCount counter = new IntervalsCount();
            double intervalsCount = counter.Calculate(chain, linkUp);
            return sum / intervalsCount;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}