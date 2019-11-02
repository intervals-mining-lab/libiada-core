using LibiadaCore.Core;
using System.Collections.Generic;

namespace LibiadaCore.DataTransformers
{
    public class SequenceConcatenator
    {
        public IEnumerable<Chain> GenerateConcatenations(Chain[] sourceSequences)
        {
            int[][] orders = null;

            for(int i = 0; i < orders.Length; i++)
            {
                yield return Concatenate(sourceSequences, orders[i]);
            }
        }

        public Chain Concatenate(Chain[] sourceSequences, int[] order)
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
    }
}
