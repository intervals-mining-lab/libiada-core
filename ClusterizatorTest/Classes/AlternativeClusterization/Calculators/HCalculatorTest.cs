using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using System.Collections.Generic;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class HCalculatorTest
    {
        private GraphManager manager;

        [SetUp]
        public void Init()
        {
            HybridDictionary hd1 = new HybridDictionary {{"y", 0}};
            HybridDictionary hd2 = new HybridDictionary {{"y", 2}};
            HybridDictionary hd3 = new HybridDictionary {{"y", 5}};
            HybridDictionary hd4 = new HybridDictionary {{"y", 6}};

            List<GraphElement> elements = new List<GraphElement>
                {
                    new GraphElement(hd1, "1"),
                    new GraphElement(hd2, "2"),
                    new GraphElement(hd3, "3"),
                    new GraphElement(hd4, "4")
                };

            List<Connection> connections = new List<Connection>
                {
                    new Connection(0, 1),
                    new Connection(0, 2),
                    new Connection(0, 3),
                    new Connection(1, 2),
                    new Connection(1, 3),
                    new Connection(2, 3)
                };


            manager = new GraphManager(connections,elements);
        }

        [Test]
        public void FourPointsZeroTest()
        {
            bool[] connected = new[] {true, false, false, true, false, false};

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 1, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.75, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsOneTest()
        {
            bool[] connected = new[] { true, false, false, false, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 1, 2, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsTwoTest()
        {
            bool[] connected = new[] { false, false, false, true, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 2, 2, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.75, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsThreeTest()
        {
            bool[] connected = new[] { true, false, false, false, false, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 1, 2, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsFourTest()
        {
            bool[] connected = new[] { false, false, false, true, false, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 2, 2, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsFiveTest()
        {
            bool[] connected = new[] { false, false, false, true, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 2, 3, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
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
                manager.Elements[i].TaxonNumber = i+1;
            }

            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsSevenTest()
        {
            bool[] connected = new[] { false, true, false, false, true, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 2, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }

        [Test]
        public void FourPointsElevenTest()
        {
            bool[] connected = new[] { false, true, false, false, true, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            int[] taxonNumbers = new[] { 1, 2, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }
    }
}