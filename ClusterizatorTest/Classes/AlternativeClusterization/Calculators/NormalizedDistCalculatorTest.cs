namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Clusterizator.Classes.AlternativeClusterization;
    using Clusterizator.Classes.AlternativeClusterization.Calculators;

    using NUnit.Framework;

    /// <summary>
    /// The normalized dist calculator test.
    /// </summary>
    [TestFixture]
    public class NormalizedDistCalculatorTest
    {
        /// <summary>
        /// The two points test.
        /// </summary>
        [Test]
        public void TwoPointsTest()
        {
            var element = new HybridDictionary { { "characteristic", 15.0 } };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary { { "characteristic", 20.0 } };
            var node2 = new GraphElement(element2, "node2");

            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);
            var graph = new List<Connection> { conn1 };

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();

            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(1, gm.Connections[0].NormalizedDistance);
        }

        /// <summary>
        /// The two int points test.
        /// </summary>
        [Test]
        public void TwoIntPointsTest()
        {
            var element = new HybridDictionary { { "characteristic", 15 } };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary { { "characteristic", 20 } };
            var node2 = new GraphElement(element2, "node2");

            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);

            var graph = new List<Connection> { conn1 };

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(1, gm.Connections[0].NormalizedDistance);
        }

        /// <summary>
        /// The three points test.
        /// </summary>
        [Test]
        public void ThreePointsTest()
        {
            var element = new HybridDictionary { { "characteristic", 15.0 } };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary { { "characteristic", 10.0 } };
            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary { { "characteristic", -3.0 } };
            var node3 = new GraphElement(element3, "node3");

            var el = new List<GraphElement> { node1, node2, node3 };

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(1, 2);
            var conn3 = new Connection(0, 2);

            var graph = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(278, Math.Round(gm.Connections[0].NormalizedDistance * 1000));
            Assert.AreEqual(722, Math.Round(gm.Connections[1].NormalizedDistance * 1000));
            Assert.AreEqual(1, gm.Connections[2].NormalizedDistance);
        }

        /// <summary>
        /// The two points 3 d test.
        /// </summary>
        [Test]
        public void TwoPoints3DTest()
        {
            var element = new HybridDictionary
                              {
                                  { "characteristic", 15.0 },
                                  { "characteristic2", 1.0 },
                                  { "characteristic3", -20.0 }
                              };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary
                               {
                                   { "characteristic", 0.0 },
                                   { "characteristic2", -3.0 },
                                   { "characteristic3", -4.0 }
                               };
            var node2 = new GraphElement(element2, "node2");

            var el = new List<GraphElement> { node1, node2 };

            var conn1 = new Connection(0, 1);

            var graph = new List<Connection> { conn1 };

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(1, gm.Connections[0].NormalizedDistance);
        }

        /// <summary>
        /// The three points 3 d test.
        /// </summary>
        [Test]
        public void ThreePoints3DTest()
        {
            var element = new HybridDictionary
                              {
                                  { "characteristic", 15.0 },
                                  { "characteristic2", 1.0 },
                                  { "characteristic3", -20.0 }
                              };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary
                               {
                                   { "characteristic", 0.0 },
                                   { "characteristic2", -3.0 },
                                   { "characteristic3", -4.0 }
                               };
            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary
                               {
                                   { "characteristic", 15.0 },
                                   { "characteristic2", 1.0 },
                                   { "characteristic3", -20.0 }
                               };
            var node3 = new GraphElement(element3, "node3");

            var el = new List<GraphElement> { node1, node2, node3 };

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);

            var graph = new List<Connection> { conn1, conn2, conn3 };

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(1, gm.Connections[0].NormalizedDistance);
            Assert.AreEqual(0, gm.Connections[1].NormalizedDistance);
            Assert.AreEqual(1, gm.Connections[2].NormalizedDistance);
        }
    }
}