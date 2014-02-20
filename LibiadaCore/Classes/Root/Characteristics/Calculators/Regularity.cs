namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// –егул€рность.
    /// </summary>
    public class Regularity : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();
        private readonly DescriptiveInformation descriptiveInformation = new DescriptiveInformation();

        public double Calculate(CongenericChain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / descriptiveInformation.Calculate(chain, link);
        }

        /// <summary>
        /// </summary>
        ///<param name="chain"></param>
        ///<param name="link"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, Link link)
        {
            return geometricMean.Calculate(chain, link) / descriptiveInformation.Calculate(chain, link);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Regularity;
        }
    }
}