namespace BuildingsIterator.Statistics.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Calculates ith raw moment of sample.
    /// </summary>
    public class RawMomentCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Moment's power.
        /// </summary>
        private readonly int s = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="RawMomentCalculator" /> class.
        /// </summary>
        /// <param name="i">
        /// Moment's power.
        /// </param>
        public RawMomentCalculator(int i)
        {
            s = i;
        }

        /// <summary>
        /// Calculates raw moment of given power for given sample.
        /// </summary>
        /// <param name="sample">
        /// The sample.
        /// </param>
        /// <returns>
        /// Raw moment.
        /// </returns>
        public double Calculate(List<double> sample)
        {
            double sum = sample.Sum(t => Math.Pow(t, s));

            sum /= sample.Count;
            return sum;
        }
    }
}
