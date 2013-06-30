namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Мощность алфавита.
    ///</summary>
    public class AlphabetPower: ICalculator
    {
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return chain.Alphabet.Power;
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            return chain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabetPower;
        }
    }
}