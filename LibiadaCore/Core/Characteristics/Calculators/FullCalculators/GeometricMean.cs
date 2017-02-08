using System;
using System.Linq;
using LibiadaCore.Core.Characteristics.Calculators.BinaryCalculators;
using LibiadaCore.Core.IntervalsManagers;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Average geometric value of interval length.
    /// </summary>
    public class GeometricMean : IFullCalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly IFullCalculator averageRemoteness = new AverageRemoteness();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double remoteness = averageRemoteness.Calculate(chain, link);

            return Math.Pow(2, remoteness);
        }
    }
}
