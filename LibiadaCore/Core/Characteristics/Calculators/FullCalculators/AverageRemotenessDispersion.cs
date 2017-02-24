﻿namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Dispersion of average remoteness.
    /// </summary>
    public class AverageRemotenessDispersion : IFullCalculator
    {
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
        /// Average remoteness dispersion <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var averageRemoteness = new AverageRemoteness();
            var intervalsCount = new IntervalsCount();

            double result = 0;
            double g = averageRemoteness.Calculate(chain, link);
            var n = (int)intervalsCount.Calculate(chain, link);
            if (n == 0)
            {
                return 0;
            }

            var congenericAverageRemoteness = new CongenericCalculators.AverageRemoteness();
            var congenericIntervalsCount = new CongenericCalculators.IntervalsCount();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gDelta = gj - g;
                result += gDelta * gDelta * nj / n;
            }

            return result;
        }
    }
}