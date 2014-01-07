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

        public double Calculate(CongenericChain chain, Link link)
        {
            return geometricMean.Calculate(chain, link)/arithmeticMean.Calculate(chain, link);
        }

        public double Calculate(Chain chain, Link link)
        {
            return geometricMean.Calculate(chain, link)/arithmeticMean.Calculate(chain, link);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}