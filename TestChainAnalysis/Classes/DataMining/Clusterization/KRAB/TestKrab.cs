using System.Collections;
using ChainAnalises.Classes.DataMining.Clusterization;
using ChainAnalises.Classes.DataMining.Clusterization.KRAB;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.DataMining.Clusterization.KRAB
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestKrab
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
        public void TestClusterization()
        {
            KrabCalusterization Krab = new KrabCalusterization(Dt);
            ArrayList Result = Krab.Clusterizate(2).Clusters;

            Assert.IsTrue(((Cluster)Result[1]).Items.Contains(1));
            Assert.IsTrue(((Cluster)Result[1]).Items.Contains(3));
            Assert.IsTrue(((Cluster)Result[1]).Items.Contains(2));
            Assert.IsTrue(((Cluster)Result[1]).Items.Contains(4));

            Assert.IsTrue(((Cluster)Result[0]).Items.Contains(5));
            Assert.IsTrue(((Cluster)Result[0]).Items.Contains(6));
        }
    }
}