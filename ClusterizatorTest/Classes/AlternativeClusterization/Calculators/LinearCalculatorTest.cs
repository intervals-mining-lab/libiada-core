using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class LinearCalculatorTest
    {

        [Test]
        public void TwoPointsTest()
        {
            HybridDictionary element = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node2 = new GraphElement(element2, "node2");

            List<GraphElement> el = new List<GraphElement> {node1, node2};

            Connection conn1 = new Connection(0, 1);
            List<Connection> con = new List<Connection> {conn1};

            GraphManager gm = new GraphManager(con,el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(0,gm.Connections[0].Distance);
        }

        [Test]
        public void TwoIntPointsTest()
        {
            
            

            HybridDictionary element = new HybridDictionary {{"characteristic", 15}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 15}};
            GraphElement node2 = new GraphElement(element2, "node2");
            List<GraphElement> el = new List<GraphElement> {node1, node2};

            Connection conn1 = new Connection(0, 1);
            List<Connection> con = new List<Connection> {conn1};

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(0, gm.Connections[0].Distance);
        }

        [Test]
        public void ThreePointsTest()
        {
            HybridDictionary element = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 10.0}};
            GraphElement node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary {{"characteristic", -3.0}};
            GraphElement node3 = new GraphElement(element3, "node3");

            List<GraphElement> el = new List<GraphElement> {node1, node2, node3};

            Connection conn1 = new Connection(0, 1);
            Connection conn2 = new Connection(1, 2);
            Connection conn3 = new Connection(0, 2);

            List<Connection> con = new List<Connection> {conn1, conn2, conn3};

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(5, gm.Connections[0].Distance);
            Assert.AreEqual(13, gm.Connections[1].Distance);
            Assert.AreEqual(18, gm.Connections[2].Distance);
        }

        [Test]
        public void TwoPoints3DTest()
        {
            HybridDictionary element = new HybridDictionary
                {
                    {"characteristic", 15.0},
                    {"characteristic2", 1.0},
                    {"characteristic3", -20.0}
                };
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary
                {
                    {"characteristic", 0.0},
                    {"characteristic2", -3.0},
                    {"characteristic3", -4.0}
                };
            GraphElement node2 = new GraphElement(element2, "node2");

            List<GraphElement> el = new List<GraphElement> {node1, node2};

            Connection conn1 = new Connection(0, 1);

            List<Connection> con = new List<Connection> {conn1};

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
        }

        [Test]
        public void ThreePoints3DTest()
        {
            HybridDictionary element = new HybridDictionary
                {
                    {"characteristic", 15.0},
                    {"characteristic2", 1.0},
                    {"characteristic3", -20.0}
                };
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary
                {
                    {"characteristic", 0.0},
                    {"characteristic2", -3.0},
                    {"characteristic3", -4.0}
                };
            GraphElement node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary
                {
                    {"characteristic", 15.0},
                    {"characteristic2", 1.0},
                    {"characteristic3", -20.0}
                };
            GraphElement node3 = new GraphElement(element3, "node3");

            List<GraphElement> el = new List<GraphElement> {node1, node2, node3};

            Connection conn1 = new Connection(0, 1);
            Connection conn2 = new Connection(0, 2);
            Connection conn3 = new Connection(1, 2);
            List<Connection> con = new List<Connection> {conn1, conn2, conn3};

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
            Assert.AreEqual(0, Math.Round(gm.Connections[1].Distance * 1000));
            Assert.AreEqual(22293, Math.Round(gm.Connections[2].Distance * 1000));
        }
    }
}