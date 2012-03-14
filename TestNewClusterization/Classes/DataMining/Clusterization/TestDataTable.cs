using System;
using NUnit.Framework;
using NewClusterization.Classes.DataMining.Clusterization;

namespace TestNewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestDataTable
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
        public void init()
        {
            DObject1 = new DataObject();
            DObject1.Id = 1;
            DObject1.Add("x",2);
            DObject1.Add("y", 2);

            DObject2 = new DataObject();
            DObject2.Id = 2;
            DObject2.Add("x", 5);
            DObject2.Add("y", 2);

            DObject3 = new DataObject();
            DObject3.Id = 3;
            DObject3.Add("x", 4);
            DObject3.Add("y", 3);

            DObject4 = new DataObject();
            DObject4.Id = 4;
            DObject4.Add("x", 3);
            DObject4.Add("y", 6);

            DObject5 = new DataObject();
            DObject5.Id = 5;
            DObject5.Add("x", 8);
            DObject5.Add("y", 8);

            DObject6 = new DataObject();
            DObject6.Id = 6;
            DObject6.Add("x", 9);
            DObject6.Add("y", 7);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestInputOutput()
        {
            DataTable DTable = new DataTable();

            DTable.Add(DObject1);
            DTable.Add(DObject2);
            DTable.Add(DObject3);
            DTable.Add(DObject4);
            DTable.Add(DObject5);
            DTable.Add(DObject6);

            Assert.AreEqual(DObject1, DTable[1]);
            Assert.AreEqual(DObject2, DTable[2]);
            Assert.AreEqual(DObject3, DTable[3]);
            Assert.AreEqual(DObject4, DTable[4]);
            Assert.AreEqual(DObject5, DTable[5]);
            Assert.AreEqual(DObject6, DTable[6]);
        }
    }
}