namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

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
        List<BaseChain> result = [];
        SequenceIterator iterator = new(length, alphabetCardinality);
        foreach (int[] sequence in iterator)
        {
            List<IBaseObject> elements = new(sequence.Length);
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
