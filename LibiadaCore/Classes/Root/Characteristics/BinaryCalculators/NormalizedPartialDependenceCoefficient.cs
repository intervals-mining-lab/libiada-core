using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class NormalizedPartialDependenceCoefficient : IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            var partialDependenceCoefficient = new PartialDependenceCoefficient();
            double k1 = partialDependenceCoefficient.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return k1 * 2 * pairs / chain.Length;
        }

        public List<List<double>> Calculate(Chain chain, LinkUp linkUp)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Power; j++)
                {
                    result[i].Add(Calculate(chain, chain.Alphabet[i], chain.Alphabet[j], linkUp));
                }
            }
            return result;
        }

        public BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.NormalizedPartialDependenceCoefficient;
        }
    }
}