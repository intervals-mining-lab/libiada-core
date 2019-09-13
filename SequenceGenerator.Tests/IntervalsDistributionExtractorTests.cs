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
        [Test]
        public void GetIntervalsDistributionWithNoneLinkTest()
        {
            var orders = new int[][] {
                new [] {1,1,1,1 },
                new [] { 1,1,1,2 },
                new [] { 1,1,2,1 },
                new [] { 1,1,2,2 },
                new [] { 1,1,2,3 },
                new [] { 1,2,1,1 },
                new [] { 1,2,1,2 },
                new [] { 1,2,1,3 },
                new [] { 1,2,2,1 },
                new [] { 1,2,2,2 },
                new [] { 1,2,2,3 },
                new [] { 1,2,3,1 },
                new [] { 1,2,3,2 },
                new [] { 1,2,3,3 },
                new [] { 1,2,3,4 }
            };
            var expectedInternalsDistribution = new IntervalsDistribution[]
            {
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>()),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach(var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.None));
            }
            for(int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }
    }
}
