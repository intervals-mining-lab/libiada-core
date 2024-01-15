namespace SequenceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The non-redundant strict sequence generator.
    /// </summary>
    public class NonRedundantStrictSequenceGenerator : ISequenceGenerator
    {
        /// <summary>
        /// The redundant sequence generator.
        /// </summary>
        private readonly StrictSequenceGenerator redundantSequenceGenerator = new StrictSequenceGenerator();

        /// <summary>
        /// The generate sequences.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="alphabetCardinality">
        /// The alphabet cardinality.
        /// </param>
        /// <returns>
        /// The <see cref="List{BaseChain}"/>.
        /// </returns>
        public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
        {
            var redundantResult = redundantSequenceGenerator.GenerateSequences(length, alphabetCardinality);
            var nonRedundantResult = new List<BaseChain>();
            foreach (var chain in redundantResult)
            {
                var chainAlphabetCardinality = chain.Alphabet.Cardinality;
                bool nonRedundant = chain.Alphabet.All(el => (ValueInt)el <= chainAlphabetCardinality);
                if (nonRedundant)
                {
                    nonRedundantResult.Add(chain);
                }
            }

            return nonRedundantResult;
        }

        /// <summary>
        /// The generate sequences.
        /// </summary>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <returns>
        /// The <see cref="List{BaseChain}"/>.
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
