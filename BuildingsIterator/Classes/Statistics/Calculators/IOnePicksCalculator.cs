namespace BuildingsIterator.Classes.Statistics.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// The OnePicksCalculator interface.
    /// </summary>
    public interface IOnePicksCalculator
    {
        /// <summary>
        /// The calculate.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double Calculate(List<double> values);
    }
}