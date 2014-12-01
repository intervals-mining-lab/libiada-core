namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Intervals count depending on link.
    /// </summary>
    public class IntervalsCount : ICalculator
    {
        /// <summary>
        /// If link is to start, to end or cycle then intervals count equals elements count.
        /// If link is to start and end then intervals count equals elements count + 1.
        /// If link is none then intervals count equals elements count - 1.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.GetIntervals(link).Length;
        }

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
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double sum = 0;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += Calculate(chain.CongenericChain(i), link);
            }

            return (int)sum;
        }
    }
}