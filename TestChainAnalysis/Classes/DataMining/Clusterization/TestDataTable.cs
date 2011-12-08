using System;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.MatrixCalculus;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.DataMining.Clusterization
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

        ///<summary>
        ///</summary>
        [Test]
        public void GetMatrix()
        {
            DataTable DTable = new DataTable();

            DTable.Add(DObject1);
            DTable.Add(DObject2);
            DTable.Add(DObject3);
            DTable.Add(DObject4);
            DTable.Add(DObject5);
            DTable.Add(DObject6);

            Matrix Mtr = DTable.GetDistanceMatrix();

            Assert.AreEqual(3, Mtr.Get(1,2));
            Assert.AreEqual(Math.Sqrt(5), Mtr.Get(1, 3));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2, 3));
            Assert.AreEqual(Math.Sqrt(17), Mtr.Get(1, 4));
            Assert.AreEqual(Math.Sqrt(20), Mtr.Get(2, 4));
            Assert.AreEqual(Math.Sqrt(10), Mtr.Get(3, 4));
            Assert.AreEqual(Math.Sqrt(72), Mtr.Get(1, 5));
            Assert.AreEqual(Math.Sqrt(45), Mtr.Get(2, 5));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(3, 5));
            Assert.AreEqual(Math.Sqrt(29), Mtr.Get(4, 5));
            Assert.AreEqual(Math.Sqrt(74), Mtr.Get(1, 6));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(2, 6));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(3, 6));
            Assert.AreEqual(Math.Sqrt(37), Mtr.Get(4, 6));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 6));


            Assert.AreEqual(3, Mtr.Get(2, 1));
            Assert.AreEqual(Math.Sqrt(5), Mtr.Get(3,1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3,2));
            Assert.AreEqual(Math.Sqrt(17), Mtr.Get(4, 1));
            Assert.AreEqual(Math.Sqrt(20), Mtr.Get(4, 2));
            Assert.AreEqual(Math.Sqrt(10), Mtr.Get(4, 3));
            Assert.AreEqual(Math.Sqrt(72), Mtr.Get(5, 1));
            Assert.AreEqual(Math.Sqrt(45), Mtr.Get(5, 2));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(5, 3));
            Assert.AreEqual(Math.Sqrt(29), Mtr.Get(5, 4));
            Assert.AreEqual(Math.Sqrt(74), Mtr.Get(6, 1));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(6, 2));
            Assert.AreEqual(Math.Sqrt(41), Mtr.Get(6, 3));
            Assert.AreEqual(Math.Sqrt(37), Mtr.Get(6, 4));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(6, 5));

            Assert.IsNaN(Mtr.Get(1, 1));
            Assert.IsNaN(Mtr.Get(2, 2));
            Assert.IsNaN(Mtr.Get(3, 3));
            Assert.IsNaN(Mtr.Get(4, 4));
            Assert.IsNaN(Mtr.Get(5, 5));
            Assert.IsNaN(Mtr.Get(6, 6));

        }

        ///<summary>
        ///</summary>
        [Test]
        public void GetDiameter()
        {
            DataTable DTable = new DataTable();

            DTable.Add(DObject1);
            DTable.Add(DObject2);
            DTable.Add(DObject3);
            DTable.Add(DObject4);
            DTable.Add(DObject5);
            DTable.Add(DObject6);

            Matrix Mtr = DTable.GetDistanceMatrix();

            Assert.AreEqual(Math.Sqrt(74), MatrixCalculator.Diameter(Mtr));


        }
    }
}