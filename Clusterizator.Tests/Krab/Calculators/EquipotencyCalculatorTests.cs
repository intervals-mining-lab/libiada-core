namespace Clusterizator.Tests.Krab.Calculators
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Clusterizator.Krab;
    using Clusterizator.Krab.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The equipotency calculator test.
    /// </summary>
    [TestFixture]
    public class EquipotencyCalculatorTests
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
            var hd1 = new HybridDictionary { { "y", 0 } };
            var hd2 = new HybridDictionary { { "y", 2 } };
            var hd3 = new HybridDictionary { { "y", 5 } };
            var hd4 = new HybridDictionary { { "y", 6 } };

            var elements = new List<GraphElement>
                               {
                                   new GraphElement(hd1, "1"),
                                   new GraphElement(hd2, "2"),
                                   new GraphElement(hd3, "3"),
                                   new GraphElement(hd4, "4")
                               };

            var connections = new List<Connection>
                                  {
                                      new Connection(0, 1),
                                      new Connection(0, 2),
                                      new Connection(0, 3),
                                      new Connection(1, 2),
                                      new Connection(1, 3),
                                      new Connection(2, 3)
                                  };

            manager = new GraphManager(connections, elements);
        }

        /// <summary>
        /// The four points zero test.
        /// </summary>
        [Test]
        public void FourPointsZeroTest()
        {
            var connected = new[] { true, false, false, true, false, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 1, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.75, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points one test.
        /// </summary>
        [Test]
        public void FourPointsOneTest()
        {
            var connected = new[] { true, false, false, false, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 1, 2, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points two test.
        /// </summary>
        [Test]
        public void FourPointsTwoTest()
        {
            var connected = new[] { false, false, false, true, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 2, 2, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.75, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points three test.
        /// </summary>
        [Test]
        public void FourPointsThreeTest()
        {
            var connected = new[] { true, false, false, false, false, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 1, 2, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points four test.
        /// </summary>
        [Test]
        public void FourPointsFourTest()
        {
            var connected = new[] { false, false, false, true, false, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 2, 2, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points five test.
        /// </summary>
        [Test]
        public void FourPointsFiveTest()
        {
            var connected = new[] { false, false, false, true, false, true };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 2, 3, 3 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(0.84375, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points six test.
        /// </summary>
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

            Assert.AreEqual(1, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points seven test.
        /// </summary>
        [Test]
        public void FourPointsSevenTest()
        {
            var connected = new[] { false, true, false, false, true, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 2, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, EquipotencyCalculator.Calculate(manager));
        }

        /// <summary>
        /// The four points eleven test.
        /// </summary>
        [Test]
        public void FourPointsElevenTest()
        {
            var connected = new[] { false, true, false, false, true, false };

            for (int i = 0; i < connected.Length; i++)
            {
                manager.Connections[i].Connected = connected[i];
            }

            var taxonNumbers = new[] { 1, 2, 1, 2 };

            for (int i = 0; i < taxonNumbers.Length; i++)
            {
                manager.Elements[i].TaxonNumber = taxonNumbers[i];
            }

            Assert.AreEqual(1, EquipotencyCalculator.Calculate(manager));
        }
    }
}
