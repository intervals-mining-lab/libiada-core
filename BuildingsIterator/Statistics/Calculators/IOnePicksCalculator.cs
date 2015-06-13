namespace BuildingsIterator.Statistics.Calculators
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
        /// <param name="sample">
        /// The sample of double values.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        double Calculate(List<double> sample);
    }
}
