namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The difference square root aggregator tests.
/// </summary>
[TestFixture]
public class DifferenceSquareRootTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];

    /// <summary>
    /// The expected difference square root value.
    /// </summary>
    private const double diffSqrt = 8;

    /// <summary>
    /// The difference square root aggregator test.
    /// </summary>
    [Test]
    public void DifferenceSquareRootTest()
    {
        DifferenceSquareRoot aggregator = new();
        double result = aggregator.Aggregate(distances);
        Assert.That(result, Is.EqualTo(diffSqrt));
    }
}
