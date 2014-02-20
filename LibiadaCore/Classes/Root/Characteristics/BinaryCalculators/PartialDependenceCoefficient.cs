namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    public class PartialDependenceCoefficient:BinaryCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

            var redundancyCalculator = new Redundancy();
            CongenericChain secondElementChain = chain.CongenericChain(secondElement);
            var count = new Count();
            int secondElementCount = (int)count.Calculate(secondElementChain, link);
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, link);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * pairs / secondElementCount;
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.PartialDependenceCoefficient;
        }
    }
}