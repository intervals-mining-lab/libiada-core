namespace Clusterizator.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// The data table test.
    /// </summary>
    [TestFixture]
    public class DataTableTests
    {
        /// <summary>
        /// The object 1.
        /// </summary>
        private DataObject object1;

        /// <summary>
        /// The object 2.
        /// </summary>
        private DataObject object2;

        /// <summary>
        /// The object 3.
        /// </summary>
        private DataObject object3;

        /// <summary>
        /// The object 4.
        /// </summary>
        private DataObject object4;

        /// <summary>
        /// The object 5.
        /// </summary>
        private DataObject object5;

        /// <summary>
        /// The object 6.
        /// </summary>
        private DataObject object6;

        /// <summary>
        /// Test initialization method.
        /// </summary>
        [SetUp]
        public void Initialization()
        {
            object1 = new DataObject { Id = 1 };
            object1.Add("x", 2);
            object1.Add("y", 2);

            object2 = new DataObject { Id = 2 };
            object2.Add("x", 5);
            object2.Add("y", 2);

            object3 = new DataObject { Id = 3 };
            object3.Add("x", 4);
            object3.Add("y", 3);

            object4 = new DataObject { Id = 4 };
            object4.Add("x", 3);
            object4.Add("y", 6);

            object5 = new DataObject { Id = 5 };
            object5.Add("x", 8);
            object5.Add("y", 8);

            object6 = new DataObject { Id = 6 };
            object6.Add("x", 9);
            object6.Add("y", 7);
        }

        /// <summary>
        /// The input output test.
        /// </summary>
        [Test]
        public void InputOutputTest()
        {
            var table = new DataTable { object1, object2, object3, object4, object5, object6 };

            Assert.AreEqual(object1, table[1]);
            Assert.AreEqual(object2, table[2]);
            Assert.AreEqual(object3, table[3]);
            Assert.AreEqual(object4, table[4]);
            Assert.AreEqual(object5, table[5]);
            Assert.AreEqual(object6, table[6]);
        }
    }
}