namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Длина цепи.
    ///</summary>
    public class Length : ICalculator
    {
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.Length;
        }

        public double Calculate(Chain chain, Link link)
        {
            return chain.Length;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.Length;
        }
    }
}