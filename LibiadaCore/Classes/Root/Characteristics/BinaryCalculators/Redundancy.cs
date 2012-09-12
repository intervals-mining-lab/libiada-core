using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class Redundancy:IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            UniformChain firstElementChain = (UniformChain)chain.UniformChain(firstElement);
            int firstElementCount = (int)firstElementChain.GetCharacteristic(linkUp, new Count());
            double avG = 0;
            int currentEntrance = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                if (chain.GetBinaryInterval(firstElement, secondElement, i) > 0)
                {
                    if (currentEntrance == 0)
                    {
                        currentEntrance = chain.GetAfter(secondElement, chain.Get(firstElement, i));
                    }
                    else
                    {
                        int nextEntrance = chain.GetAfter(secondElement, chain.Get(firstElement, i));
                        avG += Math.Log(nextEntrance - currentEntrance, 2);
                        currentEntrance = nextEntrance;
                    }
                }
            }
            avG += Math.Log(chain.Length - currentEntrance, 2);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            avG = pairs == 0 ? 0 : avG / pairs;
            var geometricMeanCalculator = new BinaryGeometricMean();
            double binaryGeometricMean = geometricMeanCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            return 1 - binaryGeometricMean / Math.Pow(2, avG);
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
            throw new System.NotImplementedException();
        }
    }
}