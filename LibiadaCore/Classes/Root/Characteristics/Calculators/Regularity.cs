namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// –егул€рность.
    ///</summary>
    public class Regularity : ICalculator
    {
        private readonly GeometricMean geometricMean = new GeometricMean();
        private readonly DescriptiveInformation descriptiveInformation = new DescriptiveInformation();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return geometricMean.Calculate(chain, linkUp) / descriptiveInformation.Calculate(chain, linkUp);
        }

        ///<summary>
        ///</summary>
        ///<param name="chain"></param>
        ///<param name="linkUp"></param>
        ///<returns></returns>
        public double Calculate(Chain chain, LinkUp linkUp)
        {
            return geometricMean.Calculate(chain, linkUp) / descriptiveInformation.Calculate(chain, linkUp);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Regularity;
        }
    }
}