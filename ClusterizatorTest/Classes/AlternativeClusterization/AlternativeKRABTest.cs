using System.Collections;
using Clusterizator.Classes;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;

namespace ClusterizatorTest.Classes.AlternativeClusterization
{
    [TestFixture]
    public class AlternativeKRABTest
    {
        private DataTable Dt;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            var dObject1 = new DataObject {Id = 1};
            dObject1.Add("x", 2);
            dObject1.Add("y", 2);

            var dObject2 = new DataObject {Id = 2};
            dObject2.Add("x", 5);
            dObject2.Add("y", 2);

            var dObject3 = new DataObject {Id = 3};
            dObject3.Add("x", 4);
            dObject3.Add("y", 3);

            var dObject4 = new DataObject {Id = 4};
            dObject4.Add("x", 3);
            dObject4.Add("y", 6);

            var dObject5 = new DataObject {Id = 5};
            dObject5.Add("x", 8);
            dObject5.Add("y", 8);

            var dObject6 = new DataObject {Id = 6};
            dObject6.Add("x", 9);
            dObject6.Add("y", 7);

            Dt = new DataTable {dObject1, dObject2, dObject3, dObject4, dObject5, dObject6};
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ClusterizationTest()
        {
            var krab = new AlternativeKRAB(Dt,4,2,1);
            var result = krab.Clusterizate(2).Clusters;

            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)1));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)3));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)2));
            Assert.IsTrue(((Cluster)result[1]).Items.Contains((long)4));

            Assert.IsTrue(((Cluster)result[0]).Items.Contains((long)5));
            Assert.IsTrue(((Cluster)result[0]).Items.Contains((long)6));
        }

        [Test]
        public void SimpleAllVariantsClusterizationTest()
        {
            var dObject1 = new DataObject {Id = 1};
            dObject1.Add("x", 2);
            
            var dObject2 = new DataObject {Id = 2};
            dObject2.Add("x", 5);
           
            var dObject3 = new DataObject {Id = 3};
            dObject3.Add("x", 4);

            var dObject4 = new DataObject {Id = 4};
            dObject4.Add("x", 3);

            var dataTable = new DataTable {dObject1, dObject2, dObject3, dObject4};

            var krab = new AlternativeKRAB(dataTable,4,2,1);
            var result = krab.ClusterizateAllVariants().Variants;
            Assert.AreEqual(3,result.Count);
        }

        [Test]
        public void AllVariantsClusterization2DTest()
        {
            var dObject1 = new DataObject {Id = 1};
            dObject1.Add("x", 2);
            dObject1.Add("y", 2);

            var dObject2 = new DataObject {Id = 2};
            dObject2.Add("x", 5);
            dObject2.Add("y", 2);

            var dObject3 = new DataObject {Id = 3};
            dObject3.Add("x", 4);
            dObject3.Add("y", 3);

            var dObject4 = new DataObject {Id = 4};
            dObject4.Add("x", 3);
            dObject4.Add("y", 6);

            var dataTable = new DataTable {dObject1, dObject2, dObject3, dObject4};

            var krab = new AlternativeKRAB(dataTable,4,2,1);
            var result = krab.ClusterizateAllVariants().Variants;
            Assert.AreEqual(3, result.Count);
        }

    }
}
