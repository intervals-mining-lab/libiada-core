using System;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using System.Collections.Generic;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class HCalculatorSecondTest
    {
        private GraphManager manager;

        [SetUp]
        public void Init()
        {
            HybridDictionary hd1 = new HybridDictionary {{"y", 0}, {"x", 10}};
            HybridDictionary hd2 = new HybridDictionary {{"y", 2}, {"x", 15}};
            HybridDictionary hd3 = new HybridDictionary {{"y", 5}, {"x", 25}};
            HybridDictionary hd4 = new HybridDictionary {{"y", 6}, {"x", 15}};
            HybridDictionary hd5 = new HybridDictionary {{"y", 6}, {"x", 18}};

            List<GraphElement> elements = new List<GraphElement>
                {
                    new GraphElement(hd1, "1"),
                    new GraphElement(hd2, "2"),
                    new GraphElement(hd3, "3"),
                    new GraphElement(hd4, "4"),
                    new GraphElement(hd5, "5")
                };

            List<Connection> connections = new List<Connection>
                {
                    new Connection(0, 1),
                    new Connection(0, 2),
                    new Connection(0, 3),
                    new Connection(0, 4),
                    new Connection(1, 2),
                    new Connection(1, 3),
                    new Connection(1, 4),
                    new Connection(2, 3),
                    new Connection(2, 4),
                    new Connection(3, 4)
                };


            manager = new GraphManager(connections, elements);
        }

        [Test]
        public void FourPointsZeroTest()
        {
            bool[] connected = new[]
                {
                    true, false, false, false, true, false,
                    false, true, false, false
                };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] {1, 1, 1, 1, 2};

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            double d = HCalculator.Calculate(manager);
            d = Math.Round(d*100)/100;
            Assert.AreEqual(0.64, d);
        }

        [Test]
        public void FourPointsOneTest()
        {
            bool[] connected = new[]
                {
                    true, false, false, false,
                    false, false, false, false, false, true
                };
            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] {1, 1, 3, 2, 2};

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            double d = HCalculator.Calculate(manager);
            d = Math.Round(d*100)/100;
            Assert.AreEqual(0.86, d);
        }

        [Test]
        public void FourPointsSixTest()
        {
            for (int i = 0; i < 6; i++)
            {
                manager.Connections[i].Connected = false;
            }

            for (int i = 0; i < 4; i++)
            {
                manager.Elements[i].TaxonNumber = i + 1;
            }

            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }
    }
}