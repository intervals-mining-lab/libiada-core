using LibiadaCore.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator.Tests
{
    [TestFixture]
    public class IntervalsDistributionExtractorTests
    {
        private readonly int[][] orders = IntervalsDistributionsStorage.Orders;

        private readonly Dictionary<Link, IntervalsDistribution[]> intervalsDistributions = IntervalsDistributionsStorage.IntervalsDistributions;

        [TestCase(Link.None)]
        [TestCase(Link.Start)]
        [TestCase(Link.End)]
        [TestCase(Link.Both)]
        [TestCase(Link.Cycle)]
        [TestCase(Link.CycleStart)]
        [TestCase(Link.CycleEnd)]
        public void GetIntervalsDistributionTest(Link link)
        {
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, link));
            }
            for (int i = 0; i < actualInternalsDistribution.Count; i++)
            {
                Assert.AreEqual(intervalsDistributions[link][i], actualInternalsDistribution[i]);
            }
        }
    }
}
