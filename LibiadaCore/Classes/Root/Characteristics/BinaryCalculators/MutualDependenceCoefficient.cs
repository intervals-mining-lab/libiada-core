using System;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class MutualDependenceCoefficient:BinaryCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
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

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.MutualDependenceCoefficient;
        }
    }
}