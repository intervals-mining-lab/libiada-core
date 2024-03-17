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
        double[][] data = [[1], [2], [10]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual[0], Is.EqualTo(actual[1]));
        Assert.That(actual[0], Is.Not.EqualTo(actual[2]));
    }

    /// <summary>
    /// The four points cluster test.
    /// </summary>
    [Test]
    public void FourPointsClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = [[-5], [-4], [4], [5]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual[0], Is.EqualTo(actual[1]));
        Assert.That(actual[0], Is.Not.EqualTo(actual[2]));
        Assert.That(actual[2], Is.EqualTo(actual[3]));
    }

    /// <summary>
    /// The two dimension data cluster test.
    /// </summary>
    [Test]
    public void TwoDimensionDataClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = [[-5, 1], [-5, 2], [0, 0], [1, 1]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual[0], Is.EqualTo(actual[1]));
        Assert.That(actual[0], Is.Not.EqualTo(actual[2]));
        Assert.That(actual[2], Is.EqualTo(actual[3]));
    }

    /// <summary>
    /// The multiple data points cluster test.
    /// </summary>
    [Test]
    public void MultipleDataPointsClusterTest()
    {
        var cluster = new KMeansClusterization();
        double[][] data = [[-2.1], [-1.0], [0.3], [1.0], [1.1], [7.0], [9.0]];
        int[] actual = cluster.Cluster(2, data);
        Assert.That(actual[0], Is.EqualTo(actual[1]));
        Assert.That(actual[0], Is.EqualTo(actual[2]));
        Assert.That(actual[0], Is.EqualTo(actual[3]));
        Assert.That(actual[0], Is.EqualTo(actual[4]));
        Assert.That(actual[0], Is.Not.EqualTo(actual[5]));
        Assert.That(actual[5], Is.EqualTo(actual[6]));
    }

}
