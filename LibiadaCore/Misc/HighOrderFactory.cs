using System.Dynamic;
using LibiadaCore.Core.IntervalsManagers;

namespace LibiadaCore.Misc
{
    using System.Collections.Generic;
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using System;
    public static class HighOrderFactory
    {
        public static Chain Create(Chain source, Link link)
        {
            if (link != Link.Start && link != Link.End) 
            {
                throw new ArgumentException("UnknownLink");
            }
            var result = new Chain(source.GetLength());
            Alphabet sourceAlphabet = source.Alphabet;
            var entries = new List<int>();
            for (int j = 0; j < sourceAlphabet.Cardinality; j++)
            {
                entries.Add(0);
            }

            var intervals = new List<int[]>();
            
            for (int j = 0; j < sourceAlphabet.Cardinality; j++)
            {
                var intervalsManager = new CongenericIntervalsManager(source.CongenericChain(j));
                intervals.Add(intervalsManager.GetIntervals(link));
            }
            
            for (int i = 0; i < source.GetLength(); i++)
            {
                var elementIndex = sourceAlphabet.IndexOf(source[i]);
                int entry = entries[elementIndex];
                entries[elementIndex]++;
                var interval = intervals[elementIndex][entry];
                result.Set(new ValueInt(interval), i);
            }

            return result;
        }
    }
}
