using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestTauStarCalculator
    {
        [Test]
        public void Test3Points()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();
          
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
            Connection conn2 = new Connection(0, 2);
            Connection conn3 = new Connection(1, 2);
            

            graph.Add(conn1);
            graph.Add(conn2);
            graph.Add(conn3);

            GraphManager gm = new GraphManager(graph, el);

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

        [Test]
        public void Test3Points3D()
        {
            List<Connection> graph = new List<Connection>();
            List<GraphElement> el = new List<GraphElement>();

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
                    {"characteristic3", -25.0}
                };
            GraphElement node3 = new GraphElement(element3, "node3");

            el.Add(node1);
            el.Add(node2);
            el.Add(node3);
            
            Connection conn1 = new Connection(0, 1);
            graph.Add(conn1);
            Connection conn2 = new Connection(0, 2);
            graph.Add(conn2);
            Connection conn3 = new Connection(1, 2);
            graph.Add(conn3);

            GraphManager gm = new GraphManager(graph, el);

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