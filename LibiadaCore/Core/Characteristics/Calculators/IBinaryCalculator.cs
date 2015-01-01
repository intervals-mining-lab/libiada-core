namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Interface of binary calculators.
    /// </summary>
    public interface IBinaryCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of characteristic.
        /// </returns>
        double Calculate(BinaryIntervalsManager manager, Link link);

        /// <summary>
        /// Calculates relative characteristics of all pairs of elements.
        /// </summary>
        /// <param name="chain">
        /// The chain.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// <see cref="List{List{double}}"/>.
        /// </returns>
        List<List<double>> CalculateAll(Chain chain, Link link);
    }
}
