namespace SequenceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The order generator.
    /// </summary>
    public class OrderGenerator
    {
        /// <summary>
        /// Generates orders of given length and 
        /// alphabet cardinality less or equals than given.
        /// </summary>
        /// <param name="length">
        /// The order length.
        /// </param>
        /// <param name="alphabetCardinality">
        /// The order alphabet cardinality.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{int[]}"/>.
        /// </returns>
        public List<int[]> GenerateOrders(int length, int alphabetCardinality)
        {
            var result = new List<int[]>();
            var iterator = new OrderIterator(length, alphabetCardinality);
            foreach (int[] order in iterator)
            {
                result.Add(order);
            }

            return result;
        }

        /// <summary>
        /// Generates orders of given length and alphabet cardinality.
        /// </summary>
        /// <param name="length">
        /// The order length.
        /// </param>
        /// <param name="alphabetCardinality">
        /// The order alphabet cardinality.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{int[]}"/>.
        /// </returns>
        public List<int[]> StrictGenerateOrders(int length, int alphabetCardinality)
        {
            var result = new List<int[]>();
            var iterator = new OrderIterator(length, alphabetCardinality);
            foreach (int[] order in iterator)
            {
                if (order.Distinct().Count() == alphabetCardinality)
                {
                    result.Add(order);
                }
            }

            return result;
        }

        /// <summary>
        /// Generate orders of given length.
        /// </summary>
        /// <param name="length">
        /// The order length.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{int[]}"/>.
        /// </returns>
        public List<int[]> GenerateOrders(int length)
        {
            return GenerateOrders(length, length);
        }
    }
}
