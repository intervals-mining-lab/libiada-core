namespace Libiada.Clusterizator.Tests.FRiSCluster;

using Clusterizator.FRiSCluster;

/// <summary>
/// The FRiS cluster tests.
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
        double[][] data = [[1], [2], [10]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual, Is.EqualTo(new[] { 0, 0, 1 }));
    }

    /// <summary>
    /// The four points cluster test.
    /// </summary>
    [Test]
    public void FourPointsClusterTest()
    {
        var cluster = new FRiSCluster(2, 2);
        double[][] data = [[-5], [-4], [4], [5]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual, Is.EqualTo(new int[] { 0, 0, 1, 1 }));
    }

    /// <summary>
    /// The two dimension data cluster test.
    /// </summary>
    [Test]
    public void TwoDimensionDataClusterTest()
    {
        var cluster = new FRiSCluster(2, 2);
        double[][] data = [[-5, 1], [-5, 2], [0, 0], [1, 1]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual, Is.EqualTo(new int[] { 0, 0, 1, 1 }));

    }

    /// <summary>
    /// The multiple data points cluster test.
    /// </summary>
    [Test]
    public void MultipleDataPointsClusterTest()
    {
        var cluster = new FRiSCluster(2, 2);
        double[][] data = [[-2.1], [-1.0], [0.3], [1.0], [1.1], [7.0], [9.0]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual, Is.EqualTo(new int[] { 0, 0, 0, 0, 0, 1, 1 }));
    }
}
