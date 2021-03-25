namespace Clusterizator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Clusterizator.Krab;
    using Clusterizator.MeanShift;
    using Clusterizator.ML.NET;

    using NUnit.Framework;

    /// <summary>
    /// The clusterizators factory tests.
    /// </summary>
    [TestFixture]
    public class ClusterizatorsFactoryTests
    {
        /// <summary>
        /// The selection test.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        [TestCase(ClusterizationType.KMeans, typeof(KMeansMLNet))]
        [TestCase(ClusterizationType.Krab, typeof(KrabClusterization))]
        [TestCase(ClusterizationType.AffinityPropagation, typeof(Clusterizator.AffinityPropagation.AffinityPropagation))]
        [TestCase(ClusterizationType.FRiSCluster, typeof(Clusterizator.FRiSCluster.FRiSCluster))]
        [TestCase(ClusterizationType.MeanShift, typeof(MeanShiftClusterization))]
        public void SelectionTest(ClusterizationType type, Type expected)
        {
            var parameters = new Dictionary<string, double>
            {
                { "powerWeight", 1 },
                { "normalizedDistanceWeight", 1 },
                { "distanceWeight", 4 },
                { "clustersCount", 2 },
                { "maximumClusters", 3 }
            };
            var clusterizator = ClusterizatorsFactory.CreateClusterizator(type, parameters);

            Assert.IsInstanceOf(expected, clusterizator);
        }

        /// <summary>
        /// The selection test.
        /// </summary>
        [Test]
        public void SelectionErrorTest()
        {
            var parameters = new Dictionary<string, double>();
            Assert.Throws<InvalidEnumArgumentException>(() => ClusterizatorsFactory.CreateClusterizator(0, parameters));
        }
    }
}
