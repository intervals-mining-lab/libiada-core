using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization;

namespace TestNewClusterization.Classes.DataMining.AlternativeClusterization
{
    [TestFixture]
    public class TestGraphManager
    {
        private List<Connection> ConnectionsList;
        private List<GraphElement> ElementsList;
        
        [SetUp]
        public void Initialize()
        {
            ConnectionsList = new List<Connection>();
            ElementsList = new List<GraphElement>();
            HybridDictionary hd1 = new HybridDictionary();
            hd1.Add("x", 2);
            hd1.Add("y", 3);
            HybridDictionary hd2 = new HybridDictionary();
            hd2.Add("x", 3);
            hd2.Add("y", 5);
            HybridDictionary hd3 = new HybridDictionary();
            hd3.Add("x", 6);
            hd3.Add("y", 2);
            HybridDictionary hd4 = new HybridDictionary();
            hd4.Add("x", 6);
            hd4.Add("y", 5);
            HybridDictionary hd5 = new HybridDictionary();
            hd5.Add("x", 7);
            hd5.Add("y", 4);
            HybridDictionary hd6 = new HybridDictionary();
            hd6.Add("x", 8);
            hd6.Add("y", 3);
            ElementsList.Add(new GraphElement(hd1, "1"));
            ElementsList.Add(new GraphElement(hd2, "2"));
            ElementsList.Add(new GraphElement(hd3, "3"));
            ElementsList.Add(new GraphElement(hd4, "4"));
            ElementsList.Add(new GraphElement(hd5, "5"));
            ElementsList.Add(new GraphElement(hd6, "6"));
            ConnectionsList.Add(new Connection(0, 1));
            ConnectionsList.Add(new Connection(0, 2));
            ConnectionsList.Add(new Connection(0, 3));
            ConnectionsList.Add(new Connection(0, 4));
            ConnectionsList.Add(new Connection(0, 5));
            ConnectionsList.Add(new Connection(1, 2));
            ConnectionsList.Add(new Connection(1, 3));
            ConnectionsList.Add(new Connection(1, 4));
            ConnectionsList.Add(new Connection(1, 5));
            ConnectionsList.Add(new Connection(2, 3));
            ConnectionsList.Add(new Connection(2, 4));
            ConnectionsList.Add(new Connection(2, 5));
            ConnectionsList.Add(new Connection(3, 4));
            ConnectionsList.Add(new Connection(3, 5));
            ConnectionsList.Add(new Connection(4, 5));
            ConnectionsList[0].Connected = true;
            ConnectionsList[14].Connected = true;
            ElementsList[0].TaxonNumber = 1;
            ElementsList[1].TaxonNumber = 1;
            ElementsList[4].TaxonNumber = 2;
            ElementsList[5].TaxonNumber = 2;

        }

        [Test]
        public void TestUnConnectedGraphs()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Connect(2, 3);
            Assert.IsTrue(ConnectionsList[9].Connected);
            Assert.AreEqual(3, ElementsList[2].TaxonNumber);
            Assert.AreEqual(3, ElementsList[3].TaxonNumber);
        }

        [Test]
        public void TestSearchConnection()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            Assert.AreEqual(-1, connector.SearchConnection(ElementsList[0], ElementsList[0]), "Search fault falue");
            Assert.AreEqual(-1, connector.SearchConnection(ElementsList[4], ElementsList[4]), "Search fault falue");
            Assert.AreEqual(0, connector.SearchConnection(ElementsList[0], ElementsList[1]), "Search fault falue");
            Assert.AreEqual(0, connector.SearchConnection(ElementsList[1], ElementsList[0]), "Search fault falue");
            Assert.AreEqual(14, connector.SearchConnection(ElementsList[4], ElementsList[5]), "Search fault falue");
            Assert.AreEqual(14, connector.SearchConnection(ElementsList[5], ElementsList[4]), "Search fault falue");
            Assert.AreEqual(0, connector.SearchConnection(ElementsList[1], ElementsList[0]), "Search fault falue");
        }

        [Test]
        public void TestOneConnectedGraph()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Connect(0, 2);
            Assert.IsTrue(ConnectionsList[1].Connected);
            Assert.AreEqual(1, ElementsList[0].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[2].TaxonNumber);
        }

        [Test]
        public void TestBothConnectionGraph()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Connect(1, 5);
            Assert.IsTrue(ConnectionsList[8].Connected);
            Assert.AreEqual(1, ElementsList[5].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[4].TaxonNumber);
            Assert.AreEqual(1, ElementsList[5].TaxonNumber);
        }

        [Test]
        public void TestUnBothConnectionGraph()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            ConnectionsList[1].Connected = true;
            ElementsList[2].TaxonNumber = 1;
            connector.Connect(1, 2);
            Assert.IsFalse(ConnectionsList[5].Connected);
            Assert.AreEqual(1, ElementsList[0].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[2].TaxonNumber);
        }

        [Test]
        public void TestCutGraph()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Cut(ElementsList[0], ElementsList[1]);
            Assert.IsFalse(ConnectionsList[0].Connected);
            Assert.AreEqual(3, ElementsList[0].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(2, ElementsList[4].TaxonNumber);
            Assert.AreEqual(2, ElementsList[5].TaxonNumber);
        }

        [Test]
        public void TestCutGraphTrio()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            ConnectionsList[1].Connected = true;
            ElementsList[2].TaxonNumber = 1;
            connector.Cut(ElementsList[0], ElementsList[2]);
            Assert.IsFalse(ConnectionsList[1].Connected);
            Assert.AreEqual(3, ElementsList[0].TaxonNumber);
            Assert.AreEqual(3, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[2].TaxonNumber);

        }

        [Test]
        public void TestClone()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            GraphManager connector2 = connector.Clone();
            Assert.IsInstanceOfType(typeof (GraphManager), connector2);
            Assert.IsInstanceOfType(typeof (Connection), connector2.Connections[0]);
            Assert.IsInstanceOfType(typeof (GraphElement), connector2.Elements[1]);
            Assert.AreNotSame(connector, connector2);
            Assert.AreNotSame(connector.Elements[0], connector2.Elements[0]);
            Assert.AreNotSame(connector.Connections[1], connector2.Connections[1]);
        }

        [Test]
        public void TestGraphConnection()
        {
            ConnectionsList[0].Connected = false;
            ConnectionsList[14].Connected = false;
            for (int i = 0; i < ConnectionsList.Count; i++)
            {
                ElementsList[ConnectionsList[i].FirstElementIndex].TaxonNumber = 0;
                ElementsList[ConnectionsList[i].SecondElementIndex].TaxonNumber = 0;
            }
            ConnectionsList[0].λ = 10;
            ConnectionsList[1].λ = 20;
            ConnectionsList[2].λ = 15;
            ConnectionsList[3].λ = 21;
            ConnectionsList[4].λ = 6;
            ConnectionsList[5].λ = 11;
            ConnectionsList[6].λ = 12;
            ConnectionsList[7].λ = 27;
            ConnectionsList[8].λ = 16;
            ConnectionsList[9].λ = 9;
            ConnectionsList[10].λ = 25;
            ConnectionsList[11].λ = 26;
            ConnectionsList[12].λ = 13;
            ConnectionsList[13].λ = 21;
            ConnectionsList[14].λ = 22;
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.ConnectGraph();
            Assert.IsTrue(ConnectionsList[0].Connected);
            Assert.IsTrue(ConnectionsList[4].Connected);
            Assert.IsTrue(ConnectionsList[5].Connected);
            Assert.IsTrue(ConnectionsList[9].Connected);
            Assert.IsTrue(ConnectionsList[12].Connected);
            Assert.IsFalse(ConnectionsList[1].Connected);
            Assert.IsFalse(ConnectionsList[2].Connected);
            Assert.IsFalse(ConnectionsList[3].Connected);
            Assert.IsFalse(ConnectionsList[6].Connected);
            Assert.IsFalse(ConnectionsList[7].Connected);
            Assert.IsFalse(ConnectionsList[8].Connected);
            Assert.IsFalse(ConnectionsList[10].Connected);
            Assert.IsFalse(ConnectionsList[11].Connected);
            Assert.IsFalse(ConnectionsList[13].Connected);
            Assert.IsFalse(ConnectionsList[14].Connected);
        }

        [Test]
        public void TestCutConnection()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Cut(connector.Connections[0]);
            Assert.IsFalse(ConnectionsList[0].Connected);
            Assert.AreEqual(3, ElementsList[0].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(2, ElementsList[4].TaxonNumber);
            Assert.AreEqual(2, ElementsList[5].TaxonNumber);

        }

        [Test]
        public void TestCutConnectionTrio()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            ConnectionsList[1].Connected = true;
            ElementsList[2].TaxonNumber = 1;
            connector.Cut(connector.Connections[1]);
            Assert.IsFalse(ConnectionsList[1].Connected);
            Assert.AreEqual(3, ElementsList[0].TaxonNumber);
            Assert.AreEqual(3, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[2].TaxonNumber);
        }
    }

}