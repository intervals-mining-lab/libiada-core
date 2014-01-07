namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    public class NormalizedPartialDependenceCoefficient:BinaryCalculator
    {
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }
            var partialDependenceCoefficient = new PartialDependenceCoefficient();
            double k1 = partialDependenceCoefficient.Calculate(chain, firstElement, secondElement, link);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return k1 * 2 * pairs / chain.Length;
        }

        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.NormalizedPartialDependenceCoefficient;
        }
    }
}