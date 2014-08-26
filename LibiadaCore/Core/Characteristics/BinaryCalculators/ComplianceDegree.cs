namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

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
            if (manager.filteredFirstIntervals.Count == 0)
            {
                return 0;
            }

            double result = 1;

            for (int i = 0; i < manager.filteredFirstIntervals.Count; i++)
            {
                result *= LocalCompliance(manager.filteredFirstIntervals[i], manager.filteredSecondIntervals[i]);
            }

            double occurrencesCoefficient = 2.0 * manager.filteredFirstIntervals.Count / (manager.firstOccurrencesCount + manager.secondOccurrencesCount);

            result = occurrencesCoefficient * Math.Pow(result, 1.0 / manager.filteredFirstIntervals.Count);
            return result;
        }

        /// <summary>
        /// The local compliance.
        /// </summary>
        /// <param name="firstPosition">
        /// The first position.
        /// </param>
        /// <param name="secondPosition">
        /// The second position.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        private double LocalCompliance(int firstPosition, int secondPosition)
        {
            return 2 * Math.Sqrt(firstPosition * secondPosition) / (firstPosition + secondPosition);
        }
    }
}