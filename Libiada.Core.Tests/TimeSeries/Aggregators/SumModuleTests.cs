namespace Libiada.Core.Tests.TimeSeries.Aggregators;

using System.Collections.Generic;

using Libiada.Core.TimeSeries.Aggregators;

using NUnit.Framework;

/// <summary>
/// The sum module aggregator tests.
/// </summary>
[TestFixture]
public class SumModuleTests
{
    /// <summary>
    /// The distances list.
    /// </summary>
    private static readonly List<double> distances = new List<double>()
    {
        1, 2, 3, 4, 5
    };

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
        Assert.AreEqual(sumMod, result);
    }
}