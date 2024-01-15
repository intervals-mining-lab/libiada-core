namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

using NUnit.Framework;

/// <summary>
/// The alternative krab test.
/// </summary>
[TestFixture]
public class KrabClusterizationTests
{
    /// <summary>
    /// The clustering test.
    /// </summary>
    [Test]
    public void ClusterizationTest()
    {
        var krab = new KrabClusterization(4, 2, 1);

        var data = new[]
                       {
                           new[] { 2.0, 2.0 },
                           new[] { 5.0, 2.0 },
                           new[] { 4.0, 3.0 },
                           new[] { 3.0, 6.0 },
                           new[] { 8.0, 8.0 },
                           new[] { 9.0, 7.0 }
                       };

        var result = krab.Cluster(2, data);

        Assert.AreEqual(result[0], 2);
        Assert.AreEqual(result[1], 2);
        Assert.AreEqual(result[2], 2);
        Assert.AreEqual(result[3], 2);

        Assert.AreEqual(result[4], 1);
        Assert.AreEqual(result[5], 1);
    }
}
