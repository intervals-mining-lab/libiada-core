namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    /// Глубина приходящаяся на одно сообщение.
    ///</summary>
    public class NormalizedDepth : ICalculator
    {
        private readonly Depth depth = new Depth();
        private readonly Length length = new Length();

        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            return depth.Calculate(chain, linkUp)/length.Calculate(chain, LinkUp.Both);
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            return depth.Calculate(chain, linkUp) / length.Calculate(chain, LinkUp.Both);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NomalizedDepth;
        }
    }
}