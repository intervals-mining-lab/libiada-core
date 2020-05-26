using System;
using System.Collections.Generic;
using System.ComponentModel;

using Clusterizator.Krab;
using Clusterizator.ML.NET;

using NUnit.Framework;

namespace Clusterizator.Tests
{
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
        public void SelectionTest(ClusterizationType type, Type expected)
        {
            var parameters = new Dictionary<string, double>
            {
                                            { "powerWeight", 1 },
                                            { "normalizedDistanceWeight", 1 },
                                            { "distanceWeight", 4 }
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
