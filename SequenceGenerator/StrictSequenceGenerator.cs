namespace SequenceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core;

    /// <summary>
    /// The strict sequence generator.
    /// </summary>
    public class StrictSequenceGenerator : ISequenceGenerator
    {
        /// <summary>
        /// Generates numeric sequences using given length and alphabet cardinality.
        /// </summary>
        /// <param name="length">
        /// The sequence length.
        /// </param>
        /// <param name="alphabetCardinality">
        /// The sequence alphabet cardinality.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{BaseChain}"/>.
        /// </returns>
        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var sequenceGenerator = new SequenceGenerator();
            var result = sequenceGenerator.GenerateSequences(length, alphabetCardinality);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i].Alphabet.Cardinality < alphabetCardinality)
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        /// <summary>
        /// Generates all sequences of given length with unique orders.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{BaseChain}"/>.
        /// </returns>
        public List<BaseChain> GenerateSequences(int length)
        {
            var result = new List<BaseChain>();
            for (int i = 1; i <= length; i++)
            {
                result.AddRange(GenerateSequences(length, i));
            }

            return result.Distinct().ToList();
        }
    }
}
