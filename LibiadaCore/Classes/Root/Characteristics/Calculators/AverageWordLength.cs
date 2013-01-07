using LibiadaCore.Classes.Root.SimpleTypes;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    public class AverageWordLength : ICharacteristicCalculator
    {
        public double Calculate(UniformChain chain, LinkUp linkUp)
        {
            throw new System.NotImplementedException();
        }

        public double Calculate(Chain chain, LinkUp linkUp)
        {
            int chainLength = chain.Length;
            int sum = 0;

            for (int index = chainLength; --index >= 0;)
            {
                sum = sum + ((ValueString) chain[index]).value.Length;
            }

            return sum/(double) chainLength;
        }

        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.AverageWordLength;
        }
    }
}