using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;

namespace ClusterizatorTest.Classes.AlternativeClusterization
{
    [TestFixture]
    public class GraphManagerTest
    {
        private List<Connection> connectionsList;
        private List<GraphElement> elementsList;

        [SetUp]
        public void Initialize()
        {
            var hd1 = new HybridDictionary {{"x", 2}, {"y", 3}};
            var hd2 = new HybridDictionary {{"x", 3}, {"y", 5}};
            var hd3 = new HybridDictionary {{"x", 6}, {"y", 2}};
            var hd4 = new HybridDictionary {{"x", 6}, {"y", 5}};
            var hd5 = new HybridDictionary {{"x", 7}, {"y", 4}};
            var hd6 = new HybridDictionary {{"x", 8}, {"y", 3}};

            elementsList = new List<GraphElement>
                {
                    new GraphElement(hd1, "1"),
                    new GraphElement(hd2, "2"),
                    new GraphElement(hd3, "3"),
                    new GraphElement(hd4, "4"),
                    new GraphElement(hd5, "5"),
                    new GraphElement(hd6, "6")
                };

            connectionsList = new List<Connection>
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

            connectionsList[0].Connected = true;
            connectionsList[14].Connected = true;
            elementsList[0].TaxonNumber = 1;
            elementsList[1].TaxonNumber = 1;
            elementsList[4].TaxonNumber = 2;
            elementsList[5].TaxonNumber = 2;
        }

        [Test]
        public void UnConnectedGraphsTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connector.Connect(2, 3);
            Assert.IsTrue(connectionsList[9].Connected);
            Assert.AreEqual(3, elementsList[2].TaxonNumber);
            Assert.AreEqual(3, elementsList[3].TaxonNumber);
        }

        [Test]
        public void SearchConnectionTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            Assert.AreEqual(-1, connector.SearchConnection(elementsList[0], elementsList[0]), "Search fault failure");
            Assert.AreEqual(-1, connector.SearchConnection(elementsList[4], elementsList[4]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(elementsList[0], elementsList[1]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(elementsList[1], elementsList[0]), "Search fault failure");
            Assert.AreEqual(14, connector.SearchConnection(elementsList[4], elementsList[5]), "Search fault failure");
            Assert.AreEqual(14, connector.SearchConnection(elementsList[5], elementsList[4]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(elementsList[1], elementsList[0]), "Search fault failure");
        }

        [Test]
        public void OneConnectedGraphTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connector.Connect(0, 2);
            Assert.IsTrue(connectionsList[1].Connected);
            Assert.AreEqual(1, elementsList[0].TaxonNumber);
            Assert.AreEqual(1, elementsList[1].TaxonNumber);
            Assert.AreEqual(1, elementsList[2].TaxonNumber);
        }

        [Test]
        public void BothConnectionGraphTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connector.Connect(1, 5);
            Assert.IsTrue(connectionsList[8].Connected);
            Assert.AreEqual(1, elementsList[5].TaxonNumber);
            Assert.AreEqual(1, elementsList[1].TaxonNumber);
            Assert.AreEqual(1, elementsList[4].TaxonNumber);
            Assert.AreEqual(1, elementsList[5].TaxonNumber);
        }

        [Test]
        public void UnBothConnectionGraphTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connectionsList[1].Connected = true;
            elementsList[2].TaxonNumber = 1;
            connector.Connect(1, 2);
            Assert.IsFalse(connectionsList[5].Connected);
            Assert.AreEqual(1, elementsList[0].TaxonNumber);
            Assert.AreEqual(1, elementsList[1].TaxonNumber);
            Assert.AreEqual(1, elementsList[2].TaxonNumber);
        }

        [Test]
        public void CutGraphTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connector.Cut(elementsList[0], elementsList[1]);
            Assert.IsFalse(connectionsList[0].Connected);
            Assert.AreEqual(3, elementsList[0].TaxonNumber);
            Assert.AreEqual(1, elementsList[1].TaxonNumber);
            Assert.AreEqual(2, elementsList[4].TaxonNumber);
            Assert.AreEqual(2, elementsList[5].TaxonNumber);
        }

        [Test]
        public void CutGraphTrioTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connectionsList[1].Connected = true;
            elementsList[2].TaxonNumber = 1;
            connector.Cut(elementsList[0], elementsList[2]);
            Assert.IsFalse(connectionsList[1].Connected);
            Assert.AreEqual(3, elementsList[0].TaxonNumber);
            Assert.AreEqual(3, elementsList[1].TaxonNumber);
            Assert.AreEqual(1, elementsList[2].TaxonNumber);

        }

        [Test]
        public void CloneTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            var connector2 = connector.Clone();
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
            connectionsList[0].Connected = false;
            connectionsList[14].Connected = false;

            for (int i = 0; i < connectionsList.Count; i++)
            {
                elementsList[connectionsList[i].FirstElementIndex].TaxonNumber = 0;
                elementsList[connectionsList[i].SecondElementIndex].TaxonNumber = 0;
            }

            var lambdas = new[] {10, 20, 15, 21, 6, 11, 12, 27, 16, 9, 25, 26, 13, 21, 22};

            for (int i = 0; i < lambdas.Length; i++)
            {
                connectionsList[i].lambda = lambdas[i];
            }

            var connector = new GraphManager(connectionsList, elementsList);
            connector.ConnectGraph();
            Assert.IsTrue(connectionsList[0].Connected);
            Assert.IsTrue(connectionsList[4].Connected);
            Assert.IsTrue(connectionsList[5].Connected);
            Assert.IsTrue(connectionsList[9].Connected);
            Assert.IsTrue(connectionsList[12].Connected);
            Assert.IsFalse(connectionsList[1].Connected);
            Assert.IsFalse(connectionsList[2].Connected);
            Assert.IsFalse(connectionsList[3].Connected);
            Assert.IsFalse(connectionsList[6].Connected);
            Assert.IsFalse(connectionsList[7].Connected);
            Assert.IsFalse(connectionsList[8].Connected);
            Assert.IsFalse(connectionsList[10].Connected);
            Assert.IsFalse(connectionsList[11].Connected);
            Assert.IsFalse(connectionsList[13].Connected);
            Assert.IsFalse(connectionsList[14].Connected);
        }

        [Test]
        public void CutConnectionTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connector.Cut(connector.Connections[0]);
            Assert.IsFalse(connectionsList[0].Connected);
            Assert.AreEqual(3, elementsList[0].TaxonNumber);
            Assert.AreEqual(1, elementsList[1].TaxonNumber);
            Assert.AreEqual(2, elementsList[4].TaxonNumber);
            Assert.AreEqual(2, elementsList[5].TaxonNumber);
        }

        [Test]
        public void CutConnectionTrioTest()
        {
            var connector = new GraphManager(connectionsList, elementsList);
            connectionsList[1].Connected = true;
            elementsList[2].TaxonNumber = 1;
            connector.Cut(connector.Connections[1]);
            Assert.IsFalse(connectionsList[1].Connected);
            Assert.AreEqual(3, elementsList[0].TaxonNumber);
            Assert.AreEqual(3, elementsList[1].TaxonNumber);
            Assert.AreEqual(1, elementsList[2].TaxonNumber);
        }
    }

}