using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestLinearCalculator
    {

        [Test]
        public void Test2Points ()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> con = new List<Connection>();
            

            HybridDictionary element = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node2 = new GraphElement(element2, "node2");
            
            el.Add(node1);
            el.Add(node2);

            Connection conn1 = new Connection(0, 1);
            con.Add(conn1);

            GraphManager gm = new GraphManager(con,el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(0,gm.Connections[0].Distance);
        }

        [Test]
        public void Test2IntPoints()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> con = new List<Connection>();

            HybridDictionary element = new HybridDictionary {{"characteristic", 15}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 15}};
            GraphElement node2 = new GraphElement(element2, "node2");

            el.Add(node1);
            el.Add(node2);

            Connection conn1 = new Connection(0, 1);
            con.Add(conn1);

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(0, gm.Connections[0].Distance);
        }

        [Test]
        public void Test3Points()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> con = new List<Connection>();

            HybridDictionary element = new HybridDictionary {{"characteristic", 15.0}};
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary {{"characteristic", 10.0}};
            GraphElement node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary {{"characteristic", -3.0}};
            GraphElement node3 = new GraphElement(element3, "node3");

            el.Add(node1);
            el.Add(node2);
            el.Add(node3);

            Connection conn1 = new Connection(0, 1);
            Connection conn2 = new Connection(1, 2);
            Connection conn3 = new Connection(0, 2);

            con.Add(conn1);
            con.Add(conn2);
            con.Add(conn3);

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(5, gm.Connections[0].Distance);
            Assert.AreEqual(13, gm.Connections[1].Distance);
            Assert.AreEqual(18, gm.Connections[2].Distance);
        }

        [Test]
        public void Test2Points3D()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> con = new List<Connection>();

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

            el.Add(node1);
            el.Add(node2);

            Connection conn1 = new Connection(0, 1);

            con.Add(conn1);

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
        }

        [Test]
        public void Test3Points3D()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> con = new List<Connection>();

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

            el.Add(node1);
            el.Add(node2);
            el.Add(node3);

            Connection conn1 = new Connection(0, 1);
            con.Add(conn1);
            Connection conn2 = new Connection(0, 2);
            con.Add(conn2);
            Connection conn3 = new Connection(1, 2);
            con.Add(conn3);

            GraphManager gm = new GraphManager(con, el);

            LinearCalculator calc = new LinearCalculator();
            calc.Calculate(gm);
            Assert.AreEqual(22293, Math.Round(gm.Connections[0].Distance * 1000));
            Assert.AreEqual(0, Math.Round(gm.Connections[1].Distance * 1000));
            Assert.AreEqual(22293, Math.Round(gm.Connections[2].Distance * 1000));
        }
    }
}