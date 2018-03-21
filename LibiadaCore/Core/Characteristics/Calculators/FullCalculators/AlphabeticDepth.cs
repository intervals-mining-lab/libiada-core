namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using System;
    using System.Linq;

    /// <summary>
    /// Depth with logarithm base equals cardinality of alphabet.
    /// </summary>
    public class AlphabeticDepth : IFullCalculator
    {
        /// <summary>
        /// The alphabet cardinality.
        /// </summary>
        private int alphabetCardinality;

        /// <summary>
        /// Logarithm of all intervals multiplied.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            alphabetCardinality = chain.Alphabet.Cardinality;
            double result = 0;
            for (int i = 0; i < alphabetCardinality; i++)
            {
                result += Calculate(chain.CongenericChain(i), link);
            }

            return result;
        }

        /// <summary>
        /// Logarithm of all intervals multiplied.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of alphabetic average remoteness.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if method is called not from <see cref="Calculate(Chain,Link)"/> and alphabet cardinality is unknown.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unknown.
        /// </exception>
        private double Calculate(CongenericChain chain, Link link)
        {
            int[] intervals = chain.GetArrangement(link);
            return intervals.Length == 0 ? 0 : intervals.Sum(interval => Math.Log(interval, alphabetCardinality));
        }
    }
}
