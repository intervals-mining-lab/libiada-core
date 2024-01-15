namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using System.Collections.Generic;

using Libiada.Core.TimeSeries.Aggregators;

using NUnit.Framework;

/// <summary>
/// The sum square root aggregator tests.
/// </summary>
[TestFixture]
public class SumSquareRootTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = new List<double>()
    {
        1, 2, 3, 4, 5, 6, 7, 8
    };

    /// <summary>
    /// The expected sum sqrt.
    /// </summary>
    private const double sumSqrt = 6;

    /// <summary>
    /// The sum square root test.
    /// </summary>
    [Test]
    public void SumSquareRootTest()
    {
        var aggregator = new SumSquareRoot();
        double result = aggregator.Aggregate(distances);
        Assert.AreEqual(sumSqrt, result);
    }
}