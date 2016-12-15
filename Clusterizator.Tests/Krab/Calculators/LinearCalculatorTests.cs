namespace Clusterizator.Tests.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    using Clusterizator.Krab;
    using Clusterizator.Krab.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The linear calculator test.
    /// </summary>
    [TestFixture]
    public class LinearCalculatorTests
    {
        /// <summary>
        /// The two points test.
        /// </summary>
        [Test]
        public void TwoPointsTest()
        {
            var node1 = new GraphElement(new[] { 15.0 }, "node1");
            var node2 = new GraphElement(new[] { 15.0 }, "node2");

            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);
            var con = new List<Connection> { conn1 };

            var gm = new GraphManager(con, el);

            var calculator = new LinearCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(0, gm.Connections[0].Distance);
        }

        /// <summary>
        /// The two integer points test.
        /// </summary>
        [Test]
        public void TwoIntPointsTest()
        {
            var node1 = new GraphElement(new[] { 15.0 }, "node1");
            var node2 = new GraphElement(new[] { 15.0 }, "node2");
            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);
            var con = new List<Connection> { conn1 };

            var gm = new GraphManager(con, el);

            var calculator = new LinearCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(0, gm.Connections[0].Distance);
        }

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
            var conn2 = new Connection(1, 2);
            var conn3 = new Connection(0, 2);

            var con = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(con, el);

            var calculator = new LinearCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(5, gm.Connections[0].Distance);
            Assert.AreEqual(13, gm.Connections[1].Distance);
            Assert.AreEqual(18, gm.Connections[2].Distance);
        }

        /// <summary>
        /// The two points 3 d test.
        /// </summary>
        [Test]
        public void TwoPoints3DTest()
        {
            var node1 = new GraphElement(new[] { 15.0, 1.0, -20.0  }, "node1");
            var node2 = new GraphElement(new[] { 0.0, -3.0, -4.0 }, "node2");

            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);

            var con = new List<Connection> { conn1 };

            var gm = new GraphManager(con, el);

            var calculator = new LinearCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
        }

        /// <summary>
        /// The three points 3 d test.
        /// </summary>
        [Test]
        public void ThreePoints3DTest()
        {
            var node1 = new GraphElement(new[] { 15.0, 1.0, -20.0 }, "node1");
            var node2 = new GraphElement(new[] { 0.0, -3.0, -4.0 }, "node2");
            var node3 = new GraphElement(new[] { 15.0, 1.0, -20.0 }, "node3");

            var el = new List<GraphElement> { node1, node2, node3 };

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);
            var con = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(con, el);

            var calculator = new LinearCalculator();
            calculator.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
            Assert.AreEqual(0, Math.Round(gm.Connections[1].Distance * 1000));
            Assert.AreEqual(22293, Math.Round(gm.Connections[2].Distance * 1000));
        }
    }
}
