namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The compliance degree.
    /// </summary>
    public class ComplianceDegree : BinaryCalculator
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public override double Calculate(BinaryIntervalsManager manager, Link link)
        {
            if (manager.FilteredFirstIntervals.Count == 0)
            {
                return 0;
            }

            double result = 1;

            for (int i = 0; i < manager.FilteredFirstIntervals.Count; i++)
            {
                result *= LocalCompliance(manager.FilteredFirstIntervals[i], manager.FilteredSecondIntervals[i]);
            }

            double occurrencesCoefficient = 2.0 * manager.FilteredFirstIntervals.Count / (manager.FirstOccurrencesCount + manager.SecondOccurrencesCount);

            result = occurrencesCoefficient * Math.Pow(result, 1.0 / manager.FilteredFirstIntervals.Count);
            return result;
        }

        /// <summary>
        /// The local compliance.
        /// </summary>
        /// <param name="firstInterval">
        /// The first position.
        /// </param>
        /// <param name="secondInterval">
        /// The second position.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double LocalCompliance(int firstInterval, int secondInterval)
        {
            return 2 * Math.Sqrt(firstInterval * secondInterval) / (firstInterval + secondInterval);
        }
    }
}