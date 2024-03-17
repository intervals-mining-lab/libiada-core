namespace Libiada.Clusterizator.Tests.Krab;

using Clusterizator.Krab;

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

        double[][] data = [
                           [2.0, 2.0],
                           [5.0, 2.0],
                           [4.0, 3.0],
                           [3.0, 6.0],
                           [8.0, 8.0],
                           [9.0, 7.0]
                          ];

        var result = krab.Cluster(2, data);

        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(2));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(2));
            Assert.That(result[3], Is.EqualTo(2));

            Assert.That(result[4], Is.EqualTo(1));
            Assert.That(result[5], Is.EqualTo(1));
        });
    }
}
