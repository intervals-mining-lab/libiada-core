namespace LibiadaCore.DataTransformers
{
    using System;
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.ArrangementManagers;
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
                throw new ArgumentException("Unknown or inapplicable link", nameof(link));
            }

            var result = new List<IBaseObject>();
            Alphabet sourceAlphabet = source.Alphabet;
            var entries = new int[sourceAlphabet.Cardinality];
            var intervals = new int[sourceAlphabet.Cardinality][];

            for (int j = 0; j < sourceAlphabet.Cardinality; j++)
            {
                var intervalsManager = new IntervalsManager();
                intervalsManager.Initialize(source.CongenericChain(j));
                intervals[j] = intervalsManager.GetArrangement(link);
            }

            for (int i = 0; i < source.Length; i++)
            {
                int elementIndex = sourceAlphabet.IndexOf(source[i]);
                int entry = entries[elementIndex]++;
                int interval = intervals[elementIndex][entry];
                result.Add(new ValueInt(interval));
            }

            return new Chain(result);
        }
    }
}
