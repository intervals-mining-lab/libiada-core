namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Периодичность.
    /// Имеет смысл только для однородной цепи.
    ///</summary>
    public class Periodicity : ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG)/
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaG) /
                pChain.GetCharacteristic(Link, CharacteristicsFactory.deltaA);

        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Periodicity;
        }
    }
}