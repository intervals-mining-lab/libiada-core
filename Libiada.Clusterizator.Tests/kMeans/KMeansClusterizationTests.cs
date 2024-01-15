namespace Libiada.Clusterizator.Tests.kMeans;

using Clusterizator.kMeans;

/// <summary>
/// The k-means cluster tests.
/// </summary>
[TestFixture]
public class KMeansClusterizationTests
{
    /// <summary>
    /// The simple cluster test.
    /// </summary>
    [Test]
    public void SimpleClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = { new double[] { 1 }, new double[] { 2 }, new double[] { 10 } };
        int[] actual = cluster.Cluster(2, data);
        Assert.IsTrue(actual[0] == actual[1]);
        Assert.IsTrue(actual[0] != actual[2]);
    }

    /// <summary>
    /// The four points cluster test.
    /// </summary>
    [Test]
    public void FourPointsClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = { new double[] { -5 }, new double[] { -4 }, new double[] { 4 }, new double[] { 5 } };
        int[] actual = cluster.Cluster(2, data);
        Assert.IsTrue(actual[0] == actual[1]);
        Assert.IsTrue(actual[0] != actual[2]);
        Assert.IsTrue(actual[2] == actual[3]);
    }

    /// <summary>
    /// The two dimension data cluster test.
    /// </summary>
    [Test]
    public void TwoDimensionDataClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = { new double[] { -5, 1 }, new double[] { -5, 2 }, new double[] { 0, 0 }, new double[] { 1, 1 } };
        int[] actual = cluster.Cluster(2, data);
        Assert.IsTrue(actual[0] == actual[1]);
        Assert.IsTrue(actual[0] != actual[2]);
        Assert.IsTrue(actual[2] == actual[3]);
    }

    /// <summary>
    /// The multiple data points cluster test.
    /// </summary>
    [Test]
    public void MultipleDataPointsClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = { new[] { -2.1 }, new[] { -1.0 }, new[] { 0.3 }, new[] { 1.0 }, new[] { 1.1 }, new[] { 7.0 }, new[] { 9.0} };
        int[] actual = cluster.Cluster(2, data);
        Assert.IsTrue(actual[0] == actual[1]);
        Assert.IsTrue(actual[0] == actual[2]);
        Assert.IsTrue(actual[0] == actual[3]);
        Assert.IsTrue(actual[0] == actual[4]);
        Assert.IsTrue(actual[0] != actual[5]);
        Assert.IsTrue(actual[5] == actual[6]);
    }
}
