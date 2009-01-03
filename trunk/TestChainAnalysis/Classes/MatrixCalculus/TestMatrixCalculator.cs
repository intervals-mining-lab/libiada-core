using System;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.MatrixCalculus
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestMatrixCalculator
    {
        private DataTable Dt;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            DataObject DObject1 = new DataObject();
            DObject1.Id = 1;
            DObject1.Add("x", 2);
            DObject1.Add("y", 2);

            DataObject DObject2 = new DataObject();
            DObject2.Id = 2;
            DObject2.Add("x", 5);
            DObject2.Add("y", 2);

            DataObject DObject3 = new DataObject();
            DObject3.Id = 3;
            DObject3.Add("x", 4);
            DObject3.Add("y", 3);

            DataObject DObject4 = new DataObject();
            DObject4.Id = 4;
            DObject4.Add("x", 3);
            DObject4.Add("y", 6);

            DataObject DObject5 = new DataObject();
            DObject5.Id = 5;
            DObject5.Add("x", 8);
            DObject5.Add("y", 8);

            DataObject DObject6 = new DataObject();
            DObject6.Id = 6;
            DObject6.Add("x", 9);
            DObject6.Add("y", 7);

            Dt = new DataTable();
            Dt.Add(DObject1);
            Dt.Add(DObject2);
            Dt.Add(DObject3);
            Dt.Add(DObject4);
            Dt.Add(DObject5);
            Dt.Add(DObject6);
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestDivision()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();
            double D = MatrixCalculator.Diameter(Mtr);

            Mtr = MatrixCalculator.Division(Mtr, D);

            Assert.AreEqual(3 / Math.Sqrt(74), Mtr.Get(1, 2));
            Assert.AreEqual(Math.Sqrt(5) / Math.Sqrt(74), Mtr.Get(1, 3));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(74), Mtr.Get(2, 3));
            Assert.AreEqual(Math.Sqrt(17) / Math.Sqrt(74), Mtr.Get(1, 4));
            Assert.AreEqual(Math.Sqrt(20) / Math.Sqrt(74), Mtr.Get(2, 4));
            Assert.AreEqual(Math.Sqrt(10) / Math.Sqrt(74), Mtr.Get(3, 4));
            Assert.AreEqual(Math.Sqrt(72) / Math.Sqrt(74), Mtr.Get(1, 5));
            Assert.AreEqual(Math.Sqrt(45) / Math.Sqrt(74), Mtr.Get(2, 5));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(3, 5));
            Assert.AreEqual(Math.Sqrt(29) / Math.Sqrt(74), Mtr.Get(4, 5));
            Assert.AreEqual(Math.Sqrt(74) / Math.Sqrt(74), Mtr.Get(1, 6));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(2, 6));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(3, 6));
            Assert.AreEqual(Math.Sqrt(37) / Math.Sqrt(74), Mtr.Get(4, 6));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(74), Mtr.Get(5, 6));


            Assert.AreEqual(3 / Math.Sqrt(74), Mtr.Get(2, 1));
            Assert.AreEqual(Math.Sqrt(5) / Math.Sqrt(74), Mtr.Get(3, 1));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(74), Mtr.Get(3, 2));
            Assert.AreEqual(Math.Sqrt(17) / Math.Sqrt(74), Mtr.Get(4, 1));
            Assert.AreEqual(Math.Sqrt(20) / Math.Sqrt(74), Mtr.Get(4, 2));
            Assert.AreEqual(Math.Sqrt(10) / Math.Sqrt(74), Mtr.Get(4, 3));
            Assert.AreEqual(Math.Sqrt(72) / Math.Sqrt(74), Mtr.Get(5, 1));
            Assert.AreEqual(Math.Sqrt(45) / Math.Sqrt(74), Mtr.Get(5, 2));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(5, 3));
            Assert.AreEqual(Math.Sqrt(29) / Math.Sqrt(74), Mtr.Get(5, 4));
            Assert.AreEqual(Math.Sqrt(74) / Math.Sqrt(74), Mtr.Get(6, 1));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(6, 2));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(74), Mtr.Get(6, 3));
            Assert.AreEqual(Math.Sqrt(37) / Math.Sqrt(74), Mtr.Get(6, 4));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(74), Mtr.Get(6, 5));

            
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
        public void TestMinIndexes()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();
            Branch Temp = MatrixCalculator.GetIndexesOfMin(Mtr);

            Assert.IsTrue(Temp.Equals(2));
            Assert.IsTrue(Temp.Equals(3));
        }


        ///<summary>
        ///</summary>
        [Test]
        public void TestDivisionMatrix()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();

            Matrix Mtr2 = Dt.GetDistanceMatrix();
            Mtr2 = MatrixCalculator.Bmin(Mtr2);

            Mtr = MatrixCalculator.Division(Mtr, Mtr2);

            Assert.AreEqual(3 / Math.Sqrt(2), Mtr.Get(1, 2));
            Assert.AreEqual(Math.Sqrt(5) / Math.Sqrt(2), Mtr.Get(1, 3));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(2), Mtr.Get(2, 3));
            Assert.AreEqual(Math.Sqrt(17) / Math.Sqrt(5), Mtr.Get(1, 4));
            Assert.AreEqual(Math.Sqrt(20) / Math.Sqrt(2), Mtr.Get(2, 4));
            Assert.AreEqual(Math.Sqrt(10) / Math.Sqrt(2), Mtr.Get(3, 4));
            Assert.AreEqual(Math.Sqrt(72) / Math.Sqrt(2), Mtr.Get(1, 5));
            Assert.AreEqual(Math.Sqrt(45) / Math.Sqrt(2), Mtr.Get(2, 5));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(3, 5));
            Assert.AreEqual(Math.Sqrt(29) / Math.Sqrt(2), Mtr.Get(4, 5));
            Assert.AreEqual(Math.Sqrt(74) / Math.Sqrt(2), Mtr.Get(1, 6));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(2, 6));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(3, 6));
            Assert.AreEqual(Math.Sqrt(37) / Math.Sqrt(2), Mtr.Get(4, 6));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(2), Mtr.Get(5, 6));


            Assert.AreEqual(3 / Math.Sqrt(2), Mtr.Get(2, 1));
            Assert.AreEqual(Math.Sqrt(5) / Math.Sqrt(2), Mtr.Get(3, 1));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(2), Mtr.Get(3, 2));
            Assert.AreEqual(Math.Sqrt(17) / Math.Sqrt(5), Mtr.Get(4, 1));
            Assert.AreEqual(Math.Sqrt(20) / Math.Sqrt(2), Mtr.Get(4, 2));
            Assert.AreEqual(Math.Sqrt(10) / Math.Sqrt(2), Mtr.Get(4, 3));
            Assert.AreEqual(Math.Sqrt(72) / Math.Sqrt(2), Mtr.Get(5, 1));
            Assert.AreEqual(Math.Sqrt(45) / Math.Sqrt(2), Mtr.Get(5, 2));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(5, 3));
            Assert.AreEqual(Math.Sqrt(29) / Math.Sqrt(2), Mtr.Get(5, 4));
            Assert.AreEqual(Math.Sqrt(74) / Math.Sqrt(2), Mtr.Get(6, 1));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(6, 2));
            Assert.AreEqual(Math.Sqrt(41) / Math.Sqrt(2), Mtr.Get(6, 3));
            Assert.AreEqual(Math.Sqrt(37) / Math.Sqrt(2), Mtr.Get(6, 4));
            Assert.AreEqual(Math.Sqrt(2) / Math.Sqrt(2), Mtr.Get(6, 5));


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
        public void TestPow()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();
            Mtr = MatrixCalculator.Pow(Mtr, 2);

            Assert.AreEqual(9, Math.Round(Mtr.Get(2, 1)));
            Assert.AreEqual(5, Math.Round(Mtr.Get(3, 1)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(3, 2)));
            Assert.AreEqual(17, Math.Round(Mtr.Get(4, 1)));
            Assert.AreEqual(20, Math.Round(Mtr.Get(4, 2)));
            Assert.AreEqual(10, Math.Round(Mtr.Get(4, 3)));
            Assert.AreEqual(72, Math.Round(Mtr.Get(5, 1)));
            Assert.AreEqual(45, Math.Round(Mtr.Get(5, 2)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(5, 3)));
            Assert.AreEqual(29, Math.Round(Mtr.Get(5, 4)));
            Assert.AreEqual(74, Math.Round(Mtr.Get(6, 1)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(6, 2)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(6, 3)));
            Assert.AreEqual(37, Math.Round(Mtr.Get(6, 4)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(6, 5)));


            Assert.AreEqual(9, Math.Round(Mtr.Get( 1,2 )));
            Assert.AreEqual(5, Math.Round(Mtr.Get(1,3)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(2 ,3)));
            Assert.AreEqual(17, Math.Round(Mtr.Get(1,4)));
            Assert.AreEqual(20, Math.Round(Mtr.Get(2,4)));
            Assert.AreEqual(10, Math.Round(Mtr.Get(3,4 )));
            Assert.AreEqual(72, Math.Round(Mtr.Get(1,5)));
            Assert.AreEqual(45, Math.Round(Mtr.Get(2,5)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(3,5)));
            Assert.AreEqual(29, Math.Round(Mtr.Get(4,5)));
            Assert.AreEqual(74, Math.Round(Mtr.Get(1,6)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(2,6)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(3,6)));
            Assert.AreEqual(37, Math.Round(Mtr.Get(4,6)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(5,6)));



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
        public void TestMultiplicate()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();
            Matrix Mtr2 = Dt.GetDistanceMatrix();
            Mtr = MatrixCalculator.Multiplicate(Mtr, Mtr2);

            Assert.AreEqual(9, Math.Round(Mtr.Get(2, 1)));
            Assert.AreEqual(5, Math.Round(Mtr.Get(3, 1)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(3, 2)));
            Assert.AreEqual(17, Math.Round(Mtr.Get(4, 1)));
            Assert.AreEqual(20, Math.Round(Mtr.Get(4, 2)));
            Assert.AreEqual(10, Math.Round(Mtr.Get(4, 3)));
            Assert.AreEqual(72, Math.Round(Mtr.Get(5, 1)));
            Assert.AreEqual(45, Math.Round(Mtr.Get(5, 2)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(5, 3)));
            Assert.AreEqual(29, Math.Round(Mtr.Get(5, 4)));
            Assert.AreEqual(74, Math.Round(Mtr.Get(6, 1)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(6, 2)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(6, 3)));
            Assert.AreEqual(37, Math.Round(Mtr.Get(6, 4)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(6, 5)));


            Assert.AreEqual(9, Math.Round(Mtr.Get(1, 2)));
            Assert.AreEqual(5, Math.Round(Mtr.Get(1, 3)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(2, 3)));
            Assert.AreEqual(17, Math.Round(Mtr.Get(1, 4)));
            Assert.AreEqual(20, Math.Round(Mtr.Get(2, 4)));
            Assert.AreEqual(10, Math.Round(Mtr.Get(3, 4)));
            Assert.AreEqual(72, Math.Round(Mtr.Get(1, 5)));
            Assert.AreEqual(45, Math.Round(Mtr.Get(2, 5)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(3, 5)));
            Assert.AreEqual(29, Math.Round(Mtr.Get(4, 5)));
            Assert.AreEqual(74, Math.Round(Mtr.Get(1, 6)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(2, 6)));
            Assert.AreEqual(41, Math.Round(Mtr.Get(3, 6)));
            Assert.AreEqual(37, Math.Round(Mtr.Get(4, 6)));
            Assert.AreEqual(2, Math.Round(Mtr.Get(5, 6)));



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
        public void TestBMin()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();

            Mtr = MatrixCalculator.Bmin(Mtr);

            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(1,2));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(1,3));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2,3));
            Assert.AreEqual(Math.Sqrt(5), Mtr.Get(1,4));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2,4));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3,4));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(1,5));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2,5));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3,5));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(4,5));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(1,6));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2, 6));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3, 6));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(4, 6));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 6));

            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(2, 1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3, 1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(3, 2));
            Assert.AreEqual(Math.Sqrt(5), Mtr.Get(4, 1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(4, 2));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(4, 3));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 2));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 3));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(5, 4));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(6, 1));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(6, 2));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(6, 3));
            Assert.AreEqual(Math.Sqrt(2), Mtr.Get(6, 4));
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
        public void TestAverge()
        {
            Matrix Mtr = Dt.GetDistanceMatrix();

            Double TheoryResult = 0;
            foreach (double value in Mtr)
            {
                if (!Double.IsNaN(value))
                {
                    TheoryResult += value;
                }
            }
            TheoryResult = TheoryResult/(Mtr.RowCount*Mtr.RowCount - Mtr.RowCount);

            Double Result = MatrixCalculator.Average(Mtr);
            Assert.AreEqual(TheoryResult, Result);
        }
    }
}