namespace LibiadaCore.Core.Characteristics.BinaryCalculators
{
    using System;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// The compliance degree.
    /// </summary>
    public class ComplianceDegree
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="firstChain">
        /// The first chain.
        /// </param>
        /// <param name="secondChain">
        /// The second chain.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain firstChain, CongenericChain secondChain)
        {
            var manager = new AccordanceIntervalsManager(firstChain, secondChain);

            if (manager.filteredFirstIntervals.Count == 0)
            {
                return 0;
            }
            double result = 1;

            for (int i = 0; i < manager.filteredFirstIntervals.Count; i++)
            {
                result *= this.LocalCompliance(manager.filteredFirstIntervals[i], manager.filteredSecondIntervals[i]);
            }

            double occurencesCoefficient = 2.0 * manager.filteredFirstIntervals.Count / (firstChain.OccurrencesCount + secondChain.OccurrencesCount);

            result = occurencesCoefficient * Math.Pow(result, 1.0 / manager.filteredFirstIntervals.Count);
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