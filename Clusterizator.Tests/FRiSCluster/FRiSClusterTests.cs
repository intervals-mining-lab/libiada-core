namespace Clusterizator.Tests.FRiSCluster
{
    using Clusterizator.FRiSCluster;

    using NUnit.Framework;

    /// <summary>
    /// The f ri s cluster tests.
    /// </summary>
    [TestFixture]
    public class FRiSClusterTests
    {
        /// <summary>
        /// The simple cluster test.
        /// </summary>
        [Test]
        public void SimpleClusterTest()
        {
            var cluster = new FRiSCluster(2, 2);
            double[][] data = { new double[] { 1 }, new double[] { 2 }, new double[] { 10 } };
            int[] actual = cluster.Cluster(2, data);
            Assert.AreEqual(new[] { 0, 0, 1 }, actual);
        }

        /// <summary>
        /// The four points cluster test.
        /// </summary>
        [Test]
        public void FourPointsClusterTest()
        {
            var cluster = new FRiSCluster(2, 2);
            double[][] data = { new double[] { -5 }, new double[] { -4 }, new double[] { 4 }, new double[] { 5 } };
            int[] actual = cluster.Cluster(2, data);
            Assert.AreEqual(new[] { 0, 0, 1, 1 }, actual);
        }

        /// <summary>
        /// The two dimension data cluster test.
        /// </summary>
        [Test]
        public void TwoDimensionDataClusterTest()
        {
            var cluster = new FRiSCluster(2, 2);
            double[][] data = { new double[] { -5, 1 }, new double[] { -5, 2 }, new double[] { 0, 0 }, new double[] { 1, 1 } };
            int[] actual = cluster.Cluster(2, data);
            Assert.AreEqual(new[] { 0, 0, 1, 1 }, actual);
        }

        /// <summary>
        /// The multiple data points cluster test.
        /// </summary>
        [Test]
        public void MultipleDataPointsClusterTest()
        {
            var cluster = new FRiSCluster(2, 2);
            double[][] data = { new[] { -2.1 }, new[] { -1.0 }, new[] { 0.3 }, new[] { 1.0 }, new[] { 1.1 }, new[] { 7.0 }, new[] { 9.0} };
            int[] actual = cluster.Cluster(2, data);
            Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 1, 1 }, actual);
        }
    }
}
