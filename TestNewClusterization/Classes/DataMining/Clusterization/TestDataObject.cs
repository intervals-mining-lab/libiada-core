using System.Collections;
using NUnit.Framework;
using NewClusterization.Classes.DataMining.Clusterization;

namespace TestNewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestDataObject
    {

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestInputOutput()
        {
            DataObject Test = new DataObject();
            Test.Id = 1;
            Test.Add("x", 2);
            Test.Add("y", 2);

            Assert.AreEqual(1, Test.Id);
            Assert.AreEqual((double)2, Test.Get("x"));
            Assert.AreEqual((double)2, Test.Get("y"));

            foreach (DictionaryEntry Item in Test)
            {
                Assert.AreEqual((double)2, Item.Value);
                Assert.IsTrue((string) Item.Key == "x" || (string) Item.Key == "y");
            }
        }
    }
}