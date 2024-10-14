namespace Libiada.Clusterizator.Tests;

using System.ComponentModel;
using Clusterizator.Krab;
using Clusterizator.kMeans;

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
    [TestCase(ClusterizationType.KMeans, typeof(KMeansClusterization))]
    [TestCase(ClusterizationType.Krab, typeof(KrabClusterization))]
    public void SelectionTest(ClusterizationType type, Type expected)
    {
        Dictionary<string, double> parameters = new()
        {
                                        { "powerWeight", 1 },
                                        { "normalizedDistanceWeight", 1 },
                                        { "distanceWeight", 4 }
        };
        IClusterizator clusterizator = ClusterizatorsFactory.CreateClusterizator(type, parameters);

        Assert.That(clusterizator, Is.InstanceOf(expected));
    }

    /// <summary>
    /// The selection test.
    /// </summary>
    [Test]
    public void SelectionErrorTest()
    {
        Dictionary<string, double> parameters = [];
        Assert.Throws<InvalidEnumArgumentException>(() => ClusterizatorsFactory.CreateClusterizator(0, parameters));
    }
}
