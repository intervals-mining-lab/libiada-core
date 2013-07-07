using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;

namespace ClusterizatorTest.Classes.AlternativeClusterization
{
    [TestFixture]
    public class GraphManagerTest
    {
        private List<Connection> ConnectionsList;
        private List<GraphElement> ElementsList;

        [SetUp]
        public void Initialize()
        {
            HybridDictionary hd1 = new HybridDictionary {{"x", 2}, {"y", 3}};
            HybridDictionary hd2 = new HybridDictionary {{"x", 3}, {"y", 5}};
            HybridDictionary hd3 = new HybridDictionary {{"x", 6}, {"y", 2}};
            HybridDictionary hd4 = new HybridDictionary {{"x", 6}, {"y", 5}};
            HybridDictionary hd5 = new HybridDictionary {{"x", 7}, {"y", 4}};
            HybridDictionary hd6 = new HybridDictionary {{"x", 8}, {"y", 3}};

            ElementsList = new List<GraphElement>
                {
                    new GraphElement(hd1, "1"),
                    new GraphElement(hd2, "2"),
                    new GraphElement(hd3, "3"),
                    new GraphElement(hd4, "4"),
                    new GraphElement(hd5, "5"),
                    new GraphElement(hd6, "6")
                };

            ConnectionsList = new List<Connection>
                {
                    new Connection(0, 1),
                    new Connection(0, 2),
                    new Connection(0, 3),
                    new Connection(0, 4),
                    new Connection(0, 5),
                    new Connection(1, 2),
                    new Connection(1, 3),
                    new Connection(1, 4),
                    new Connection(1, 5),
                    new Connection(2, 3),
                    new Connection(2, 4),
                    new Connection(2, 5),
                    new Connection(3, 4),
                    new Connection(3, 5),
                    new Connection(4, 5)
                };

            ConnectionsList[0].Connected = true;
            ConnectionsList[14].Connected = true;
            ElementsList[0].TaxonNumber = 1;
            ElementsList[1].TaxonNumber = 1;
            ElementsList[4].TaxonNumber = 2;
            ElementsList[5].TaxonNumber = 2;
        }

        [Test]
        public void UnConnectedGraphsTest()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Connect(2, 3);
            Assert.IsTrue(ConnectionsList[9].Connected);
            Assert.AreEqual(3, ElementsList[2].TaxonNumber);
            Assert.AreEqual(3, ElementsList[3].TaxonNumber);
        }

        [Test]
        public void SearchConnectionTest()
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
        public void OneConnectedGraphTest()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            connector.Connect(0, 2);
            Assert.IsTrue(ConnectionsList[1].Connected);
            Assert.AreEqual(1, ElementsList[0].TaxonNumber);
            Assert.AreEqual(1, ElementsList[1].TaxonNumber);
            Assert.AreEqual(1, ElementsList[2].TaxonNumber);
        }

        [Test]
        public void BothConnectionGraphTest()
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
        public void UnBothConnectionGraphTest()
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
        public void CutGraphTest()
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
        public void CutGraphTrioTest()
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
        public void CloneTest()
        {
            GraphManager connector = new GraphManager(ConnectionsList, ElementsList);
            GraphManager connector2 = connector.Clone();
            Assert.IsInstanceOf(typeof (GraphManager), connector2);
            Assert.IsInstanceOf(typeof (Connection), connector2.Connections[0]);
            Assert.IsInstanceOf(typeof (GraphElement), connector2.Elements[1]);
            Assert.AreNotSame(connector, connector2);
            Assert.AreNotSame(connector.Elements[0], connector2.Elements[0]);
            Assert.AreNotSame(connector.Connections[1], connector2.Connections[1]);
        }

        [Test]
        public void GraphConnectionTest()
        {
            ConnectionsList[0].Connected = false;
            ConnectionsList[14].Connected = false;

            for (int i = 0; i < ConnectionsList.Count; i++)
            {
                ElementsList[ConnectionsList[i].FirstElementIndex].TaxonNumber = 0;
                ElementsList[ConnectionsList[i].SecondElementIndex].TaxonNumber = 0;
            }

            int[] lambdas = new[] {10, 20, 15, 21, 6, 11, 12, 27, 16, 9, 25, 26, 13, 21, 22};

            for (int i = 0; i < lambdas.Length; i++)
            {
                ConnectionsList[i].λ = lambdas[i];
            }

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
        public void CutConnectionTest()
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
        public void CutConnectionTrioTest()
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