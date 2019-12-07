using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using System.Collections.Generic;

namespace LibiadaCore.DataTransformers
{
    /// <summary>
    /// Class for constructing different concatenations of sequences sets.
    /// In other words it generates all possible orderings of several sequences.
    /// </summary>
    public static class SequenceConcatenator
    {
        /// <summary>
        /// Yields array of all possible concatenations of all sequences of given array.
        /// </summary>
        /// <param name="sourceSequences">
        /// Array of sequences to concatenate.
        /// </param>
        /// <returns>
        /// Collection of sequences concatenated in various orders.
        /// </returns>
        public static IEnumerable<Chain> GenerateConcatenations(Chain[] sourceSequences)
        {
            int[][] orders = PermutationGenerator.GetOrders(sourceSequences.Length);

            for(int i = 0; i < orders.Length; i++)
            {
                yield return Concatenate(sourceSequences, orders[i]);
            }
        }
        /// <summary>
        /// Concatenates sequences in given order.
        /// </summary>
        /// <param name="sourceSequences">
        /// Sequences to concatenate.
        /// </param>
        /// <param name="order">
        /// Order in which sequences are concatenated.
        /// </param>
        /// <returns>
        /// <see cref="Chain"/> of all source sequences in given order.
        /// </returns>
        public static Chain Concatenate(Chain[] sourceSequences, int[] order)
        {
            int resultLength = 0;
            for (int i = 0; i < sourceSequences.Length; i++)
            {
                resultLength += sourceSequences[i].Length;
            }
            Chain result = new Chain(resultLength);
            int resultIndex = 0;
            for (int i = 0; i < sourceSequences.Length; i++)
            {
                Chain currentSequence = sourceSequences[order[i]];
                for (int j = 0; j < currentSequence.Length; j++)
                {
                    result[resultIndex++] = currentSequence[j];
                }
            }
            return result;
        }


        /// <summary>
        /// Concatenates sequences in given order.
        /// </summary>
        /// <param name="sourceSequences">
        /// Sequences to concatenate.
        /// </param>
        /// <returns>
        /// <see cref="Chain"/> of all source sequences in ascending order.
        /// </returns>
        public static Chain ConcatenateOrder(Chain[] sourceSequences)
        {
            int resultLength = 0;
            for (int i = 0; i < sourceSequences.Length; i++)
            {
                resultLength += sourceSequences[i].Length;
            }
            var result = new int[resultLength];
            var resultAlphabet = new Alphabet() { NullValue.Instance() };
            int k = 0;
            for (int i = 0; i < sourceSequences.Length; i++)
            {
                var coder = new Dictionary<int, int>();
                var chain = sourceSequences[i];
                var building = chain.Building;
                for (int m = 0; m < chain.Alphabet.Cardinality; m++)
                {
                    if (!resultAlphabet.Contains(chain.Alphabet[m]))
                    {
                        resultAlphabet.Add(chain.Alphabet[m]);
                    }
                    coder.Add(m + 1, resultAlphabet.IndexOf(chain.Alphabet[m]));
                }
                for (int j = 0; j < chain.Length; j++)
                {
                    result[k] = coder[building[j]];
                    k++;
                }
            }
            return new Chain(result, resultAlphabet);
        }

    }
}
