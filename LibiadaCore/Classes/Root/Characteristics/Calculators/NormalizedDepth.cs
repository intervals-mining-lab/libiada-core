namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    /// <summary>
    /// Глубина приходящаяся на одно сообщение.
    /// </summary>
    public class NormalizedDepth : ICalculator
    {
        private readonly Depth depth = new Depth();
        private readonly Length length = new Length();

        public double Calculate(CongenericChain chain, Link link)
        {
            return depth.Calculate(chain, link)/length.Calculate(chain, Link.Both);
        }

        public double Calculate(Chain chain, Link link)
        {
            return depth.Calculate(chain, link) / length.Calculate(chain, Link.Both);
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.NormalizedDepth;
        }
    }
}