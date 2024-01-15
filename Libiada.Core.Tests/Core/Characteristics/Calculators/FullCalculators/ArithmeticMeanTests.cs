namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The arithmetic mean test.
/// </summary>
[TestFixture]
public class ArithmeticMeanTests : FullCalculatorsTests<ArithmeticMean>
{
    /// <summary>
    /// The chain calculation test.
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
    [TestCase(0, Link.None, 2.4286)]
    [TestCase(0, Link.Start, 2.6)]
    [TestCase(0, Link.End, 2.4)]
    [TestCase(0, Link.Both, 2.5385)]
    [TestCase(0, Link.Cycle, 3)]
    public void ChainCalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
