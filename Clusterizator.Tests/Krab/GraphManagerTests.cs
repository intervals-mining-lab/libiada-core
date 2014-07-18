using System.Collections.Generic;
using System.Collections.Specialized;
using Clusterizator.Krab;
using NUnit.Framework;

namespace Clusterizator.Tests.Krab
{
    /// <summary>
    /// The graph manager test.
    /// </summary>
    [TestFixture]
    public class GraphManagerTests
    {
        /// <summary>
        /// The connections list.
        /// </summary>
        private List<Connection> connectionsList;

        /// <summary>
        /// The elements list.
        /// </summary>
        private List<GraphElement> elementsList;

        /// <summary>
        /// Test initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            var hd1 = new HybridDictionary { { "x", 2 }, { "y", 3 } };
            var hd2 = new HybridDictionary { { "x", 3 }, { "y", 5 } };
            var hd3 = new HybridDictionary { { "x", 6 }, { "y", 2 } };
            var hd4 = new HybridDictionary { { "x", 6 }, { "y", 5 } };
            var hd5 = new HybridDictionary { { "x", 7 }, { "y", 4 } };
            var hd6 = new HybridDictionary { { "x", 8 }, { "y", 3 } };

            this.elementsList = new List<GraphElement>
                               {
                                   new GraphElement(hd1, "1"),
                                   new GraphElement(hd2, "2"),
                                   new GraphElement(hd3, "3"),
                                   new GraphElement(hd4, "4"),
                                   new GraphElement(hd5, "5"),
                                   new GraphElement(hd6, "6")
                               };

            this.connectionsList = new List<Connection>
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

            this.connectionsList[0].Connected = true;
            this.connectionsList[14].Connected = true;
            this.elementsList[0].TaxonNumber = 1;
            this.elementsList[1].TaxonNumber = 1;
            this.elementsList[4].TaxonNumber = 2;
            this.elementsList[5].TaxonNumber = 2;
        }

        /// <summary>
        /// The un connected graphs test.
        /// </summary>
        [Test]
        public void UnConnectedGraphsTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.Connect(2, 3);
            Assert.IsTrue(this.connectionsList[9].Connected);
            Assert.AreEqual(3, this.elementsList[2].TaxonNumber);
            Assert.AreEqual(3, this.elementsList[3].TaxonNumber);
        }

        /// <summary>
        /// The search connection test.
        /// </summary>
        [Test]
        public void SearchConnectionTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            Assert.AreEqual(-1, connector.SearchConnection(this.elementsList[0], this.elementsList[0]), "Search fault failure");
            Assert.AreEqual(-1, connector.SearchConnection(this.elementsList[4], this.elementsList[4]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(this.elementsList[0], this.elementsList[1]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(this.elementsList[1], this.elementsList[0]), "Search fault failure");
            Assert.AreEqual(14, connector.SearchConnection(this.elementsList[4], this.elementsList[5]), "Search fault failure");
            Assert.AreEqual(14, connector.SearchConnection(this.elementsList[5], this.elementsList[4]), "Search fault failure");
            Assert.AreEqual(0, connector.SearchConnection(this.elementsList[1], this.elementsList[0]), "Search fault failure");
        }

        /// <summary>
        /// The one connected graph test.
        /// </summary>
        [Test]
        public void OneConnectedGraphTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.Connect(0, 2);
            Assert.IsTrue(this.connectionsList[1].Connected);
            Assert.AreEqual(1, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[2].TaxonNumber);
        }

        /// <summary>
        /// The both connection graph test.
        /// </summary>
        [Test]
        public void BothConnectionGraphTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.Connect(1, 5);
            Assert.IsTrue(this.connectionsList[8].Connected);
            Assert.AreEqual(1, this.elementsList[5].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[4].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[5].TaxonNumber);
        }

        /// <summary>
        /// The un both connection graph test.
        /// </summary>
        [Test]
        public void UnBothConnectionGraphTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            this.connectionsList[1].Connected = true;
            this.elementsList[2].TaxonNumber = 1;
            connector.Connect(1, 2);
            Assert.IsFalse(this.connectionsList[5].Connected);
            Assert.AreEqual(1, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[2].TaxonNumber);
        }

        /// <summary>
        /// The cut graph test.
        /// </summary>
        [Test]
        public void CutGraphTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.Cut(this.elementsList[0], this.elementsList[1]);
            Assert.IsFalse(this.connectionsList[0].Connected);
            Assert.AreEqual(3, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(2, this.elementsList[4].TaxonNumber);
            Assert.AreEqual(2, this.elementsList[5].TaxonNumber);
        }

        /// <summary>
        /// The cut graph trio test.
        /// </summary>
        [Test]
        public void CutGraphTrioTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            this.connectionsList[1].Connected = true;
            this.elementsList[2].TaxonNumber = 1;
            connector.Cut(this.elementsList[0], this.elementsList[2]);
            Assert.IsFalse(this.connectionsList[1].Connected);
            Assert.AreEqual(3, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(3, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[2].TaxonNumber);
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            var connector2 = connector.Clone();
            Assert.IsInstanceOf(typeof(GraphManager), connector2);
            Assert.IsInstanceOf(typeof(Connection), connector2.Connections[0]);
            Assert.IsInstanceOf(typeof(GraphElement), connector2.Elements[1]);
            Assert.AreNotSame(connector, connector2);
            Assert.AreNotSame(connector.Elements[0], connector2.Elements[0]);
            Assert.AreNotSame(connector.Connections[1], connector2.Connections[1]);
        }

        /// <summary>
        /// The graph connection test.
        /// </summary>
        [Test]
        public void GraphConnectionTest()
        {
            this.connectionsList[0].Connected = false;
            this.connectionsList[14].Connected = false;

            for (int i = 0; i < this.connectionsList.Count; i++)
            {
                this.elementsList[this.connectionsList[i].FirstElementIndex].TaxonNumber = 0;
                this.elementsList[this.connectionsList[i].SecondElementIndex].TaxonNumber = 0;
            }

            var lambdas = new[] { 10, 20, 15, 21, 6, 11, 12, 27, 16, 9, 25, 26, 13, 21, 22 };

            for (int i = 0; i < lambdas.Length; i++)
            {
                this.connectionsList[i].Lambda = lambdas[i];
            }

            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.ConnectGraph();
            Assert.IsTrue(this.connectionsList[0].Connected);
            Assert.IsTrue(this.connectionsList[4].Connected);
            Assert.IsTrue(this.connectionsList[5].Connected);
            Assert.IsTrue(this.connectionsList[9].Connected);
            Assert.IsTrue(this.connectionsList[12].Connected);
            Assert.IsFalse(this.connectionsList[1].Connected);
            Assert.IsFalse(this.connectionsList[2].Connected);
            Assert.IsFalse(this.connectionsList[3].Connected);
            Assert.IsFalse(this.connectionsList[6].Connected);
            Assert.IsFalse(this.connectionsList[7].Connected);
            Assert.IsFalse(this.connectionsList[8].Connected);
            Assert.IsFalse(this.connectionsList[10].Connected);
            Assert.IsFalse(this.connectionsList[11].Connected);
            Assert.IsFalse(this.connectionsList[13].Connected);
            Assert.IsFalse(this.connectionsList[14].Connected);
        }

        /// <summary>
        /// The cut connection test.
        /// </summary>
        [Test]
        public void CutConnectionTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            connector.Cut(connector.Connections[0]);
            Assert.IsFalse(this.connectionsList[0].Connected);
            Assert.AreEqual(3, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(2, this.elementsList[4].TaxonNumber);
            Assert.AreEqual(2, this.elementsList[5].TaxonNumber);
        }

        /// <summary>
        /// The cut connection trio test.
        /// </summary>
        [Test]
        public void CutConnectionTrioTest()
        {
            var connector = new GraphManager(this.connectionsList, this.elementsList);
            this.connectionsList[1].Connected = true;
            this.elementsList[2].TaxonNumber = 1;
            connector.Cut(connector.Connections[1]);
            Assert.IsFalse(this.connectionsList[1].Connected);
            Assert.AreEqual(3, this.elementsList[0].TaxonNumber);
            Assert.AreEqual(3, this.elementsList[1].TaxonNumber);
            Assert.AreEqual(1, this.elementsList[2].TaxonNumber);
        }
    }
}