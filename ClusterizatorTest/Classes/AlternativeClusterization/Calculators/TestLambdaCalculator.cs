using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestLambdaCalculator
    {
        [Test]
        public void Test3Points()
        {
            List<Connection> graph = new List<Connection>();
            List<GraphElement> el = new List<GraphElement>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 10.0);
            GraphElement node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary();
            element3.Add("characteristic", -3.0);
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
            calc = new TauCalculator();
            calc.Calculate(gm);
            LambdaCalculator lmbdaCalc = new LambdaCalculator();
            lmbdaCalc.Calculate(gm,2,1);
            Assert.AreEqual(57, Math.Round(gm.Connections[0].λ * 1000));
            Assert.AreEqual(678, Math.Round(gm.Connections[2].λ * 100));
            Assert.AreEqual(18, gm.Connections[1].λ);
        }

        [Test]
        public void Test3Points3D()
        {
            List<Connection> graph = new List<Connection>();
            List<GraphElement> el = new List<GraphElement>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            element.Add("characteristic2", 1.0);
            element.Add("characteristic3", -20.0);
            GraphElement node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 0.0);
            element2.Add("characteristic2", -3.0);
            element2.Add("characteristic3", -4.0);
            GraphElement node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary();
            element3.Add("characteristic", 15.0);
            element3.Add("characteristic2", 1.0);
            element3.Add("characteristic3", -25.0);
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
            calc = new TauCalculator();
            calc.Calculate(gm);
            LambdaCalculator lmbdaCalc = new LambdaCalculator();
            lmbdaCalc.Calculate(gm, 2, 1);
            Assert.AreEqual(1625, Math.Round(gm.Connections[0].λ * 100));
            Assert.AreEqual(9, Math.Round(gm.Connections[1].λ * 1000));
            Assert.AreEqual(2612, Math.Round(gm.Connections[2].λ * 100));
        }
    }
}