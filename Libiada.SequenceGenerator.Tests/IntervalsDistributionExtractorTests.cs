namespace Libiada.SequenceGenerator.Tests;

using Libiada.Core.Core;

[TestFixture]
public class IntervalsDistributionExtractorTests
{
    private readonly int[][] orders = IntervalsDistributionsStorage.Orders;

    private readonly Dictionary<Link, IntervalsDistribution[]> intervalsDistributions = IntervalsDistributionsStorage.IntervalsDistributions;
    private readonly Dictionary<Link, Dictionary<IntervalsDistribution, List<int[]>>> ordersIntervalsDistributionsAccordance = IntervalsDistributionsStorage.OrdersIntervalsDistributionsAccordance;

    [TestCase(Link.None)]
    [TestCase(Link.Start)]
    [TestCase(Link.End)]
    [TestCase(Link.Both)]
    [TestCase(Link.Cycle)]
    [TestCase(Link.CycleStart)]
    [TestCase(Link.CycleEnd)]
    public void GetIntervalsDistributionTest(Link link)
    {
        List<IntervalsDistribution> actualInternalsDistribution = new(orders.Length);
        foreach (var order in orders)
        {
            actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, link));
        }
        for (int i = 0; i < actualInternalsDistribution.Count; i++)
        {
            Assert.That(actualInternalsDistribution[i], Is.EqualTo(intervalsDistributions[link][i]));
        }
    }

    [TestCase(Link.None)]
    [TestCase(Link.Start)]
    [TestCase(Link.End)]
    [TestCase(Link.Both)]
    [TestCase(Link.Cycle)]
    [TestCase(Link.CycleStart)]
    [TestCase(Link.CycleEnd)]
    public void GetOrdersIntervalsDistributionsTest(Link link)
    {
        var actualOrdersIntervalsDistributionsAccordance = IntervalsDistributionExtractor.GetOrdersIntervalsDistributionsAccordance(orders, link);
        foreach (var expected in ordersIntervalsDistributionsAccordance[link])
        {
            Assert.That(actualOrdersIntervalsDistributionsAccordance.ContainsKey(expected.Key));
            Assert.That(actualOrdersIntervalsDistributionsAccordance[expected.Key], Has.Count.EqualTo(expected.Value.Count));
            for (int i = 0; i < expected.Value.Count; i++)
            {
                for (int j = 0; j < expected.Value[i].Length; j++)
                {
                    Assert.That(actualOrdersIntervalsDistributionsAccordance[expected.Key][i][j], Is.EqualTo(expected.Value[i][j]));
                }
            }
        }
    }
}
