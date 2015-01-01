namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// The average remoteness with logarithm base equals cardinality of alphabet.
    /// </summary>
    public class AlphabeticAverageRemoteness : IFullCalculator
    {
        /// <summary>
        /// The geometric mean.
        /// </summary>
        private readonly ICalculator geometricMean = new GeometricMean();

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
        /// <see cref="double"/> 
        /// Value of alphabetic average remoteness.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int alphabetCardinality = chain.Alphabet.Cardinality;
            return Math.Log(geometricMean.Calculate(chain, link), alphabetCardinality);
        }
    }
}
