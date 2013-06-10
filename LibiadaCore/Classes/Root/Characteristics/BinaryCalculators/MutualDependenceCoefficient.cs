using System;
using System.Collections.Generic;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class MutualDependenceCoefficient:IBinaryCharacteristicCalculator
    {
        public double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
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
            return BinaryCharacteristicsEnum.MutualDependenceCoefficient;
        }
    }
}