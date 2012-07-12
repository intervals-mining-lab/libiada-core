using LibiadaCore.Classes.Root.Characteristics.AuxiliaryInterfaces;

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
            double n = chain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
            double n_j = chain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.n);
            double result = n/n_j;
            return result;
        }

        ///<summary>
        /// ����������� ��� ������� �������� �� �������� ��������� ���������� �����
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            IChainDataForCalculaton Data = pChain;
            double sum = 0;
            for (int i = 0; i < pChain.Alphabet.Power; i++)
            {
                sum += Data.IUniformChain(i).GetCharacteristic(Link, CharacteristicsFactory.deltaA);
            }
            return sum/pChain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.ArithmeticMean;
        }
    }
}