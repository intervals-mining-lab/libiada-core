namespace Clusterizator.Tests.Classes.AlternativeClusterization
{
    using System.Collections;
    using System.Collections.Specialized;

    using Clusterizator.Classes.AlternativeClusterization;

    using NUnit.Framework;

    /// <summary>
    /// The graph element test.
    /// </summary>
    [TestFixture]
    public class GraphElementTests
    {
        /// <summary>
        /// The node test.
        /// </summary>
        [Test]
        public void NodeTest()
        {
            var element = new HybridDictionary { { "characteristic", 15 } };
            var node = new GraphElement(element, "node");
            object tempKey = null;
            object tempValue = null;
            foreach (DictionaryEntry entry in node.Content)
            {
                if (entry.Key.Equals("characteristic"))
                {
                    tempKey = entry.Key;
                    tempValue = entry.Value;
                }
            }

            Assert.AreEqual(15, tempValue);
            Assert.AreEqual("characteristic", tempKey);
            Assert.AreEqual(0, node.TaxonNumber);
        }

        /// <summary>
        /// The node two test.
        /// </summary>
        [Test]
        public void NodeTwoTest()
        {
            var dictionary = new HybridDictionary { { "characteristic", 15 } };
            var node = new GraphElement(dictionary, 1);
            var dictionary2 = new HybridDictionary { { "bla-bla", -8 } };
            node.TaxonNumber = 5;
            object tempKey = null;
            object tempValue = null;
            foreach (DictionaryEntry entry in node.Content)
            {
                if (entry.Key.Equals("characteristic"))
                {
                    tempKey = entry.Key;
                    tempValue = entry.Value;
                }
            }

            Assert.AreEqual(15, tempValue);
            Assert.AreEqual("characteristic", tempKey);
            node.Content = dictionary2;
            foreach (DictionaryEntry entry in node.Content)
            {
                if (entry.Key.Equals("bla-bla"))
                {
                    tempKey = entry.Key;
                    tempValue = entry.Value;
                }
            }

            Assert.AreEqual(-8, tempValue);
            Assert.AreEqual("bla-bla", tempKey);
            Assert.AreEqual(5, node.TaxonNumber);
            node.TaxonNumber = -5;
            Assert.AreEqual(5, node.TaxonNumber);
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            var element = new HybridDictionary { { "characteristic", 15 } };
            var node = new GraphElement(element, "node");
            var nodeClone = node.Clone();
            Assert.AreEqual(node.Content, nodeClone.Content);
            Assert.AreEqual(node.Id, nodeClone.Id);
            Assert.AreNotSame(node, nodeClone);
            Assert.IsInstanceOf(typeof(GraphElement), nodeClone);
        }
    }
}