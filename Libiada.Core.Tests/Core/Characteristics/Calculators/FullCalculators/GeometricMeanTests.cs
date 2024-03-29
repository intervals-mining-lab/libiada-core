namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The geometric mean test.
/// </summary>
[TestFixture]
public class GeometricMeanTests : FullCalculatorsTests<GeometricMean>
{
    /// <summary>
    /// The calculation test.
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
    [TestCase(0, Link.None, 2.0339)]
    [TestCase(0, Link.Start, 2.155)]
    [TestCase(0, Link.End, 2.0237)]
    [TestCase(0, Link.Both, 2.1182)]
    [TestCase(0, Link.Cycle, 2.3522)]
    public void CalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(0, link, value);
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
    [TestCase(7, Link.None, 1)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
