namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// �������������.
    /// ����� ����� ������ ��� ���������� ����.
    ///</summary>
    public class Periodicity : ICharacteristicCalculator
    {
        private GeometricMean geometricMean = new GeometricMean();
        private ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return geometricMean.Calculate(pChain, Link)/arithmeticMean.Calculate(pChain, Link);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return geometricMean.Calculate(pChain, Link)/arithmeticMean.Calculate(pChain, Link);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}