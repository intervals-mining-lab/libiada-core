namespace LibiadaCore.Misc
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Static class that creates dissimilar chain by ordinary chain.
    /// Numbers of occurrences are used as elements of dissimilar chain.
    /// <example>
    /// <para>
    /// Chain                    A|T|T|A|C|G|T|C|A
    /// Building                 1|2|2|1|3|4|2|3|1
    /// Dissimilar building      1|1|2|2|1|1|3|2|3 
    /// </para>
    /// <para>
    /// Chain alphabet       A|T|C|G
    /// Dissimilar alphabet  1|2|3
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
        /// <returns>
        /// Dissimilar chain.
        /// </returns>
        public static Chain Create(BaseChain source)
        {
            var result = new Chain(source.GetLength());
            Alphabet sourceAlphabet = source.Alphabet;
            var entries = new List<int>();
            for (int j = 0; j < sourceAlphabet.Cardinality; j++)
            {
                entries.Add(0);
            }

            for (int i = 0; i < source.GetLength(); i++)
            {
                int entry = ++entries[sourceAlphabet.IndexOf(source[i])];
                result.Add(new ValueInt(entry), i);
            }

            return result;
        }
    }
}
