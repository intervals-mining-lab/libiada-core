namespace LibiadaCore.TimeSeries.Aggregators
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The max aggregator.
    /// </summary>
    public class Max : IDistancesAggregator
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
            return distances.Max();
        }
    }
}