namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System.Linq;

    /// <summary>
    /// Sum of intervals lengths depending on link.
    /// </summary>
    public class IntervalsSum : ICalculator
    {
        /// <summary>
        /// Sum of intervals lengths in congeneric sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var intervals = chain.GetIntervals(link);

            return intervals.Length == 0 ? 0 : intervals.Sum(interval => interval);
        }

        /// <summary>
        /// Sum of intervals lengths in all congeneric sequences of complete sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double sum = 0;

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += Calculate(chain.CongenericChain(i), link);
            }

            return sum;
        }
    }
}
