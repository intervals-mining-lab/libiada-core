using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using System.Collections.Generic;

namespace LibiadaCore.DataTransformers
{
    public class SequenceConcatenator
    {
        public IEnumerable<Chain> GenerateConcatenations(Chain[] sourceSequences)
        {
            int[][] orders = OrderGenerator.GetOrders(sourceSequences.Length);

            for(int i = 0; i < orders.Length; i++)
            {
                yield return Concatenate(sourceSequences, orders[i]);
            }
        }

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
                        resultAlphabet.Add(chain.Alphabet[m]);
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
