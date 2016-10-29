namespace LibiadaCore.Misc
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Core.IntervalsManagers;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// The high order factory.
    /// </summary>
    public static class HighOrderFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="Chain"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if link is unacceptable.
        /// </exception>
        public static Chain Create(Chain source, Link link)
        {
            if (link != Link.Start && link != Link.End && link != Link.CycleEnd && link != Link.CycleStart)
            {
                throw new ArgumentException("Unknown link", "link");
            }

            var result = new Chain(source.GetLength());
            Alphabet sourceAlphabet = source.Alphabet;
            var entries = new int[sourceAlphabet.Cardinality];

            var intervals = new int[sourceAlphabet.Cardinality][];

            for (int j = 0; j < sourceAlphabet.Cardinality; j++)
            {
                var intervalsManager = new CongenericIntervalsManager(source.CongenericChain(j));
                intervals[j] = intervalsManager.GetIntervals(link);
            }

            for (int i = 0; i < source.GetLength(); i++)
            {
                var elementIndex = sourceAlphabet.IndexOf(source[i]);
                int entry = entries[elementIndex]++;
                var interval = intervals[elementIndex][entry];
                result.Set(new ValueInt(interval), i);
            }

            return result;
        }
    }
}
