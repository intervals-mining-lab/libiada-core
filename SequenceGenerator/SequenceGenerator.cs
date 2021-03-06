﻿namespace SequenceGenerator
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The sequence generator.
    /// </summary>
    public class SequenceGenerator : ISequenceGenerator
    {
        /// <summary>
        /// Generates numeric sequences using given length and
        /// alphabet cardinality less or equal than given.
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
            var result = new List<BaseChain>();
            var iterator = new SequenceIterator(length, alphabetCardinality);
            foreach (int[] sequence in iterator)
            {
                var elements = new List<IBaseObject>(sequence.Length);
                for (int i = 0; i < sequence.Length; i++)
                {
                    elements.Add(new ValueInt(sequence[i]));
                }

                result.Add(new BaseChain(elements));
            }

            return result;
        }

        /// <summary>
        /// Generates numeric sequences using given length.
        /// </summary>
        /// <param name="length">
        /// The sequence length.
        /// </param>
        /// <returns>
        /// The <see cref="T:List{BaseChain}"/>.
        /// </returns>
        public List<BaseChain> GenerateSequences(int length)
        {
            return GenerateSequences(length, length);
        }
    }
}
