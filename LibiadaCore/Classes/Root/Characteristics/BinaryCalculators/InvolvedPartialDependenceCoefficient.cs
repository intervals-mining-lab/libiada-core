using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class InvolvedPartialDependenceCoefficient : BinaryCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            var count = new Count();
            CongenericChain firstElementChain = chain.CongenericChain(firstElement);
            CongenericChain secondElementChain = chain.CongenericChain(secondElement);
            int firstElementCount = (int)count.Calculate(firstElementChain,link);
            int secondElementCount = (int)count.Calculate(secondElementChain, link);
            var redundancyCalculator = new Redundancy();
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, link);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * (2 * pairs) / (firstElementCount + secondElementCount);
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.InvolvedPartialDependenceCoefficient;
        }
    }
}