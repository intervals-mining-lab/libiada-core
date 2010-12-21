using System.Collections.Specialized;
using ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization;
using ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization.Calculators;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestChainAnalysis.Classes.DataMining.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestHCalculator
    {
        private GraphManager manager;

        [SetUp]
        public void init()
        {
            List<GraphElement> elements = new List<GraphElement>();
            List<Connection> connections = new List<Connection>();

            HybridDictionary hd1 = new HybridDictionary();
            hd1.Add("y", 0);
            HybridDictionary hd2 = new HybridDictionary();
            hd2.Add("y", 2);
            HybridDictionary hd3 = new HybridDictionary();
            hd3.Add("y", 5);
            HybridDictionary hd4 = new HybridDictionary();
            hd4.Add("y", 6);

            elements.Add(new GraphElement(hd1, "1"));
            elements.Add(new GraphElement(hd2, "2"));
            elements.Add(new GraphElement(hd3, "3"));
            elements.Add(new GraphElement(hd4, "4"));

            connections.Add(new Connection(0, 1));
            connections.Add(new Connection(0, 2));
            connections.Add(new Connection(0, 3));
            connections.Add(new Connection(1, 2));
            connections.Add(new Connection(1, 3));
            connections.Add(new Connection(2, 3));


            manager = new GraphManager(connections,elements);
        }

        //TODO: тесты для H
        [Test]
        public void Test4Points0()
        {
            manager.Connections[0].Connected = true;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = true;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = false;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 1;
            manager.Elements[2].TaxonNumber = 1;
            manager.Elements[3].TaxonNumber = 2;
            Assert.AreEqual(0.75, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points1()
        {
            manager.Connections[0].Connected = true;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = true;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 1;
            manager.Elements[2].TaxonNumber = 2;
            manager.Elements[3].TaxonNumber = 2;
            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points2()
        {
            manager.Connections[0].Connected = false;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = true;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = true;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 2;
            manager.Elements[2].TaxonNumber = 2;
            manager.Elements[3].TaxonNumber = 2;
            Assert.AreEqual(0.75, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points3()
        {
            manager.Connections[0].Connected = true;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = false;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 1;
            manager.Elements[2].TaxonNumber = 2;
            manager.Elements[3].TaxonNumber = 3;
            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points4()
        {
            manager.Connections[0].Connected = false;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = true;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = false;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 2;
            manager.Elements[2].TaxonNumber = 2;
            manager.Elements[3].TaxonNumber = 3;
            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points5()
        {
            manager.Connections[0].Connected = false;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = true;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 2;
            manager.Elements[2].TaxonNumber = 3;
            manager.Elements[3].TaxonNumber = 3;
            Assert.AreEqual(0.84375, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points6()
        {
            manager.Connections[0].Connected = false;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = false;
            manager.Connections[5].Connected = false;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 2;
            manager.Elements[2].TaxonNumber = 3;
            manager.Elements[3].TaxonNumber = 4;
            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }

        [Test]
        public void Test4Points7()
        {
            manager.Connections[0].Connected = false;
            manager.Connections[1].Connected = true;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = true;
            manager.Connections[5].Connected = false;
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 2;
            manager.Elements[2].TaxonNumber = 1;
            manager.Elements[3].TaxonNumber = 2;
            Assert.AreEqual(1, HCalculator.Calculate(manager));
        }
    }
}