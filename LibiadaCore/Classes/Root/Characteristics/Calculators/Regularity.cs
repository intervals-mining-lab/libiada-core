namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// –егул€рность.
    ///</summary>
    public class Regularity : ICharacteristicCalculator
    {
        GeometricMean geometricMean = new GeometricMean();
        DescriptiveInformation descriptiveInformation = new DescriptiveInformation();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return geometricMean.Calculate(pChain, Link) / descriptiveInformation.Calculate(pChain, Link);
        }

        ///<summary>
        ///</summary>
        ///<param name="pChain"></param>
        ///<param name="Link"></param>
        ///<returns></returns>
        public double Calculate(Chain pChain, LinkUp Link)
        {
            return geometricMean.Calculate(pChain, Link) / descriptiveInformation.Calculate(pChain, Link);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Regularity;
        }
    }
}