﻿namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The strict sequence generator.
/// </summary>
public class StrictSequenceGenerator : ISequenceGenerator
{
    private SequenceGenerator sequenceGenerator = new();

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
        List<BaseChain> result = [];
        SequenceIterator iterator = new(length, alphabetCardinality);
        foreach(int[] sequence in iterator)
        {
            if(sequence.Distinct().Count() == alphabetCardinality)
            {
                List<IBaseObject> elements = new(sequence.Length);
                for (int i = 0; i < sequence.Length; i++)
                {
                    elements.Add(new ValueInt(sequence[i]));
                }
                result.Add(new BaseChain(elements));
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
        List<BaseChain> result = [];
        for (int i = 1; i <= length; i++)
        {
            result.AddRange(GenerateSequences(length, i));
        }

        return result.Distinct().ToList();
    }
}
