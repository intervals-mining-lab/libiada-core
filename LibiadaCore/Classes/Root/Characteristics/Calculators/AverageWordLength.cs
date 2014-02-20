namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using LibiadaCore.Classes.Root.SimpleTypes;

    public class AverageWordLength : ICalculator
    {
        public double Calculate(CongenericChain chain, Link link)
        {
            throw new System.NotImplementedException();
        }

        public double Calculate(Chain chain, Link link)
        {
            int chainLength = chain.Length;
            int sum = 0;

            for (int index = chainLength; --index >= 0;)
            {
                sum = sum + ((ValueString) chain[index]).Value.Length;
            }

            return sum/(double) chainLength;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverageWordLength;
        }
    }
}