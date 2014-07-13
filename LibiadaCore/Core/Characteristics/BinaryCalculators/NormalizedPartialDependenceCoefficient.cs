namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    /// <summary>
    /// The normalized partial dependence coefficient of binary chain.
    /// </summary>
    public class NormalizedPartialDependenceCoefficient : BinaryCalculator
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
        /// <see cref="double"/> value of normalized partial dependence coefficient.
        /// </returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

            var partialDependenceCoefficient = new PartialDependenceCoefficient();
            double k1 = partialDependenceCoefficient.Calculate(chain, firstElement, secondElement, link);
            int pairs = chain.GetPairsCount(firstElement, secondElement);
            return k1 * 2 * pairs / chain.GetLength();
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.NormalizedPartialDependenceCoefficient;
        }
    }
}