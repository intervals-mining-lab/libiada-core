using System;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.DataMining.Clusterization.KRAB;
using ChainAnalises.Classes.MatrixCalculus;
using ChainAnalises.Classes.TheoryOfGraphs;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.DataMining.Clusterization.KRAB
{
    ///<summary>
    ///</summary>
    [TestFixture] 
    public class TestGraphCalculator
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
        public void TestCalculate()
        {
            Matrix a = Dt.GetDistanceMatrix();
            Matrix d = MatrixCalculator.Division(a, MatrixCalculator.Diameter(a));
            Matrix Bmin = MatrixCalculator.Bmin(a);
            Matrix tx = MatrixCalculator.Division(a, Bmin);
            Matrix t = MatrixCalculator.Division(tx, MatrixCalculator.Diameter(tx));
            Matrix t_2 = MatrixCalculator.Pow(t, 2);
            Matrix l = MatrixCalculator.Multiplicate(t_2, d);

            ShortestOpenLoopPathBuilder Builder = new ShortestOpenLoopPathBuilder();
            Graph LSOLP = Builder.Create(l);

            Graph ResultGraph = GraphCalculator.Voltage(LSOLP);
            Assert.AreEqual(ResultGraph[new Branch(2, 3)], LSOLP[new Branch(2, 3)] * Math.Pow((4 * (1 / (double)6) * (5 / (double)6)), 4));
            Assert.AreEqual(ResultGraph[new Branch(1, 3)], LSOLP[new Branch(1, 3)] * Math.Pow((4 * (2 / (double)6) * (4 / (double)6)), 4));
            Assert.AreEqual(ResultGraph[new Branch(1, 4)], LSOLP[new Branch(1, 4)] * Math.Pow((4 * (3 / (double)6) * (3 / (double)6)), 4));
            Assert.AreEqual(ResultGraph[new Branch(4, 5)], LSOLP[new Branch(4, 5)] * Math.Pow((4 * (4 / (double)6) * (2 / (double)6)), 4));
            Assert.AreEqual(ResultGraph[new Branch(5, 6)], LSOLP[new Branch(5, 6)] * Math.Pow((4 * (5 / (double)6) * (1 / (double)6)), 4));
        }
    }
}