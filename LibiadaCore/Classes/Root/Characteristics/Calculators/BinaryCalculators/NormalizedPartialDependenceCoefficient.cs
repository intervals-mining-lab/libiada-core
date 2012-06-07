using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    public class NormalizedPartialDependenceCoefficient : IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            var partialDependenceCoefficient = new PartialDependenceCoefficient();
            double k1 = partialDependenceCoefficient.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return k1 * 2 * pairs / chain.Length;
        }

        public List<List<double>> Calculate(Chain chain, LinkUp linkUp)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.power; j++)
                {
                    if (i != j)
                    {
                        result[i].Add(Calculate(chain, chain.Alphabet[i], chain.Alphabet[j], linkUp));
                    }
                    else
                    {
                        result[i].Add(0);
                    }
                }
            }
            return result;
        }

        public BinaryCharacteristicsEnum GetCharacteristicName()
        {
            throw new System.NotImplementedException();
        }
    }
}