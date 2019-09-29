using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator
{
    public static class IntervalsDistributionExtensions
    {

        public static IntervalsDistribution SetDistribution(this IntervalsDistribution intervalsDistribution, Dictionary<int, int> distribution)
        {
            intervalsDistribution.Distribution = distribution;
            return intervalsDistribution;
        }
    }
}
