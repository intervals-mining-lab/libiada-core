﻿namespace LibiadaCore.TimeSeries.Aggregators
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The min aggregator.
    /// </summary>
    public class Min : IDistancesAggregator
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
            return distances.Min();
        }
    }
}