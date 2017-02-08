namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Entropy of Dispersion.
    /// </summary>
    public class EntropyDispersion : IFullCalculator
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
        /// Entropy dispersion <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var identificationInformation = new IdentificationInformation();
            var intervalsCount = new IntervalsCount();

            double result = 0;
            double g = identificationInformation.Calculate(chain, link);
            var n = (int)intervalsCount.Calculate(chain, link);

            var congenericIntervalsCount = new CongenericCalculators.IntervalsCount();
            var congenericAverageRemoteness = new CongenericCalculators.AverageRemoteness();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gj = congenericAverageRemoteness.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double deltaH = gj - g;
                result += n == 0 ? 0 : nj / n * deltaH * deltaH;
            }

            return result;
        }
    }
}
