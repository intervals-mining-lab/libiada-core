namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The non-redundant strict sequence generator.
/// </summary>
public class NonRedundantStrictSequenceGenerator : ISequenceGenerator
{
    /// <summary>
    /// The redundant sequence generator.
    /// </summary>
    private readonly StrictSequenceGenerator redundantSequenceGenerator = new();

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
            int chainAlphabetCardinality = sequence.Alphabet.Cardinality;
            bool nonRedundant = sequence.Alphabet.All(el => (ValueInt)el <= chainAlphabetCardinality);
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
        List<Sequence> result = [];
        for (int i = 1; i <= length; i++)
        {
            result.AddRange(GenerateSequences(length, i));
        }

        return result.Distinct().ToList();
    }
}
