using System.Collections;
using System.Collections.Specialized;
using NUnit.Framework;
using NewClusterization.Classes.DataMining.Clusterization.AlternativeClusterization;

namespace TestNewClusterization.Classes.DataMining.AlternativeClusterization
{
    [TestFixture]
    public class TestGraphElement
    {
        [Test]
        public void TestNode()
        {
            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15);
            GraphElement Node = new GraphElement(element,"node");
            object TempKey = null;
            object TempValue = null;
            foreach (DictionaryEntry entry in Node.Content)
            {
                if(entry.Key.Equals("characteristic"))
                {
                    TempKey = entry.Key;
                    TempValue = entry.Value;
                }
            }
            Assert.AreEqual(15, TempValue);
            Assert.AreEqual("characteristic", TempKey);
            Assert.AreEqual(0,Node.TaxonNumber);
        }

        [Test]
        public void TestNode2()
        {
            HybridDictionary dictionary =new HybridDictionary();
            dictionary.Add("characteristic", 15);
            GraphElement Node = new GraphElement(dictionary,1);
            HybridDictionary dictionary2 = new HybridDictionary();
            dictionary2.Add("bla-bla", -8);
            Node.TaxonNumber = 5;
            object TempKey = null;
            object TempValue = null;
            foreach (DictionaryEntry entry in Node.Content)
            {
                if (entry.Key.Equals("characteristic"))
                {
                    TempKey = entry.Key;
                    TempValue = entry.Value;
                }
            }
            Assert.AreEqual(15, TempValue);
            Assert.AreEqual("characteristic", TempKey);
            Node.Content = dictionary2;
            foreach (DictionaryEntry entry in Node.Content)
            {
                if (entry.Key.Equals("bla-bla"))
                {
                    TempKey = entry.Key;
                    TempValue = entry.Value;
                }
            }
            Assert.AreEqual(-8, TempValue);
            Assert.AreEqual("bla-bla", TempKey);
            Assert.AreEqual(5, Node.TaxonNumber);
            Node.TaxonNumber = -5;
            Assert.AreEqual(5, Node.TaxonNumber);
        }
        [Test]
        public void TestClone ()
        {
            HybridDictionary element = new HybridDictionary();
            element.Add("characteristic", 15);
            GraphElement Node = new GraphElement(element, "node");
            GraphElement NodeClone = Node.Clone();
            Assert.AreEqual(Node.Content,NodeClone.Content);
            Assert.AreEqual(Node.Id,NodeClone.Id);
            Assert.AreNotSame(Node,NodeClone);
            Assert.IsInstanceOf(typeof (GraphElement), NodeClone);
        }
    }
}