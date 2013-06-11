using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class PartialDependenceCoefficient:BinaryCharacteristicCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

            Redundancy redundancyCalculator = new Redundancy();
            UniformChain secondElementChain = chain.UniformChain(secondElement);
            Count count = new Count();
            int secondElementCount = (int)count.Calculate(secondElementChain, linkUp);
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * pairs / secondElementCount;
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.PartialDependenceCoefficient;
        }
    }
}