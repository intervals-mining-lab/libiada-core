﻿namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness asymmetry test.
/// </summary>
[TestFixture]
public class EntropySkewnessTests : FullCalculatorsTests<EntropySkewness>
{
    /// <summary>
    /// The average remoteness dispersion test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.Cycle, -1.14708)]
    [TestCase(1, Link.Cycle, -3.1965)]
    [TestCase(2, Link.Cycle, -2.16606)]
    [TestCase(3, Link.Cycle, -0.125)]
    [TestCase(4, Link.Cycle, 0)]
    [TestCase(5, Link.Cycle, -3.375)]
    [TestCase(6, Link.Cycle, -1.859589)]
    [TestCase(7, Link.Cycle, -0.125)]
    [TestCase(8, Link.Cycle, 0)]
    public void ChainCalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(3, Link.None, 0)]
    [TestCase(5, Link.None, 0)]
    [TestCase(7, Link.None, 0)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
