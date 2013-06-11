namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// �������� ��������.
    ///</summary>
    public class AlphabetPower: ICharacteristicCalculator
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