using LibiadaCore.Classes.Root.Characteristics.Calculators;

namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class InvolvedPartialDependenceCoefficient : BinaryCharacteristicCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, LinkUp linkUp)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            Count count = new Count();
            UniformChain firstElementChain = chain.UniformChain(firstElement);
            UniformChain secondElementChain = chain.UniformChain(secondElement);
            int firstElementCount = (int)count.Calculate(firstElementChain,linkUp);
            int secondElementCount = (int)count.Calculate(secondElementChain, linkUp);
            Redundancy redundancyCalculator = new Redundancy();
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, linkUp);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * (2 * pairs) / (firstElementCount + secondElementCount);
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.InvolvedPartialDependenceCoefficient;
        }
    }
}