namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Мощность алфавита.
    ///</summary>
    public class AlphabetPower: ICharacteristicCalculator
    {
        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return pChain.Alphabet.Power;
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return pChain.Alphabet.Power;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AlphabetPower;
        }
    }
}