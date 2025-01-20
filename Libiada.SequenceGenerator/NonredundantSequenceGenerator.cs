namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The non-redundant sequence generator.
/// </summary>
public class NonRedundantSequenceGenerator : ISequenceGenerator
{
    /// <summary>
    /// The redundant sequence generator.
    /// </summary>
    private readonly SequenceGenerator redundantSequenceGenerator = new();

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
    /// The <see cref="List{Libiada.Core.Core.Sequence}"/>.
    /// </returns>
    public List<Sequence> GenerateSequences(int length, int alphabetCardinality)
    {
        List<Sequence> redundantResult = redundantSequenceGenerator.GenerateSequences(length, alphabetCardinality);
        List<Sequence> nonRedundantResult = [];
        foreach (Sequence sequence in redundantResult)
        {
            int sequenceAlphabetCardinality = sequence.Alphabet.Cardinality;
            bool nonRedundant = sequence.Alphabet.All(el => (ValueInt)el <= sequenceAlphabetCardinality);
            if (nonRedundant)
            {
                nonRedundantResult.Add(sequence);
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
    /// The <see cref="List{Libiada.Core.Core.Sequence}"/>.
    /// </returns>
    public List<Sequence> GenerateSequences(int length)
    {
        return GenerateSequences(length, length);
    }
}
