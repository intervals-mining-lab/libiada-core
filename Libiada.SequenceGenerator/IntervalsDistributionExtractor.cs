namespace Libiada.SequenceGenerator;

using Libiada.Core.Core;

public static class IntervalsDistributionExtractor
{
    public static IntervalsDistribution GetIntervalsDistribution(int[] order, Link link)
    {
        Chain sequence = new(order);
        IntervalsDistribution intervalsDistribution = new();
        foreach (IBaseObject el in sequence.Alphabet.ToList())
        {
            int[] congIntervals = sequence.CongenericChain(el).GetArrangement(link);
            foreach (int interval in congIntervals)
            {
                intervalsDistribution.AddInterval(interval);
            }
        }
        return intervalsDistribution;
    }

    public static Dictionary<IntervalsDistribution, List<int[]>> GetOrdersIntervalsDistributionsAccordance(int[][] orders, Link link)
    {
        Dictionary<IntervalsDistribution, List<int[]>> accordance = [];
        foreach (int[] order in orders)
        {
            IntervalsDistribution orderIntervalsDistribution = GetIntervalsDistribution(order, link);
            if (accordance.ContainsKey(orderIntervalsDistribution))
            {
                accordance[orderIntervalsDistribution].Add(order);
            }
            else
            {
                accordance.Add(orderIntervalsDistribution, [order]);
            }
        }
        return accordance;
    }
}
