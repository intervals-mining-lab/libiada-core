namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Периодичность.
    /// Имеет смысл только для однородной цепи.
    ///</summary>
    public class Periodicity : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();
        private readonly ArithmeticMean arithmeticMean = new ArithmeticMean();

        public double Calculate(CongenericChain chain, LinkUp linkUp)
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