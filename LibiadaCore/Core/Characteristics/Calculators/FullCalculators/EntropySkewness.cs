namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Asymmetry of average remoteness. Third central moment.
    /// </summary>
    public class EntropySkewness : IFullCalculator
    {
        /// <summary>
        /// The average remoteness.
        /// </summary>
        private readonly IFullCalculator identificationInformation = new IdentificationInformation();

        /// <summary>
        /// The intervals count.
        /// </summary>
        private readonly IFullCalculator intervalsCount = new IntervalsCount();

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
            double result = 0;
            double h = identificationInformation.Calculate(chain, link);
            var n = (int)intervalsCount.Calculate(chain, link);

            var congenericIntervalsCount = new CongenericCalculators.IntervalsCount();
            var congenericIdentificationInformation = new CongenericCalculators.IdentificationInformation();
            Alphabet alphabet = chain.Alphabet;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                double nj = congenericIntervalsCount.Calculate(chain.CongenericChain(i), link);
                double hj = congenericIdentificationInformation.Calculate(chain.CongenericChain(i), link);
                double deltaH = hj - h;
                result += n == 0 ? 0 : deltaH * deltaH * deltaH * nj / n;
            }

            return result;
        }
    }
}
