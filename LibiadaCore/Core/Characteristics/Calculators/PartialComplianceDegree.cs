using System.ComponentModel;

namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;
    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The compliance degree.
    /// </summary>
    public class PartialComplianceDegree : IAccordanceCalculator
    {
        public double Calculate(CongenericChain firstChain, CongenericChain secondChain, Link link)
        {
            var manager = new AccordanceIntervalsManager(firstChain, secondChain);
            if (manager.FilteredFirstIntervals.Count == 0)
            {
                return 0;
            }

            double result = 1;

            for (int i = 0; i < manager.FilteredFirstIntervals.Count; i++)
            {
                result *= LocalCompliance(manager.FilteredFirstIntervals[i], manager.FilteredSecondIntervals[i]);
            }

            double firstAndSecondOccurrences = manager.FirstOccurrencesCount + manager.SecondOccurrencesCount;

            double occurrencesCoefficient = 2.0 * manager.FilteredFirstIntervals.Count / firstAndSecondOccurrences;

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
