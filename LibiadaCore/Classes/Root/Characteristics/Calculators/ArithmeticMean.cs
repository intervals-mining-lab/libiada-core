namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// ������� �������������� �������� ���� ����������.
    ///</summary>
    public class ArithmeticMean : ICharacteristicCalculator
    {
        /// <summary>
        /// ��� ���������� ���� ������ �������������� 
        /// ����������� ��� 1/����������� ��� �������� � ��������.
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="Link"></param>
        /// <returns></returns>
        public double Calculate(UniformChain chain, LinkUp Link)
        {
            Probability probability = new Probability();
            return 1 / probability.Calculate(chain, Link);
        }

        ///<summary>
        /// ����������� ��� ������� �������� �� �������� ��������� ���������� �����
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            double sum = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                sum += Calculate(pChain.UniformChain(i), Link);
            }
            return sum/pChain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}