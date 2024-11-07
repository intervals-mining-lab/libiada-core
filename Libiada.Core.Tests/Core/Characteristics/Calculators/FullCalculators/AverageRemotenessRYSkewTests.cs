namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class AverageRemotenessRYSkewTests : FullCalculatorsTests<AverageRemotenessRYSkew>
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
    [TestCase(1, Link.None, 0.2290)]
    [TestCase(1, Link.Start, 0.3138)]
    [TestCase(1, Link.End, -0.2065)]
    [TestCase(1, Link.Both, -0.0862)]
    [TestCase(1, Link.Cycle, 0.2050)]

    [TestCase(2, Link.None, 1.444165399575)]
    [TestCase(2, Link.Start, 1.6566498)]
    [TestCase(2, Link.End, 2.369195368)]
    [TestCase(2, Link.Both, 1.550897715)]
    [TestCase(2, Link.Cycle, 2.14199532)]
    public void CalculationTest(int index, Link link, double value)
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
