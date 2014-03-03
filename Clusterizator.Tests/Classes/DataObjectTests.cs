namespace ClusterizatorTest.Classes
{
    using System.Collections;

    using Clusterizator.Classes;

    using NUnit.Framework;

    /// <summary>
    /// The data object test.
    /// </summary>
    [TestFixture]
    public class DataObjectTests
    {
        /// <summary>
        /// The input output test.
        /// </summary>
        [Test]
        public void InputOutputTest()
        {
            var test = new DataObject { Id = 1 };
            test.Add("x", 2);
            test.Add("y", 2);

            Assert.AreEqual(1, test.Id);
            Assert.AreEqual((double)2, test.Get("x"));
            Assert.AreEqual((double)2, test.Get("y"));

            foreach (DictionaryEntry item in test)
            {
                Assert.AreEqual((double)2, item.Value);
                Assert.IsTrue((string)item.Key == "x" || (string)item.Key == "y");
            }
        }
    }
}