namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using Calculators;

    /// <summary>
    /// Involved partial dependence coefficient of binary chain.
    /// </summary>
    public class InvolvedPartialDependenceCoefficient : BinaryCalculator
    {
        /// <summary>
        /// Коэффициент частичной зависимоти.
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
        /// <see cref="double"/> value of involved partial dependence coefficient.
        /// </returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

            var count = new ElementsCount();
            CongenericChain firstElementChain = chain.CongenericChain(firstElement);
            CongenericChain secondElementChain = chain.CongenericChain(secondElement);
            int firstElementCount = (int)count.Calculate(firstElementChain, link);
            int secondElementCount = (int)count.Calculate(secondElementChain, link);
            var redundancyCalculator = new Redundancy();
            double redundancy = redundancyCalculator.Calculate(chain, firstElement, secondElement, link);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return redundancy * (2 * pairs) / (firstElementCount + secondElementCount);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.InvolvedPartialDependenceCoefficient;
        }
    }
}