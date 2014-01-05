using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TauCalculatorTest
    {
        [Test]
        public void ThreePointsTest()
        {
            var element = new HybridDictionary {{"characteristic", 15.0}};
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary {{"characteristic", 10.0}};
            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary {{"characteristic", -3.0}};
            var node3 = new GraphElement(element3, "node3");

            var el = new List<GraphElement> {node1, node2, node3};

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);

            var graph = new List<Connection> {conn1, conn2, conn3};

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            calc = new TauStarCalculator();
            calc.Calculate(gm);
            calc = new TauCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(107, Math.Round(gm.Connections[0].Tau * 1000));
            Assert.AreEqual(722, Math.Round(gm.Connections[2].Tau * 1000));
            Assert.AreEqual(1, gm.Connections[1].Tau);
        }

        [Test]
        public void ThreePoints3DTest()
        {
            var element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            element.Add("characteristic2", 1.0);
            element.Add("characteristic3", -20.0);
            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary();
            element2.Add("characteristic", 0.0);
            element2.Add("characteristic2", -3.0);
            element2.Add("characteristic3", -4.0);
            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary();
            element3.Add("characteristic", 15.0);
            element3.Add("characteristic2", 1.0);
            element3.Add("characteristic3", -25.0);
            var node3 = new GraphElement(element3, "node3");

            var el = new List<GraphElement> {node1, node2, node3};

            var conn1 = new Connection(0, 1);
            var conn2 = new Connection(0, 2);
            var conn3 = new Connection(1, 2);

            var graph = new List<Connection> {conn1, conn2, conn3};

            var gm = new GraphManager(graph, el);

            ICalculator calc = new LinearCalculator();

            calc.Calculate(gm);
            calc = new NormalizedLinearCalculator();
            calc.Calculate(gm);
            calc = new TauStarCalculator();
            calc.Calculate(gm);
            calc = new TauCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(854, Math.Round(gm.Connections[0].Tau * 1000));
            Assert.AreEqual(43, Math.Round(gm.Connections[1].Tau * 1000));
            Assert.AreEqual(1, gm.Connections[2].Tau);
        }
      
    }
}