namespace Libiada.Core.DataTransformers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Static class that creates dissimilar chain by ordinary chain.
/// Numbers of occurrences are used as elements of dissimilar chain.
/// <example>
/// <para>
/// Chain                    A|T|T|A|C|G|T|C|A
/// Order                    1|2|2|1|3|4|2|3|1
/// Dissimilar order         1|1|2|2|1|1|3|2|3
/// </para>
/// <para>
/// Source chain alphabet A|T|C|G
/// Dissimilar alphabet 1|2|3
/// </para>
/// </example>
/// </summary>
public static class DissimilarChainFactory
{
    /// <summary>
    /// Method that creates chain of "first occurrences of different elements".
    /// </summary>
    /// <param name="source">
    /// Source chain.
    /// </param>
    /// <returns>/
    /// Dissimilar chain.
    /// </returns>
    public static Chain Create(BaseChain source)
    {
        List<IBaseObject> result = [];
        Alphabet sourceAlphabet = source.Alphabet;
        int[] entries = new int[sourceAlphabet.Cardinality];

        for (int i = 0; i < source.Length; i++)
        {
            int elementIndex = sourceAlphabet.IndexOf(source[i]);
            int entry = ++entries[elementIndex];
            result.Add(new ValueInt(entry));
        }

        return new Chain(result);
    }
}
