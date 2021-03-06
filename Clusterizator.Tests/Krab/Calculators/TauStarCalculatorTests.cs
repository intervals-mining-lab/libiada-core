namespace Clusterizator.Tests.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    using Clusterizator.Krab;
    using Clusterizator.Krab.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The tau star calculator test.
    /// </summary>
    [TestFixture]
    public class TauStarCalculatorTests
    {
        /// <summary>
        /// The three points test.
        /// </summary>
        [Test]
        public void ThreePointsTest()
        {
            var node1 = new GraphElement(new[] { 15.0 }, "node1");

            var node2 = new GraphElement(new[] { 10.0 }, "node2");

            var node3 = new GraphElement(new[] { -3.0 }, "node3");

            var el = new List<GraphElement> { node1, node2, node3 };

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);

            var graph = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(graph, el);

            ICalculator calculator = new LinearCalculator();
            calculator.Calculate(gm);
            calculator = new NormalizedLinearCalculator();
            calculator.Calculate(gm);
            calculator = new TauStarCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(385, Math.Round(gm.Connections[0].TauStar * 1000));
            Assert.AreEqual(3.6, gm.Connections[1].TauStar);
            Assert.AreEqual(2.6, gm.Connections[2].TauStar);
        }

        /// <summary>
        /// The three points 3 d test.
        /// </summary>
        [Test]
        public void ThreePoints3DTest()
        {
            var node1 = new GraphElement(new[] { 15.0, 1.0, -20.0 }, "node1");
            var node2 = new GraphElement(new[] { 0.0, -3.0, -4.0 }, "node2");
            var node3 = new GraphElement(new[] { 15.0, 1.0, -25.0 }, "node3");

            var el = new List<GraphElement> { node1, node2, node3 };

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);

            var graph = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(graph, el);

            ICalculator calculator = new LinearCalculator();
            calculator.Calculate(gm);
            calculator = new NormalizedLinearCalculator();
            calculator.Calculate(gm);
            calculator = new TauStarCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(4459, Math.Round(gm.Connections[0].TauStar * 1000));
            Assert.AreEqual(224, Math.Round(gm.Connections[1].TauStar * 1000));
            Assert.AreEqual(5223, Math.Round(gm.Connections[2].TauStar * 1000));
        }
    }
}
