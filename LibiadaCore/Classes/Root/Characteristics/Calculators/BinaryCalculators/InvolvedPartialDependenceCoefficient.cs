using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    public class InvolvedPartialDependenceCoefficient : IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            UniformChain firstElementChain = (UniformChain)chain.UniformChain(firstElement);
            UniformChain secondElementChain = (UniformChain)chain.UniformChain(secondElement);
            int firstElementCount = (int)firstElementChain.GetCharacteristic(linkUp, new Count());
            int secondElementCount = (int)secondElementChain.GetCharacteristic(linkUp, new Count());
            int intervals = 1;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = chain.GetBinaryInterval(firstElement, secondElement, i);
                if (binaryInterval > 0)
                {
                    intervals *= binaryInterval;
                }
            }
            Redundancy redundancyCalculator = new Redundancy();
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * (2 * pairs) / (firstElementCount + secondElementCount);
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