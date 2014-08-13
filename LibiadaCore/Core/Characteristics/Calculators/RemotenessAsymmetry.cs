namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Третий центральный момент или ассиметрия средних удаленностей.
    /// </summary>
    public class RemotenessAsymmetry : IFullCalculator
    {
        /// <summary>
        /// The average remoteness.
        /// </summary>
        private readonly ICalculator averageRemoteness = new AverageRemoteness();

        /// <summary>
        /// The elements count.
        /// </summary>
        private readonly ICalculator elementsCount = new ElementsCount();

        /// <summary>
        /// The length.
        /// </summary>
        private readonly ICalculator length = new Length();

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
            double g = averageRemoteness.Calculate(chain, link);
            double n = length.Calculate(chain, link);

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                double nj = elementsCount.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                double gj = averageRemoteness.Calculate(chain.CongenericChain(chain.Alphabet[i]), link);
                result += nj / n * (gj - g) * (gj - g) * (gj - g);
            }

            return result;
        }
    }
}