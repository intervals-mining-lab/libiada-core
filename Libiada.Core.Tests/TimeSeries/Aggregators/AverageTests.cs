﻿namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using Libiada.Core.TimeSeries.Aggregators;

/// <summary>
/// The average aggregator tests.
/// </summary>
[TestFixture]
public class AverageTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = [1, 2, 3, 4, 5];

    /// <summary>
    /// The expected average result.
    /// </summary>
    private const double average = 3;

    /// <summary>
    /// The average aggregator test.
    /// </summary>
    [Test]
    public void AverageTest()
    {
        Average aggregator = new();
        double result = aggregator.Aggregate(distances);
        Assert.That(result, Is.EqualTo(average));
    }
}
