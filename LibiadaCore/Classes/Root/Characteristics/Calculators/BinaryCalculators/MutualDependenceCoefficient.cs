﻿using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.Calculators.BinaryCalculators
{
    public class MutualDependenceCoefficient:IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            var involvedCoefficientCalculator = new InvolvedPartialDependenceCoefficient();
            double firstInvolvedCoefficient = involvedCoefficientCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            double secondInvolvedCoefficient = involvedCoefficientCalculator.Calculate(chain, secondElement, firstElement, linkUp);
            if (firstInvolvedCoefficient < 0 || secondInvolvedCoefficient < 0)
            {
                return 0;
            }
            return Math.Sqrt(firstInvolvedCoefficient * secondInvolvedCoefficient);
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