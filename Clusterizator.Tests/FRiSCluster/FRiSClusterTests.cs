using NUnit.Framework;

namespace Clusterizator.Tests.FRiSCluster
{
    [TestFixture]
    public class FRiSClusterTests
    {
        [Test]
        public void SimpleClusterTest()
        {
            var Cluster = new Clusterizator.FRiSCluster.FRiSCluster(2, 2);
            double[][] data = new double[3][] { new double[]{ 1 },new double[]{ 2 }, new double[]{ 10 } };
            var actual = Cluster.Cluster(2, data);
            Assert.AreEqual(new int[] { 1, 1, 2 }, actual);
        }
    }
}
