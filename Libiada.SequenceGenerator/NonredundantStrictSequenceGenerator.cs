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
    /// The <see cref="List{BaseChain}"/>.
    /// </returns>
    public List<BaseChain> GenerateSequences(int length, int alphabetCardinality)
    {
        List<BaseChain> redundantResult = redundantSequenceGenerator.GenerateSequences(length, alphabetCardinality);
        List<BaseChain> nonRedundantResult = [];
        foreach (BaseChain chain in redundantResult)
        {
            int chainAlphabetCardinality = chain.Alphabet.Cardinality;
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
        List<BaseChain> result = [];
        for (int i = 1; i <= length; i++)
        {
            result.AddRange(GenerateSequences(length, i));
        }

        return result.Distinct().ToList();
    }
}
