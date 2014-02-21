namespace LibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    using System;

    /// <summary>
    /// Mutual dependence coefficient of binary chain.
    /// </summary>
    public class MutualDependenceCoefficient : BinaryCalculator
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
        /// <see cref="double"/> value of mutual dependence coefficient.
        /// </returns>
        public override double Calculate(Chain chain, IBaseObject firstElement, IBaseObject secondElement, Link link)
        {
            if (firstElement.Equals(secondElement))
            {
                return 0;
            }

            var involvedCoefficientCalculator = new InvolvedPartialDependenceCoefficient();
            double firstInvolvedCoefficient = involvedCoefficientCalculator.Calculate(chain, firstElement, secondElement, link);
            double secondInvolvedCoefficient = involvedCoefficientCalculator.Calculate(chain, secondElement, firstElement, link);
            return firstInvolvedCoefficient < 0 || secondInvolvedCoefficient < 0
                       ? 0 : Math.Sqrt(firstInvolvedCoefficient * secondInvolvedCoefficient);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="BinaryCharacteristicsEnum"/>.
        /// </returns>
        public override BinaryCharacteristicsEnum GetCharacteristicName()
        {
            return BinaryCharacteristicsEnum.MutualDependenceCoefficient;
        }
    }
}