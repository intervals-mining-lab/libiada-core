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
    /// The <see cref="List"/>.
    /// </returns>
    public List<BaseChain> GenerateSequences(int length)
    {
        return GenerateSequences(length, length);
    }
}
