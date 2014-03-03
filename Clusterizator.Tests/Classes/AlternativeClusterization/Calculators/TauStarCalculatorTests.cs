namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Clusterizator.Classes.AlternativeClusterization;
    using Clusterizator.Classes.AlternativeClusterization.Calculators;

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
            var element = new HybridDictionary { { "characteristic", 15.0 } };
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary { { "characteristic", 10.0 } };
            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary { { "characteristic", -3.0 } };
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
            calc = new TauStarCalculator();
            calc.Calculate(gm);
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
                                   { "characteristic3", -25.0 }
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
            calc = new TauStarCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(4459, Math.Round(gm.Connections[0].TauStar * 1000));
            Assert.AreEqual(224, Math.Round(gm.Connections[1].TauStar * 1000));
            Assert.AreEqual(5223, Math.Round(gm.Connections[2].TauStar * 1000));
        }
    }
}