using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class BinaryGeometricMean : IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            int firstElementCount = (int)chain.UniformChain(firstElement).GetCharacteristic(linkUp, new Count());
            double intervals = 0;
            for (int i = 1; i <= firstElementCount; i++)
            {
                int binaryInterval = chain.GetBinaryInterval(firstElement, secondElement, i);
                if (binaryInterval > 0)
                {
                    intervals += Math.Log(binaryInterval, 2);
                }
            }
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return Math.Pow(2, pairs == 0 ? 0 : intervals / pairs);
        }

        public List<List<double>> Calculate(Chain chain, LinkUp linkUp)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Power; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Power; j++)
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