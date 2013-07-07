using System.Collections;
using Clusterizator.Classes;
using NUnit.Framework;

namespace ClusterizatorTest.Classes
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class DataObjectTest
    {
        ///<summary>
        ///</summary>
        ///
        [Test]
        public void InputOutputTest()
        {
            DataObject test = new DataObject {Id = 1};
            test.Add("x", 2);
            test.Add("y", 2);

            Assert.AreEqual(1, test.Id);
            Assert.AreEqual((double)2, test.Get("x"));
            Assert.AreEqual((double)2, test.Get("y"));

            foreach (DictionaryEntry item in test)
            {
                Assert.AreEqual((double)2, item.Value);
                Assert.IsTrue((string) item.Key == "x" || (string) item.Key == "y");
            }
        }
    }
}