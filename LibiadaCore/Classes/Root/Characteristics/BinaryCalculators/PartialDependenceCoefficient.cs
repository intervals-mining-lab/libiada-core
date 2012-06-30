using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class PartialDependenceCoefficient:IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            Redundancy redundancyCalculator = new Redundancy();
            UniformChain secondElementChain = (UniformChain)chain.UniformChain(secondElement);
            int secondElementCount = (int)secondElementChain.GetCharacteristic(linkUp, new Count());
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * pairs / secondElementCount;
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

        public  BinaryCharacteristicsEnum GetCharacteristicName()
        {
            throw new System.NotImplementedException();
        }
    }
}