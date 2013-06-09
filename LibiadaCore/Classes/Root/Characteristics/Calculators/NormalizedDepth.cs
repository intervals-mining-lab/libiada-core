namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Глубина приходящаяся на одно сообщение.
    ///</summary>
    public class NormalizedDepth : ICharacteristicCalculator
    {
        private Depth depth = new Depth();
        private Length length = new Length();

        public double Calculate(UniformChain pChain, LinkUp Link)
        {
            return depth.Calculate(pChain, Link)/length.Calculate(pChain, LinkUp.Both);
        }

        public double Calculate(Chain pChain, LinkUp Link)
        {
            return depth.Calculate(pChain, Link) / length.Calculate(pChain, LinkUp.Both);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NomalizedDepth;
        }
    }
}