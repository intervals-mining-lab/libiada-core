namespace Clusterizator.Tests.Krab.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Clusterizator.Krab;
    using Clusterizator.Krab.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The equipotency calculator second test.
    /// </summary>
    [TestFixture]
    public class EquipotencyCalculatorSecondTests
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private GraphManager manager;

        /// <summary>
        /// Test initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            var hd1 = new HybridDictionary { { "y", 0 }, { "x", 10 } };
            var hd2 = new HybridDictionary { { "y", 2 }, { "x", 15 } };
            var hd3 = new HybridDictionary { { "y", 5 }, { "x", 25 } };
            var hd4 = new HybridDictionary { { "y", 6 }, { "x", 15 } };
            var hd5 = new HybridDictionary { { "y", 6 }, { "x", 18 } };

            var elements = new List<GraphElement>
                {
                    new GraphElement(hd1, "1"),
                    new GraphElement(hd2, "2"),
                    new GraphElement(hd3, "3"),
                    new GraphElement(hd4, "4"),
                    new GraphElement(hd5, "5")
                };

            var connections = new List<Connection>
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

            this.manager = new GraphManager(connections, elements);
        }

        /// <summary>
        /// The four points zero test.
        /// </summary>
        [Test]
        public void FourPointsZeroTest()
        {
            var connected = new[]
                {
                    true, false, false, false, true, false,
                    false, true, false, false
                };

            for (int i = 0; i < connected.Length; i++)
            {
                this.manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 1, 1, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                this.manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            var d = EquipotencyCalculator.Calculate(this.manager);
            d = Math.Round(d * 100) / 100;
            Assert.AreEqual(0.64, d);
        }

        /// <summary>
        /// The four points one test.
        /// </summary>
        [Test]
        public void FourPointsOneTest()
        {
            var connected = new[]
                {
                    true, false, false, false,
                    false, false, false, false, false, true
                };
            for (int i = 0; i < connected.Length; i++)
            {
                this.manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 1, 3, 2, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                this.manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            var d = EquipotencyCalculator.Calculate(this.manager);
            d = Math.Round(d * 100) / 100;
            Assert.AreEqual(0.86, d);
        }

        /// <summary>
        /// The four points six test.
        /// </summary>
        [Test]
        public void FourPointsSixTest()
        {
            for (int i = 0; i < 6; i++)
            {
                this.manager.Connections[i].Connected = false;
            }

            for (int i = 0; i < 4; i++)
            {
                this.manager.Elements[i].TaxonNumber = i + 1;
            }

            Assert.AreEqual(1, EquipotencyCalculator.Calculate(this.manager));
        }
    }
}