using LibiadaCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceGenerator
{
    public static class IntervalsDistributionExtractor
    {
        public static IntervalsDistribution GetIntervalsDistribution(int[] order, Link link)
        {
            var sequence = new Chain(order.Select(Convert.ToInt16).ToArray());
            sequence.FillIntervalManagers();
            var intervalsDistribution = new IntervalsDistribution();
            foreach (var el in sequence.Alphabet.ToList())
            {
                var congIntervals = sequence.CongenericChain(el).GetArrangement(link);
                foreach (var interval in congIntervals)
                {
                    intervalsDistribution.AddInterval(interval);
                }
            }
            return intervalsDistribution;
        }
    }
}
