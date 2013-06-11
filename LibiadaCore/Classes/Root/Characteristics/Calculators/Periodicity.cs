namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// �������������.
    /// ����� ����� ������ ��� ���������� ����.
    ///</summary>
    public class Periodicity : ICharacteristicCalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return geometricMean.Calculate(chain, linkUp)/arithmeticMean.Calculate(chain, linkUp);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            return geometricMean.Calculate(chain, linkUp)/arithmeticMean.Calculate(chain, linkUp);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}