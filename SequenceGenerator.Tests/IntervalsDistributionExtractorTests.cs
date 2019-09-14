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
                new [] { 1,1,1,1 },
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

        [Test]
        public void GetIntervalsDistributionWithStartLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,3 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,2 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 },
                    { 3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 2,2 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 },
                    {3,1 },
                    {4,1 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.Start));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }

        [Test]
        public void GetIntervalsDistributionWithEndLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 2,3 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 2,2 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 },
                    { 3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    { 1,1},
                    { 2,2 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {2,1 },
                    {3,1 },
                    {4,1 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.End));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }

        [Test]
        public void GetIntervalsDistributionWithStartAndEndLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,5 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,4 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,2 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,4 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,1 },
                    {3,2 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,2 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    { 2,3 },
                    {3,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,2 },
                    {3,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,4 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,2 },
                    { 3,3 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    { 1,2},
                    { 2,3 },
                    {3,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,3 },
                    {2,1 },
                    {3,2 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,2 },
                    {3,2 },
                    {4,2 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.Both));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }

        [Test]
        public void GetIntervalsDistributionWithCycleLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {4,4 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.Cycle));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }

        [Test]
        public void GetIntervalsDistributionWithCycleStartLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {4,4 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.CycleStart));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }

        [Test]
        public void GetIntervalsDistributionWithCycleEndLinkTest()
        {
            var orders = new int[][] {
                new [] { 1,1,1,1 },
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
                    {1,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,4 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {3,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,2 },
                    {2,1 },
                    {4,1 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    { 3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {2,2 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {1,1 },
                    {3,1 },
                    {4,2 }
                }),
                new IntervalsDistribution().SetDistribution(new Dictionary<int, int>(){
                    {4,4 }
                }),
            };
            var actualInternalsDistribution = new List<IntervalsDistribution>();
            foreach (var order in orders)
            {
                actualInternalsDistribution.Add(IntervalsDistributionExtractor.GetIntervalsDistribution(order, Link.CycleEnd));
            }
            for (int i = 0; i < expectedInternalsDistribution.Length; i++)
            {
                Assert.AreEqual(expectedInternalsDistribution[i], actualInternalsDistribution[i]);
            }
        }
    }
}
