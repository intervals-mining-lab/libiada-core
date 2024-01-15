namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using System.Collections.Generic;

using Libiada.Core.TimeSeries.Aggregators;

using NUnit.Framework;

/// <summary>
/// The difference module aggregator tests.
/// </summary>
[TestFixture]
public class DifferenceModuleTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = new List<double>()
    {
        1, 2, 3, 4, 5
    };

    /// <summary>
    /// The expected difference module value.
    /// </summary>
    private const double diffMod = 13;

    /// <summary>
    /// The difference module test.
    /// </summary>
    [Test]
    public void DifferenceModuleTest()
    {
        var aggregator = new DifferenceModule();
        double result = aggregator.Aggregate(distances);
        Assert.AreEqual(diffMod, result);
    }
}