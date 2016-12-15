namespace Clusterizator.Tests.Krab
{
    using Clusterizator.Krab;

    using NUnit.Framework;

    /// <summary>
    /// The alternative krab test.
    /// </summary>
    [TestFixture]
    public class KrabClusterizationTests
    {
        /// <summary>
        /// The dt.
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// Test initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            var object1 = new DataObject { Id = 1 };
            object1.Add("x", 2);
            object1.Add("y", 2);

            var object2 = new DataObject { Id = 2 };
            object2.Add("x", 5);
            object2.Add("y", 2);

            var object3 = new DataObject { Id = 3 };
            object3.Add("x", 4);
            object3.Add("y", 3);

            var object4 = new DataObject { Id = 4 };
            object4.Add("x", 3);
            object4.Add("y", 6);

            var object5 = new DataObject { Id = 5 };
            object5.Add("x", 8);
            object5.Add("y", 8);

            var object6 = new DataObject { Id = 6 };
            object6.Add("x", 9);
            object6.Add("y", 7);

            dt = new DataTable { object1, object2, object3, object4, object5, object6 };
        }

        /// <summary>
        /// The clustering test.
        /// </summary>
        [Test]
        public void ClusterizationTest()
        {
            var krab = new KrabClusterization(4, 2, 1);

            var data = new[]
                           {
                               new[] { 2.0, 2.0 },
                               new[] { 5.0, 2.0 },
                               new[] { 4.0, 3.0 },
                               new[] { 3.0, 6.0 },
                               new[] { 8.0, 8.0 },
                               new[] { 9.0, 7.0 }
                           };

            var result = krab.Cluster(2, data);

            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 2);
            Assert.AreEqual(result[3], 2);

            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 1);
        }
    }
}
