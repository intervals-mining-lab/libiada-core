namespace Clusterizator.Tests.Krab.Calculators
{
    using System;
    using System.Collections.Generic;

    using Clusterizator.Krab;
    using Clusterizator.Krab.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The lambda calculator test.
    /// </summary>
    [TestFixture]
    public class LambdaCalculatorTests
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
            calculator = new TauCalculator();
            calculator.Calculate(gm);
            var lambdaCalculator = new LambdaCalculator();
            lambdaCalculator.Calculate(gm, 2, 1);
            Assert.AreEqual(57, Math.Round(gm.Connections[0].Lambda * 1000));
            Assert.AreEqual(678, Math.Round(gm.Connections[2].Lambda * 100));
            Assert.AreEqual(18, gm.Connections[1].Lambda);
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
            calculator = new TauCalculator();
            calculator.Calculate(gm);
            var lambdaCalculator = new LambdaCalculator();
            lambdaCalculator.Calculate(gm, 2, 1);
            Assert.AreEqual(1625, Math.Round(gm.Connections[0].Lambda * 100));
            Assert.AreEqual(9, Math.Round(gm.Connections[1].Lambda * 1000));
            Assert.AreEqual(2612, Math.Round(gm.Connections[2].Lambda * 100));
        }
    }
}
