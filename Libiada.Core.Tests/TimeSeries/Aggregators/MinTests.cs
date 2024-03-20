namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The min aggregator tests.
/// </summary>
[TestFixture]
public class MinTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = [1, 2, 3, 4, 5];

    /// <summary>
    /// The expected min value.
    /// </summary>
    private const double min = 1;

    /// <summary>
    /// The min aggregator test.
    /// </summary>
    [Test]
    public void MinTest()
    {
        Min aggregator = new();
        double result = aggregator.Aggregate(distances);
        Assert.That(result, Is.EqualTo(min));
    }
}
