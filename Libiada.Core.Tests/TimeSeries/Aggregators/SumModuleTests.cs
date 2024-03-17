namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The sum module aggregator tests.
/// </summary>
[TestFixture]
public class SumModuleTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = [1, 2, 3, 4, 5];

    /// <summary>
    /// The expected sum mod value.
    /// </summary>
    private const double sumMod = 15;

    /// <summary>
    /// The sum module aggregator test.
    /// </summary>
    [Test]
    public void SumModuleTest()
    {
        var aggregator = new SumModule();
        double result = aggregator.Aggregate(distances);
        Assert.That(result, Is.EqualTo(sumMod));
    }
}
