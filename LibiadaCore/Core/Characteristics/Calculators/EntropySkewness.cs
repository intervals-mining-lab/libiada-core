namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Asymmetry of average remoteness. Third central moment. Третий центральный момент.
    /// </summary>
    public class EntropySkewness : IFullCalculator
    {
        /// <summary>
        /// The average remoteness.
        /// </summary>
        private readonly ICalculator identificationInformation = new IdentificationInformation();

        /// <summary>
        /// The intervals count.
        /// </summary>
        private readonly ICalculator intervalsCount = new IntervalsCount();

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
            int n = (int)intervalsCount.Calculate(chain, link);

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = intervalsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double hj = identificationInformation.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double deltaH = hj - h;
                result += n == 0 ? 0 : deltaH * deltaH * deltaH * nj / n;
            }

            return result;
        }
    }
}
