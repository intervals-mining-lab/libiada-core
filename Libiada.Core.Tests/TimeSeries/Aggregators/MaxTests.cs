﻿namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The max aggregator tests.
/// </summary>
[TestFixture]
public class MaxTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = new List<double>()
    {
        1, 2, 3, 4, 5
    };

    /// <summary>
    /// The expected max value.
    /// </summary>
    private const double max = 5;

    /// <summary>
    /// The max aggregator test.
    /// </summary>
    [Test]
    public void MaxTest()
    {
        var aggregator = new Max();
        double result = aggregator.Aggregate(distances);
        Assert.AreEqual(max, result);
    }
}