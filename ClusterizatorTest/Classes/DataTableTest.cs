using Clusterizator.Classes;
using NUnit.Framework;

namespace ClusterizatorTest.Classes
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class DataTableTest
    {
        private DataObject DObject1;
        private DataObject DObject2;
        private DataObject DObject3;
        private DataObject DObject4;
        private DataObject DObject5;
        private DataObject DObject6;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            DObject1 = new DataObject {Id = 1};
            DObject1.Add("x",2);
            DObject1.Add("y", 2);

            DObject2 = new DataObject {Id = 2};
            DObject2.Add("x", 5);
            DObject2.Add("y", 2);

            DObject3 = new DataObject {Id = 3};
            DObject3.Add("x", 4);
            DObject3.Add("y", 3);

            DObject4 = new DataObject {Id = 4};
            DObject4.Add("x", 3);
            DObject4.Add("y", 6);

            DObject5 = new DataObject {Id = 5};
            DObject5.Add("x", 8);
            DObject5.Add("y", 8);

            DObject6 = new DataObject {Id = 6};
            DObject6.Add("x", 9);
            DObject6.Add("y", 7);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void InputOutputTest()
        {
            var dTable = new DataTable {DObject1, DObject2, DObject3, DObject4, DObject5, DObject6};

            Assert.AreEqual(DObject1, dTable[1]);
            Assert.AreEqual(DObject2, dTable[2]);
            Assert.AreEqual(DObject3, dTable[3]);
            Assert.AreEqual(DObject4, dTable[4]);
            Assert.AreEqual(DObject5, dTable[5]);
            Assert.AreEqual(DObject6, dTable[6]);
        }
    }
}