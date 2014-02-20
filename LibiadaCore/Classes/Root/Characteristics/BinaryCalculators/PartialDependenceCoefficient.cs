namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using LibiadaCore.Classes.Root.Characteristics.Calculators;

    /// <summary>
    /// The partial dependence coefficient of binary chain.
    /// </summary>
    public class PartialDependenceCoefficient : BinaryCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="firstElement">
        /// Первый элемент
        /// </param>
        /// <param name="secondElement">
        /// Второй элемент
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of partial dependence coefficient.
        /// </returns>
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

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.PartialDependenceCoefficient;
        }
    }
}