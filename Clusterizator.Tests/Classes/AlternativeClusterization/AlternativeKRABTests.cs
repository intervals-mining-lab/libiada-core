namespace ClusterizatorTest.Classes.AlternativeClusterization
{
    using Clusterizator.Classes;
    using Clusterizator.Classes.AlternativeClusterization;

    using NUnit.Framework;

    /// <summary>
    /// The alternative krab test.
    /// </summary>
    [TestFixture]
    public class AlternativeKRABTests
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

            this.dt = new DataTable { object1, object2, object3, object4, object5, object6 };
        }

        /// <summary>
        /// The clusterization test.
        /// </summary>
        [Test]
        public void ClusterizationTest()
        {
            var krab = new AlternativeKRAB(this.dt, 4, 2, 1);
            var result = krab.Clusterizate(2).Clusters;

            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)1));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)3));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)2));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)4));

            Assert.IsTrue(((Cluster)result[0]).Items.Contains((long)5));
            Assert.IsTrue(((Cluster)result[0]).Items.Contains((long)6));
        }

        /// <summary>
        /// The simple all variants clusterization test.
        /// </summary>
        [Test]
        public void SimpleAllVariantsClusterizationTest()
        {
            var object1 = new DataObject { Id = 1 };
            object1.Add("x", 2);

            var object2 = new DataObject { Id = 2 };
            object2.Add("x", 5);

            var object3 = new DataObject { Id = 3 };
            object3.Add("x", 4);

            var object4 = new DataObject { Id = 4 };
            object4.Add("x", 3);

            var dataTable = new DataTable { object1, object2, object3, object4 };

            var krab = new AlternativeKRAB(dataTable, 4, 2, 1);
            var result = krab.ClusterizateAllVariants().Variants;
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// The all variants clusterization 2 d test.
        /// </summary>
        [Test]
        public void AllVariantsClusterization2DTest()
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

            var dataTable = new DataTable { object1, object2, object3, object4 };

            var krab = new AlternativeKRAB(dataTable, 4, 2, 1);
            var result = krab.ClusterizateAllVariants().Variants;
            Assert.AreEqual(3, result.Count);
        }
    }
}