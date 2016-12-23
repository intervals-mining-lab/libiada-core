using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Clusterizator.Krab;
using Clusterizator.kMeans;

namespace Clusterizator.Tests
{
    [TestFixture]
    class ClusterizatorsFactoryTests
    {
        [TestCase(ClusterizationType.kMeans, typeof(KMeansClusterization))]
        [TestCase(ClusterizationType.Krab, typeof(KrabClusterization))]
        public void SelectionTest(ClusterizationType type, Type expected)
        {            
            var parameters = new Dictionary<string, double> { 
                                            { "powerWeight", 1 }, 
                                            { "normalizedDistanceWeight", 1}, 
                                            {  "distanceWeight", 4} };
            var clusterizator = ClusterizatorsFactory.CreateClusterization(type, parameters);
            
            Assert.IsInstanceOf(expected, clusterizator);
        }
        [Test]
        public void SelectionTest()
        {
            var parameters = new Dictionary<string, double>();
            Assert.Throws<Exception>(() => ClusterizatorsFactory.CreateClusterization((ClusterizationType)3, parameters));
        }
    }
}
