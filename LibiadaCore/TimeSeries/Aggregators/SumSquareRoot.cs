namespace LibiadaCore.TimeSeries.Aggregators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The sum square root aggregator.
    /// </summary>
    public class SumSquareRoot : IDistancesAggregator
    {
        /// <summary>
        /// The aggregate.
        /// </summary>
        /// <param name="distances">
        /// The distances.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double Aggregate(List<double> distances)
        {
            return Math.Sqrt(distances.Sum());
        }
    }
}