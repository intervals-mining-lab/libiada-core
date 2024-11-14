namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness variance test.
/// </summary>
[TestFixture]
public class AverageRemotenessVarianceTests : FullCalculatorsTests<AverageRemotenessVariance>
{
    /// <summary>
    /// The average remoteness variance test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.0716)]
    [TestCase(0, Link.Start, 0.0168)]
    [TestCase(0, Link.End, 0.0169)]
    [TestCase(0, Link.Both, 0.0506)]
    [TestCase(0, Link.Cycle, 0.0365)]

    [TestCase(2, Link.None, 0.5758459898)]
    [TestCase(2, Link.Start, 0.3539214584)]
    [TestCase(2, Link.End, 0.3746324241)]
    [TestCase(2, Link.Both, 0.4057662147)]
    [TestCase(2, Link.Cycle, 0.7039322237)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 0.2615874729)]
    [TestCase(30, Link.Start, 0.2207915344)]
    [TestCase(30, Link.End, 0.0037990343)]
    [TestCase(30, Link.Both, 0.0320311191)]
    [TestCase(30, Link.Cycle, 0.0939945344)]
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
