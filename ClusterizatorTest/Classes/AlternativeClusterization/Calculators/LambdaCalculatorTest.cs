using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class LambdaCalculatorTest
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
            var lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(gm,2,1);
            Assert.AreEqual(57, Math.Round(gm.Connections[0].λ * 1000));
            Assert.AreEqual(678, Math.Round(gm.Connections[2].λ * 100));
            Assert.AreEqual(18, gm.Connections[1].λ);
        }

        [Test]
        public void ThreePoints3DTest()
        {
            var element = new HybridDictionary
                {
                    {"characteristic", 15.0},
                    {"characteristic2", 1.0},
                    {"characteristic3", -20.0}
                };

            var node1 = new GraphElement(element, "node1");

            var element2 = new HybridDictionary
                {
                    {"characteristic", 0.0},
                    {"characteristic2", -3.0},
                    {"characteristic3", -4.0}
                };

            var node2 = new GraphElement(element2, "node2");

            var element3 = new HybridDictionary
                {
                    {"characteristic", 15.0},
                    {"characteristic2", 1.0},
                    {"characteristic3", -25.0}
                };

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
            var lambdaCalc = new LambdaCalculator();
            lambdaCalc.Calculate(gm, 2, 1);
            Assert.AreEqual(1625, Math.Round(gm.Connections[0].λ * 100));
            Assert.AreEqual(9, Math.Round(gm.Connections[1].λ * 1000));
            Assert.AreEqual(2612, Math.Round(gm.Connections[2].λ * 100));
        }
    }
}