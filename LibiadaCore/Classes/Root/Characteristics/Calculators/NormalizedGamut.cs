namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Удалённость приходящаяся на одно сообщение.
    ///</summary>
    public class NormalizedGamut : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.G)/
                pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.G) /
                pChain.GetCharacteristic(LinkUp.Both, CharacteristicsFactory.Length);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NomalizationGamut;
        }
    }
}