﻿namespace Libiada.Core.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

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
    public static IEnumerable<ComposedSequence> GenerateConcatenations(ComposedSequence[] sourceSequences)
    {
        int[][] orders = PermutationGenerator.GetOrders(sourceSequences.Length);

        for (int i = 0; i < orders.Length; i++)
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
    /// <see cref="ComposedSequence"/> of all source sequences in given order.
    /// </returns>
    public static ComposedSequence Concatenate(ComposedSequence[] sourceSequences, int[] order)
    {
        // TODO: optimize this method
        int resultLength = 0;
        for (int i = 0; i < sourceSequences.Length; i++)
        {
            resultLength += sourceSequences[i].Length;
        }

        ComposedSequence result = new(resultLength);
        int resultIndex = 0;
        for (int i = 0; i < sourceSequences.Length; i++)
        {
            ComposedSequence currentSequence = sourceSequences[order[i]];
            for (int j = 0; j < currentSequence.Length; j++)
            {
                result[resultIndex++] = currentSequence[j];
            }
        }

        return result;
    }

    /// <summary>
    /// Concatenates sequences as they ordered in input array.
    /// </summary>
    /// <param name="sourceSequences">
    /// Sequences to concatenate.
    /// </param>
    /// <returns>
    /// <see cref="ComposedSequence"/> of all source sequences in ascending order.
    /// </returns>
    public static ComposedSequence ConcatenateAsOrdered(ComposedSequence[] sourceSequences)
    {
        // TODO: optimize this method
        int resultLength = 0;
        for (int i = 0; i < sourceSequences.Length; i++)
        {
            resultLength += sourceSequences[i].Length;
        }

        int[] resultOrder = new int[resultLength];
        Alphabet resultAlphabet = [NullValue.Instance()];
        int resultIndex = 0;
        for (int i = 0; i < sourceSequences.Length; i++)
        {
            Dictionary<int, int> coder = [];
            ComposedSequence sequence = sourceSequences[i];
            int[] order = sequence.Order;
            Alphabet alphabet = sequence.Alphabet;
            for (int m = 0; m < alphabet.Cardinality; m++)
            {
                if (!resultAlphabet.Contains(alphabet[m]))
                {
                    resultAlphabet.Add(alphabet[m]);
                }
                coder.Add(m + 1, resultAlphabet.IndexOf(alphabet[m]));
            }

            for (int j = 0; j < sequence.Length; j++)
            {
                resultOrder[resultIndex] = coder[order[j]];
                resultIndex++;
            }
        }

        return new ComposedSequence(resultOrder, resultAlphabet);
    }
}
