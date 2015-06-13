namespace BuildingsIterator.Statistics.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// Calculator for expected value (first central moment or mathematical expectation).
    /// </summary>
    public class ExpectationCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Calculates expected value for given sample.
        /// </summary>
        /// <param name="sample">
        /// The sample of double values.
        /// </param>
        /// <returns>
        /// Mathematical expectation.
        /// </returns>
        public double Calculate(List<double> sample)
        {
            return (new RawMomentCalculator(1)).Calculate(sample);
        }
    }
}
