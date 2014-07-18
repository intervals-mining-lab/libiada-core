using NUnit.Framework;

namespace Clusterizator.Tests
{
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
            this.object1 = new DataObject { Id = 1 };
            this.object1.Add("x", 2);
            this.object1.Add("y", 2);

            this.object2 = new DataObject { Id = 2 };
            this.object2.Add("x", 5);
            this.object2.Add("y", 2);

            this.object3 = new DataObject { Id = 3 };
            this.object3.Add("x", 4);
            this.object3.Add("y", 3);

            this.object4 = new DataObject { Id = 4 };
            this.object4.Add("x", 3);
            this.object4.Add("y", 6);

            this.object5 = new DataObject { Id = 5 };
            this.object5.Add("x", 8);
            this.object5.Add("y", 8);

            this.object6 = new DataObject { Id = 6 };
            this.object6.Add("x", 9);
            this.object6.Add("y", 7);
        }

        /// <summary>
        /// The input output test.
        /// </summary>
        [Test]
        public void InputOutputTest()
        {
            var table = new DataTable { this.object1, this.object2, this.object3, this.object4, this.object5, this.object6 };

            Assert.AreEqual(this.object1, table[1]);
            Assert.AreEqual(this.object2, table[2]);
            Assert.AreEqual(this.object3, table[3]);
            Assert.AreEqual(this.object4, table[4]);
            Assert.AreEqual(this.object5, table[5]);
            Assert.AreEqual(this.object6, table[6]);
        }
    }
}