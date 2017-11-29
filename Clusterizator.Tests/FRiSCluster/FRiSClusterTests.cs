﻿using NUnit.Framework;

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

        [Test]
        public void FoutrPointsClusterTest()
        {
            var Cluster = new Clusterizator.FRiSCluster.FRiSCluster(2, 2);
            double[][] data = new double[4][] { new double[] { -5 }, new double[] { -4 }, new double[] { 4 }, new double[] { 5 } };
            var actual = Cluster.Cluster(2, data);
            Assert.AreEqual(new int[] { 1, 1, 2, 2 }, actual);
        }

        [Test]
        public void TwoDementionDataClusterTest()
        {
            var Cluster = new Clusterizator.FRiSCluster.FRiSCluster(2, 2);
            double[][] data = new double[4][] { new double[] { -5, 1 }, new double[] { -5, 2 }, new double[] { 0, 0 }, new double[] { 1, 1 } };
            var actual = Cluster.Cluster(2, data);
            Assert.AreEqual(new int[] { 1, 1, 2, 2 }, actual);
        }

        [Test]
        public void MultipleDatapointsClusterTest()
        {
            var Cluster = new Clusterizator.FRiSCluster.FRiSCluster(2, 2);
            double[][] data = new double[7][] { new [] { -2.1 }, new [] { -1.0 }, new [] { 0.3 }, new [] { 1.0 }, new [] { 1.1 }, new [] { 7.0 }, new [] { 9.0} };
            var actual = Cluster.Cluster(2, data);
            Assert.AreEqual(new int[] { 1, 1, 1, 1, 1, 2, 2 }, actual);
        }
    }
}
