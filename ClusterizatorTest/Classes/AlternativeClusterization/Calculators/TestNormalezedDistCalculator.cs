using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestNormalezedDistCalculator
    {
        [Test]
        public void Test2Points ()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            GraphElement Node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 20.0);
            GraphElement Node2 = new GraphElement(element2, "node2");

            el.Add(Node1);
            el.Add(Node2);

            Connection Conn1 = new Connection(0, 1);
            graph.Add(Conn1);

            GraphManager GM = new GraphManager(graph, el);

            ICalculator Calc = new LinearCalculator();

            Calc.Calculate(GM);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(GM);
            Assert.AreEqual(1,GM.Connections[0].NormalizedDistance);

        }

        [Test]
        public void Test2IntPoints()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15);
            GraphElement Node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 20);
            GraphElement Node2 = new GraphElement(element2, "node2");

            el.Add(Node1);
            el.Add(Node2);

            Connection Conn1 = new Connection(0, 1);
            graph.Add(Conn1);

            GraphManager GM = new GraphManager(graph, el);

            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(GM);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(GM);
            Assert.AreEqual(1, GM.Connections[0].NormalizedDistance);
        }

        [Test]
        public void Test3Points()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            GraphElement Node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 10.0);
            GraphElement Node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary();
            element3.Add("characteristic", -3.0);
            GraphElement Node3 = new GraphElement(element3, "node3");

            el.Add(Node1);
            el.Add(Node2);
            el.Add(Node3);

            Connection Conn1 = new Connection(0, 1);
            Connection Conn2 = new Connection(1, 2);
            Connection Conn3 = new Connection(0, 2);
            graph.Add(Conn1);
            graph.Add(Conn2);
            graph.Add(Conn3);

            GraphManager GM = new GraphManager(graph, el);

            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(GM);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(GM);
            Assert.AreEqual(278, Math.Round(GM.Connections[0].NormalizedDistance * 1000));
            Assert.AreEqual(722, Math.Round(GM.Connections[1].NormalizedDistance * 1000));
            Assert.AreEqual(1,GM.Connections[2].NormalizedDistance);
        }

        [Test]
        public void Test2Points3D()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            element.Add("characteristic2", 1.0);
            element.Add("characteristic3", -20.0);
            GraphElement Node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 0.0);
            element2.Add("characteristic2", -3.0);
            element2.Add("characteristic3", -4.0);
            GraphElement Node2 = new GraphElement(element2, "node2");

            el.Add(Node1);
            el.Add(Node2);

            Connection Conn1 = new Connection(0, 1);
            graph.Add(Conn1);

            GraphManager GM = new GraphManager(graph, el);

            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(GM);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(GM);
            Assert.AreEqual(1, GM.Connections[0].NormalizedDistance);
        }

        [Test]
        public void Test3Points3D()
        {
            List<GraphElement> el = new List<GraphElement>();
            List<Connection> graph = new List<Connection>();

            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15.0);
            element.Add("characteristic2", 1.0);
            element.Add("characteristic3", -20.0);
            GraphElement Node1 = new GraphElement(element, "node1");

            HybridDictionary element2 = new HybridDictionary();
            element2.Add("characteristic", 0.0);
            element2.Add("characteristic2", -3.0);
            element2.Add("characteristic3", -4.0);
            GraphElement Node2 = new GraphElement(element2, "node2");

            HybridDictionary element3 = new HybridDictionary();
            element3.Add("characteristic", 15.0);
            element3.Add("characteristic2", 1.0);
            element3.Add("characteristic3", -20.0);
            GraphElement Node3 = new GraphElement(element3, "node3");

            el.Add(Node1);
            el.Add(Node2);
            el.Add(Node3);

            Connection Conn1 = new Connection(0, 1);
            graph.Add(Conn1);
            Connection Conn2 = new Connection(0, 2);
            graph.Add(Conn2);
            Connection Conn3 = new Connection(1, 2);
            graph.Add(Conn3);

            GraphManager GM = new GraphManager(graph, el);

            ICalculator Calc = new LinearCalculator();
            Calc.Calculate(GM);
            Calc = new NormalizedLinearCalculator();
            Calc.Calculate(GM);
            Assert.AreEqual(1, GM.Connections[0].NormalizedDistance);
            Assert.AreEqual(0, GM.Connections[1].NormalizedDistance);
            Assert.AreEqual(1, GM.Connections[2].NormalizedDistance);
        }

    }
}